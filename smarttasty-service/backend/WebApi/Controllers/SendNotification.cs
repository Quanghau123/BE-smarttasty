using backend.Domain.Enums.Commons.Response;
using backend.Infrastructure.Helpers.Commons.Response;
using backend.Domain.Models.Requests.Notifications;
using backend.Application.DTOs.KafkaPayload;
using backend.Application.DTOs.Kafka;
using backend.Infrastructure.Messaging.Kafka;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using backend.Domain.Enums;


namespace backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly KafkaProducerService _kafkaProducer;
        private readonly IMapper _mapper;

        public NotificationsController(KafkaProducerService kafkaProducer, IMapper mapper)
        {
            _kafkaProducer = kafkaProducer;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Send([FromBody] SendNotificationRequest req)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var payload = _mapper.Map<SendNotificationPayload>(req);
            payload.RequestedByUserId = userId;
            payload.RequestedByRole = User.FindFirst(ClaimTypes.Role)?.Value switch
            {
                "admin" => UserRole.admin,
                "user" => UserRole.user,
                _ => null
            };

            var envelope = new KafkaEnvelope<SendNotificationPayload>
            {
                Event = "SendNotification",
                Source = "smarttasty-service",
                Target = string.Empty,
                Payload = payload
            };

            await _kafkaProducer.SendMessageAsync(envelope, topic: "notifications");
            return Accepted(new { status = "queued" });
        }
    }
}