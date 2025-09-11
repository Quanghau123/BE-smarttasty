using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using NotificationService.Application.Requests.Shared;
using NotificationService.Application.Commons.Utils;

namespace NotificationService.Application.Services
{
    public class EmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly IConfiguration _config;

        public EmailService(ILogger<EmailService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task SendEmailAsync(EmailReq req, string txId)
        {
            var emailEnabled = _config.GetValue<bool>("Email:Enable");
            if (!emailEnabled)
            {
                _logger.LogInformation("Ignore sendEmail because feature disabled, TxId={TxId}", txId);
                return;
            }

            try
            {
                var subject = NotificationUtils.FormatNotificationContent(req.Subject, req.Params ?? new Dictionary<string, object>());
                var templateName = NotificationUtils.FormatNotificationContent(req.EmailTemplate, req.Params ?? new Dictionary<string, object>());

                var resourcePath = _config.GetValue<string>("Email:Resource");
                var basePath = string.IsNullOrEmpty(resourcePath)
                    ? Path.Combine(AppContext.BaseDirectory, "Templates")
                    : resourcePath;

                var templatePath = Path.Combine(basePath, templateName ?? string.Empty);

                if (!File.Exists(templatePath))
                {
                    _logger.LogError("Template file not found: {TemplatePath}, TxId={TxId}", templatePath, txId);
                    return;
                }

                var body = await File.ReadAllTextAsync(templatePath);

                foreach (var kv in req.Params ?? new Dictionary<string, object>())
                {
                    body = body.Replace($"{{{{{kv.Key}}}}}", kv.Value?.ToString());
                }

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(
                    _config.GetValue<string>("Email:FromName") ?? "",
                    _config.GetValue<string>("Email:From")));
                message.To.Add(MailboxAddress.Parse(req.Email));

                if (req.EmailCC != null && req.EmailCC.Any())
                {
                    foreach (var cc in req.EmailCC.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        message.Cc.Add(MailboxAddress.Parse(cc));
                    }
                }

                if (req.EmailBCC != null && req.EmailBCC.Any())
                {
                    foreach (var bcc in req.EmailBCC.Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        message.Bcc.Add(MailboxAddress.Parse(bcc));
                    }
                }

                message.Subject = subject;

                var builder = new BodyBuilder { HtmlBody = body };

                if (req.FileAttachments != null && req.FileAttachments.Any())
                {
                    foreach (var file in req.FileAttachments)
                    {
                        if (File.Exists(file.FileUrl))
                        {
                            using var stream = File.OpenRead(file.FileUrl);

                            if (!string.IsNullOrEmpty(file.Cid))
                            {
                                var image = builder.LinkedResources.Add(file.FileName, stream);
                                image.ContentId = file.Cid;
                            }
                            else
                            {
                                builder.Attachments.Add(file.FileName, stream, ContentType.Parse("application/octet-stream"));
                            }
                        }
                        else
                        {
                            _logger.LogWarning("Attachment file not found: {FileUrl}, TxId={TxId}", file.FileUrl, txId);
                        }
                    }
                }

                message.Body = builder.ToMessageBody();

                var host = _config.GetValue<string>("Email:Smtp:Host");
                var port = _config.GetValue<int>("Email:Smtp:Port");
                var user = _config.GetValue<string>("Email:Smtp:User");
                var pass = _config.GetValue<string>("Email:Smtp:Pass");

                using var client = new SmtpClient();
                await client.ConnectAsync(host, port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(user, pass);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation("Send email to {Email} successfully, TxId={TxId}", req.Email, txId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during SendEmail, TxId={TxId}, Error={Message}", txId, ex.Message);
            }
        }
    }
}
