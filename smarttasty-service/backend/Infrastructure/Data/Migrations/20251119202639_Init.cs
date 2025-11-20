using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    UserPassword = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BusinessOwnerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_BusinessOwnerId",
                        column: x => x.BusinessOwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    Steps = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ImagePublicId = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    AverageRating = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OpenTime = table.Column<string>(type: "text", nullable: false),
                    CloseTime = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeReviews_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    AppliedPromotionId = table.Column<int>(type: "integer", nullable: true),
                    AppliedVoucherCode = table.Column<string>(type: "text", nullable: true),
                    FinalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "text", nullable: false),
                    RecipientName = table.Column<string>(type: "text", nullable: false),
                    RecipientPhone = table.Column<string>(type: "text", nullable: false),
                    DeliveryStatus = table.Column<int>(type: "integer", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscountType = table.Column<int>(type: "integer", nullable: false),
                    DiscountValue = table.Column<float>(type: "real", nullable: false),
                    TargetType = table.Column<int>(type: "integer", nullable: false),
                    VoucherCode = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    AdultCount = table.Column<int>(type: "integer", nullable: false),
                    ChildCount = table.Column<int>(type: "integer", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReservationTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Method = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    PaymentUrl = table.Column<string>(type: "text", nullable: true),
                    PaidAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OrderSnapshotJson = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishPromotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    PromotionId = table.Column<int>(type: "integer", nullable: false),
                    OriginalPrice = table.Column<float>(type: "real", nullable: true),
                    AppliedPrice = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishPromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishPromotions_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishPromotions_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPromotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PromotionId = table.Column<int>(type: "integer", nullable: false),
                    MinOrderValue = table.Column<float>(type: "real", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: true),
                    TargetUserId = table.Column<int>(type: "integer", nullable: true),
                    IsGlobal = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPromotions_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPromotions_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReservationId = table.Column<int>(type: "integer", nullable: false),
                    ContactName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingCustomers_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReservationId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChangedBy = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationStatusHistories_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CODPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentId = table.Column<int>(type: "integer", nullable: false),
                    IsCollected = table.Column<bool>(type: "boolean", nullable: false),
                    CollectedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CODPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CODPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentId = table.Column<int>(type: "integer", nullable: false),
                    Provider = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RawData = table.Column<string>(type: "text", nullable: true),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTransactionLogs_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refunds_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VNPayPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentId = table.Column<int>(type: "integer", nullable: false),
                    VnpTxnRef = table.Column<string>(type: "text", nullable: false),
                    BankCode = table.Column<string>(type: "text", nullable: true),
                    CardType = table.Column<string>(type: "text", nullable: true),
                    ResponseCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNPayPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VNPayPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZaloPayPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentId = table.Column<int>(type: "integer", nullable: false),
                    AppTransId = table.Column<string>(type: "text", nullable: false),
                    ZpTransId = table.Column<string>(type: "text", nullable: true),
                    ResponseMessage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaloPayPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZaloPayPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "BusinessOwnerId", "CreatedAt", "Email", "IsActive", "Phone", "Role", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 1, "123 Admin Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8356), "l3acasha@gmail.com", true, "0386001106", 0, "admin", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 2, "456 Business Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8359), "nhocsieuquay131023@gmail.com", true, "0827749293", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 3, "789 User Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8362), "phatqq0@gmail.com", true, "0395042018", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 4, "987 Business Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8365), "test1@gmail.com", true, "0829949293", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 5, "654 User Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8378), "test2@gmail.com", true, "0395992018", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 6, "321 Business Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8380), "test3@gmail.com", true, "0826649293", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 7, "136 User Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8383), "test4@gmail.com", true, "0395042018", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 8, "111 Business Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8386), "test5@gmail.com", true, "0826111123", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 9, "222 User Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8388), "test6@gmail.com", true, "0395888201", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 10, "333 Business Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8391), "test7@gmail.com", true, "0826333444", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 11, "444 User Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8393), "test8@gmail.com", true, "0395001122", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 12, "555 Business Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8396), "test9@gmail.com", true, "0826777888", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 13, "666 User Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8399), "test10@gmail.com", true, "0395123456", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 14, "777 Business Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8401), "test11@gmail.com", true, "0826999000", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 15, "888 User Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8404), "test12@gmail.com", true, "0395666777", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 16, "999 Business Street", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8406), "test13@gmail.com", true, "0826222333", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 17, "101 User Ave", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8409), "test14@gmail.com", true, "0395777123", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 18, "202 Business Ave", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8411), "test15@gmail.com", true, "0826555444", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 19, "303 User Ave", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8414), "test16@gmail.com", true, "0395999888", 2, "user", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" },
                    { 20, "404 Business Ave", null, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8416), "test17@gmail.com", true, "0826111777", 1, "business", "$2a$11$S3CqbavZCGuTIVa7/gxhq.uhpOZzGZtyAv0xSnXnUJ6pNzENH0T86" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Image", "Ingredients", "Steps", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9070), "Món spaghetti sốt thịt kiểu Ý, thơm đậm đà.", "null", "Spaghetti, thịt bò xay, cà chua, hành tây, tỏi, dầu ô liu", "1. Luộc mì.\n2. Phi hành tỏi.\n3. Xào thịt bò.\n4. Thêm sốt cà chua.\n5. Trộn với mì và thưởng thức.", "Spaghetti Bolognese", 3 },
                    { 2, 11, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9072), "Món gỏi cuốn thanh mát, phù hợp mùa nóng.", "null", "Bánh tráng, bún, tôm, thịt heo luộc, rau sống", "1. Luộc tôm thịt.\n2. Chuẩn bị rau sống.\n3. Cuốn cùng bún.\n4. Chấm nước mắm hoặc tương.", "Gỏi Cuốn Tôm Thịt", 3 },
                    { 3, 4, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9074), "Bánh flan mềm mịn với lớp caramel nâu vàng.", "null", "Trứng, sữa tươi, đường, vanilla", "1. Làm caramel.\n2. Đánh hỗn hợp trứng sữa.\n3. Hấp hoặc nướng cách thủy.\n4. Để lạnh và thưởng thức.", "Bánh Flan Caramel", 3 },
                    { 4, 1, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9076), "Trà sữa thơm béo với trân châu mềm dẻo.", "null", "Trà đen, sữa tươi, bột béo, trân châu, đường đen", "1. Nấu trân châu đường đen.\n2. Pha trà.\n3. Khuấy cùng sữa.\n4. Cho trân châu vào ly.", "Trà Sữa Trân Châu Đường Đen", 5 },
                    { 5, 8, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9078), "Cơm chiên thơm lừng với tôm, mực và rau củ.", "null", "Cơm nguội, tôm, mực, trứng, hành tây, đậu Hà Lan", "1. Xào hải sản.\n2. Thêm cơm và trứng.\n3. Nêm nếm.\n4. Xào đều tay cho tơi.", "Cơm Chiên Hải Sản", 5 },
                    { 6, 10, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9079), "Súp bí đỏ mềm mịn, bổ dưỡng.", "null", "Bí đỏ, kem tươi, hành tây, bơ, muối", "1. Hấp bí đỏ.\n2. Xào hành với bơ.\n3. Xay nhuyễn hỗn hợp.\n4. Nấu sôi nhẹ với kem.", "Súp Bí Đỏ", 5 },
                    { 7, 15, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9081), "Món salad ít calo, nhiều protein.", "null", "Ức gà, xà lách, cà chua, dưa leo, sốt dầu giấm", "1. Áp chảo ức gà.\n2. Rửa rau.\n3. Trộn cùng dầu giấm.\n4. Cho gà lên trên.", "Salad Ức Gà Healthy", 7 },
                    { 8, 3, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9083), "Bánh mì chảo nóng hổi với trứng, pate, xúc xích.", "null", "Pate, trứng, xúc xích, bánh mì", "1. Làm nóng chảo.\n2. Chiên trứng.\n3. Làm nóng pate và xúc xích.\n4. Ăn cùng bánh mì.", "Bánh Mì Chảo", 7 },
                    { 9, 12, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9085), "Bánh mềm xốp, phù hợp ăn nhẹ.", "null", "Bột mì, trứng, đường, whipping cream", "1. Đánh bông trứng.\n2. Trộn bột.\n3. Nướng.\n4. Phết kem.", "Bánh Bông Lan Kem Tươi", 7 },
                    { 10, 16, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9087), "Phở bò chuẩn vị truyền thống Việt Nam.", "null", "Xương bò, bánh phở, thịt bò, hành, gừng, gia vị", "1. Ninh xương.\n2. Sơ chế thịt bò.\n3. Trụng bánh phở.\n4. Chan nước dùng nóng.", "Phở Bò Truyền Thống", 9 },
                    { 11, 7, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9089), "Bánh xèo giòn rụm, ăn kèm rau sống và nước mắm.", "null", "Bột bánh xèo, tôm, thịt, giá, hành lá", "1. Pha bột.\n2. Chiên bánh.\n3. Thêm nhân.\n4. Gấp đôi và thưởng thức.", "Bánh Xèo Miền Tây", 9 },
                    { 12, 4, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9091), "Chè trái cây mát lạnh, ngọt béo.", "null", "Sầu riêng, thạch, mít, sữa, nước cốt dừa", "1. Cắt nhỏ trái cây.\n2. Chuẩn bị thạch.\n3. Trộn với sữa.\n4. Thêm đá.", "Chè Thái", 9 },
                    { 13, 1, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9092), "Sinh tố béo mịn, thơm ngon.", "null", "Bơ, sữa đặc, sữa tươi, đá", "1. Cho bơ vào máy xay.\n2. Thêm sữa và đá.\n3. Xay nhuyễn.\n4. Rót ra ly.", "Sinh Tố Bơ", 11 },
                    { 14, 9, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9094), "Cá hấp thơm mùi gừng, ăn rất đưa cơm.", "null", "Cá, gừng, hành lá, nước mắm, tiêu", "1. Sơ chế cá.\n2. Rải gừng hành.\n3. Hấp 15 phút.\n4. Rưới nước mắm.", "Cá Hấp Gừng", 11 },
                    { 15, 13, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9096), "Bánh mì thơm lừng với thịt nướng và đồ chua.", "null", "Thịt heo, bánh mì, đồ chua, pate, rau", "1. Ướp thịt.\n2. Nướng thơm vàng.\n3. Kẹp bánh mì.\n4. Thêm đồ chua và rau.", "Bánh Mì Thịt Nướng", 11 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "AverageRating", "Category", "CloseTime", "CreatedAt", "Description", "ImagePublicId", "IsHidden", "Latitude", "Longitude", "Name", "OpenTime", "OwnerId", "Status" },
                values: new object[,]
                {
                    { 1, "123 Đường Biển, TP. HCM", 0.0, 1, "22:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8619), "Chuyên các món hải sản tươi sống, không gian sang trọng.", null, false, 10.776899999999999, 106.7009, "Nhà Hàng Hải Sản Biển Xanh", "09:00", 2, 1 },
                    { 2, "456 Đường Lê Lợi, TP. HCM", 0.0, 2, "23:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8622), "Quán ăn vặt bình dân, giá rẻ, hợp túi tiền sinh viên.", null, false, 10.7705, 106.69799999999999, "Quán Ăn Vỉa Hè", "15:00", 2, 0 },
                    { 3, "789 Đường Nguyễn Huệ, TP. HCM", 0.0, 4, "21:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8625), "Quán cafe view đẹp, thích hợp để học tập và làm việc.", null, false, 10.7798, 106.69629999999999, "Cafe Góc Phố", "07:00", 4, 1 },
                    { 4, "654 Đường Hòa Bình, TP. HCM", 0.0, 7, "00:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8627), "Chuyên các món nhậu dân dã, không gian thoải mái.", null, false, 10.772500000000001, 106.66849999999999, "Quán Nhậu Bình Dân", "16:00", 4, 1 },
                    { 5, "321 Đường Nguyễn Văn Linh, TP. HCM", 0.0, 3, "21:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8630), "Nhà hàng chay thanh tịnh, chuyên phục vụ các món ăn tốt cho sức khỏe.", null, false, 10.779, 106.7, "Nhà Hàng Chay Tâm An", "08:00", 6, 1 },
                    { 6, "888 Đường Trần Hưng Đạo, TP. HCM", 0.0, 6, "03:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8632), "Bar sôi động với DJ và nhạc EDM cực chất.", null, false, 10.772, 106.699, "Bar The Night", "20:00", 6, 0 },
                    { 7, "12 Đường Trần Phú, TP. HCM", 0.0, 1, "22:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8635), "Nhà hàng Nhật Bản chuyên sushi, sashimi tươi ngon.", null, false, 10.773999999999999, 106.70099999999999, "Nhà Hàng Sushi Tokyo", "10:00", 8, 1 },
                    { 8, "34 Đường Hàng Bông, TP. HCM", 0.0, 4, "18:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8637), "Quán cafe yên tĩnh, phục vụ sáng và trưa.", null, false, 10.779999999999999, 106.69499999999999, "Cafe Sáng Phố", "06:30", 8, 1 },
                    { 9, "56 Đường Lý Thường Kiệt, TP. HCM", 0.0, 5, "21:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8646), "Quán ăn đa dạng món Việt, phục vụ nhanh và giá hợp lý.", null, false, 10.782, 106.702, "Quán Ăn Ngon 99", "09:00", 10, 1 },
                    { 10, "78 Đường Bạch Đằng, TP. HCM", 0.0, 6, "02:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8648), "Bar với không gian ngoài trời, nhạc sống mỗi tối.", null, false, 10.776, 106.6985, "Bar Sunset", "18:00", 10, 0 },
                    { 11, "90 Đường Phan Chu Trinh, TP. HCM", 0.0, 3, "20:30", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8651), "Các món chay thanh tịnh, tốt cho sức khỏe và tâm hồn.", null, false, 10.781000000000001, 106.703, "Nhà Hàng Chay An Lạc", "07:30", 12, 1 },
                    { 12, "23 Đường Lê Lợi, TP. HCM", 0.0, 4, "19:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8653), "Cafe với không gian ngoài trời, view đẹp.", null, false, 10.782999999999999, 106.705, "Cafe Mặt Trời", "06:30", 12, 1 },
                    { 13, "12 Đường Nguyễn Văn Cừ, TP. HCM", 0.0, 1, "22:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8655), "Nhà hàng phục vụ bò né và các món ăn Việt truyền thống.", null, false, 10.7745, 106.6938, "Nhà Hàng Bò Né 3 Ngon", "09:00", 14, 1 },
                    { 14, "45 Đường Phạm Ngũ Lão, TP. HCM", 0.0, 2, "23:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8658), "Quán ăn vặt nổi tiếng, giá sinh viên, đông khách.", null, false, 10.7705, 106.69799999999999, "Quán Ăn Vặt Phố Xinh", "14:00", 14, 0 },
                    { 15, "78 Đường Trần Phú, TP. HCM", 0.0, 1, "22:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8660), "Hải sản tươi sống, không gian sang trọng bên bờ biển.", null, false, 10.779500000000001, 106.7025, "Nhà Hàng Hải Sản Đại Dương", "09:00", 16, 1 },
                    { 16, "90 Đường Trần Phú, TP. HCM", 0.0, 6, "02:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8663), "Bar với nhạc EDM và cocktail đặc sắc.", null, false, 10.7805, 106.703, "Bar Blue Night", "19:00", 16, 0 },
                    { 17, "21 Đường Trần Phú, TP. HCM", 0.0, 4, "21:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8665), "Cafe view biển, phục vụ đồ uống và bánh ngọt.", null, false, 10.781499999999999, 106.70399999999999, "Cafe Gió Biển", "06:30", 18, 1 },
                    { 18, "33 Đường Lê Hồng Phong, TP. HCM", 0.0, 7, "00:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8667), "Quán nhậu dân dã, hải sản tươi ngon, không gian thoải mái.", null, false, 10.782500000000001, 106.705, "Quán Nhậu Biển Xanh", "17:00", 18, 1 },
                    { 19, "12 Đường Nguyễn Trãi, TP. HCM", 0.0, 0, "22:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8670), "Buffet cao cấp với đa dạng món ăn Á – Âu.", null, false, 10.77, 106.6985, "Nhà Hàng Buffet Hoàng Gia", "11:00", 20, 1 },
                    { 20, "34 Đường Trần Nhân Tông, TP. HCM", 0.0, 6, "02:00", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8672), "Bar sôi động với âm nhạc trẻ trung, cocktail đặc sắc.", null, false, 10.772, 106.699, "Bar Red Moon", "19:00", 20, 0 }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Category", "Description", "Image", "IsActive", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 0, "Tôm hùm tươi nướng với bơ tỏi thơm lừng.", "", true, "Tôm Hùm Nướng Bơ Tỏi", 1200000f, 1 },
                    { 2, 0, "Sò huyết xào me chua ngọt hấp dẫn.", "", true, "Sò Huyết Xào Me", 250000f, 1 },
                    { 3, 0, "Cua hoàng đế tươi sống hấp nguyên con giữ trọn vị ngọt.", "", true, "Cua Hoàng Đế Hấp", 3200000f, 1 },
                    { 4, 0, "Ghẹ rang muối đậm đà, thịt chắc và thơm.", "", true, "Ghẹ Rang Muối", 450000f, 1 },
                    { 5, 0, "Mực một nắng nướng muối ớt cay thơm, mềm ngọt.", "", true, "Mực Một Nắng Nướng Muối Ớt", 380000f, 1 },
                    { 6, 0, "Hàu tươi nướng phô mai béo ngậy, hấp dẫn.", "", true, "Hàu Nướng Phô Mai", 160000f, 1 },
                    { 7, 0, "Ốc hương rang tỏi thơm lừng, giòn ngọt.", "", true, "Ốc Hương Rang Tỏi", 290000f, 1 },
                    { 8, 0, "Tôm sú hấp nước dừa thanh ngọt, hương vị tự nhiên.", "", true, "Tôm Sú Hấp Nước Dừa", 420000f, 1 },
                    { 9, 0, "Cá chẽm nướng muối ớt, thịt dai và ít xương.", "", true, "Cá Chẽm Nướng Muối Ớt", 360000f, 1 },
                    { 10, 0, "Cá mú hấp kiểu HongKong với gừng và nước tương đặc trưng.", "", true, "Cá Mú Hấp HongKong", 680000f, 1 },
                    { 11, 0, "Ngao xào bơ tỏi thơm, thịt ngọt mềm.", "", true, "Ngao Xào Bơ Tỏi", 180000f, 1 },
                    { 12, 0, "Sò điệp tươi nướng mỡ hành béo thơm.", "", true, "Sò Điệp Nướng Mỡ Hành", 220000f, 1 },
                    { 13, 0, "Tôm tích cháy tỏi giòn rụm, cực kỳ bắt vị.", "", true, "Tôm Tích Cháy Tỏi", 540000f, 1 },
                    { 14, 0, "Lẩu hải sản đầy đủ tôm, mực, cá, nghêu cùng rau và bún.", "", true, "Lẩu Hải Sản Thập Cẩm", 750000f, 1 },
                    { 15, 0, "Bạch tuộc nướng sa tế cay nồng, dai giòn sần sật.", "", true, "Bạch Tuộc Nướng Sa Tế", 330000f, 1 },
                    { 16, 0, "Bánh tráng trộn bò khô, trứng cút, rau răm, mỡ hành đậm vị.", "", true, "Bánh Tráng Trộn", 25000f, 2 },
                    { 17, 0, "Phô mai que chiên vàng giòn, kéo sợi hấp dẫn.", "", true, "Phô Mai Que", 30000f, 2 },
                    { 18, 0, "Cá viên chiên nóng giòn ăn kèm tương ớt và mayonnaise.", "", true, "Cá Viên Chiên", 20000f, 2 },
                    { 19, 0, "Xúc xích nướng than thơm lừng, sốt đậm đà.", "", true, "Xúc Xích Nướng", 15000f, 2 },
                    { 20, 0, "Bánh tráng cuốn bơ, hành phi, bò khô, trứng cút.", "", true, "Bánh Tráng Cuốn", 20000f, 2 },
                    { 21, 0, "Hồ lô nướng dai giòn, thơm ngon chuẩn vỉa hè.", "", true, "Hồ Lô Nướng", 20000f, 2 },
                    { 22, 0, "Nem chua rán giòn ngoài mềm trong, chấm tương ớt tuyệt hảo.", "", true, "Nem Chua Rán", 30000f, 2 },
                    { 23, 0, "Khoai tây chiên lắc phô mai thơm béo, giòn rụm.", "", true, "Khoai Tây Lắc Phô Mai", 25000f, 2 },
                    { 24, 0, "Bánh mì nướng giòn sốt bơ, trứng cút và chà bông.", "", true, "Bánh Mì Nướng Muối Ớt", 20000f, 2 },
                    { 25, 0, "Trà tắc mát lạnh, vị chua nhẹ giải khát cực tốt.", "", true, "Trà Tắc", 10000f, 2 },
                    { 26, 0, "Trà sữa trân châu ngọt nhẹ, topping dẻo mềm.", "", true, "Trà Sữa Trân Châu", 25000f, 2 },
                    { 27, 0, "Bánh flan béo mềm, caramel thơm ngọt.", "", true, "Bánh Flan Caramel", 15000f, 2 },
                    { 28, 0, "Sữa chua đá mát lạnh, vị chua nhẹ dễ uống.", "", true, "Sữa Chua Đá", 12000f, 2 },
                    { 29, 0, "Gỏi xoài trộn bò khô, đậu phộng và nước mắm chua ngọt.", "", true, "Gỏi Xoài Bò Khô", 30000f, 2 },
                    { 30, 0, "Bột chiên trứng giòn mềm, ăn kèm đu đủ bào.", "", true, "Bột Chiên", 30000f, 2 },
                    { 31, 1, "Cà phê đen pha phin truyền thống, đậm vị và tỉnh táo.", "", true, "Cà Phê Đen Đá", 25000f, 3 },
                    { 32, 1, "Cà phê sữa đá đậm đà, cực kỳ phù hợp để học tập và làm việc.", "", true, "Cà Phê Sữa Đá", 30000f, 3 },
                    { 33, 1, "Bạc xỉu béo ngậy, ít cà phê, dễ uống.", "", true, "Bạc Xỉu", 28000f, 3 },
                    { 34, 1, "Trà đào cam sả mát lạnh, hương thơm dễ chịu.", "", true, "Trà Đào Cam Sả", 35000f, 3 },
                    { 35, 1, "Trà vải ngọt nhẹ, thanh mát, nhiều trái vải.", "", true, "Trà Vải", 35000f, 3 },
                    { 36, 1, "Matcha latte béo nhẹ, vị trà xanh thơm dịu.", "", true, "Matcha Latte", 42000f, 3 },
                    { 37, 1, "Caramel macchiato thơm ngọt, nhẹ nhàng và dễ uống.", "", true, "Caramel Macchiato", 45000f, 3 },
                    { 38, 1, "Sinh tố bơ béo mịn, làm từ bơ tươi nguyên chất.", "", true, "Sinh Tố Bơ", 42000f, 3 },
                    { 39, 1, "Sinh tố dâu chua nhẹ, mát lạnh, phù hợp ngày nóng.", "", true, "Sinh Tố Dâu", 42000f, 3 },
                    { 40, 1, "Nước ép cam tươi nguyên chất, giàu vitamin C.", "", true, "Nước Ép Cam", 38000f, 3 },
                    { 41, 1, "Ly latte nóng thơm nhẹ, tạo bọt mịn.", "", true, "Latte Nóng", 42000f, 3 },
                    { 42, 1, "Cappuccino với lớp bọt sữa dày và hương cà phê đặc trưng.", "", true, "Cappuccino", 45000f, 3 },
                    { 43, 0, "Bánh mousse chocolate mềm mịn, ngọt vừa phải.", "", true, "Bánh Mousse Chocolate", 38000f, 3 },
                    { 44, 0, "Bánh croissant bơ thơm phức, vỏ giòn ruộm.", "", true, "Croissant Bơ", 32000f, 3 },
                    { 45, 0, "Tiramisu nhẹ nhàng vị cà phê, kem béo mịn.", "", true, "Bánh Tiramisu", 42000f, 3 },
                    { 46, 0, "Đậu phộng rang giòn, thơm mùi tỏi – món khai vị quen thuộc.", "", true, "Đậu Phộng Rang Tỏi", 30000f, 4 },
                    { 47, 0, "Khô mực nướng thơm lừng, xé chấm tương ớt chuẩn vị nhậu.", "", true, "Khô Mực Nướng", 120000f, 4 },
                    { 48, 0, "Gà nướng muối ớt cay thơm, da giòn thịt mềm.", "", true, "Gà Nướng Muối Ớt", 180000f, 4 },
                    { 49, 0, "Thịt bò xào rau muống thơm tỏi, món nhậu quen thuộc.", "", true, "Bò Xào Rau Muống", 90000f, 4 },
                    { 50, 0, "Nghêu hấp sả nóng hổi, ngọt nước và thơm mùi sả.", "", true, "Nghêu Hấp Sả", 70000f, 4 },
                    { 51, 0, "Ốc len xào nước cốt dừa béo thơm, đặc sản miền Nam.", "", true, "Ốc Len Xào Dừa", 80000f, 4 },
                    { 52, 0, "Tôm rim mặn ngọt đậm đà, ăn kèm rất đưa bia.", "", true, "Tôm Rim Mặn Ngọt", 90000f, 4 },
                    { 53, 0, "Sườn nướng ngũ vị thơm mềm, đậm vị.", "", true, "Sườn Nướng Ngũ Vị", 150000f, 4 },
                    { 54, 0, "Bạch tuộc nướng sa tế cay nồng, giòn sần sật.", "", true, "Bạch Tuộc Nướng Sa Tế", 120000f, 4 },
                    { 55, 0, "Lẩu Thái với hải sản và nấm, nước dùng chua cay đậm đà.", "", true, "Lẩu Thái Chua Cay", 190000f, 4 },
                    { 56, 0, "Giò heo muối chiên giòn, nạc mỡ hòa quyện hấp dẫn.", "", true, "Giò Heo Muối Chiên", 160000f, 4 },
                    { 57, 0, "Gỏi gà xé phay chua ngọt, giòn và thanh mát.", "", true, "Gỏi Gà Xé Phay", 85000f, 4 },
                    { 58, 0, "Cá kèo kho tộ đậm vị, thơm mùi tiêu và nước màu.", "", true, "Cá Kèo Kho Tộ", 95000f, 4 },
                    { 59, 0, "Ếch xào sả ớt thơm cay, rất đưa cơm và đưa bia.", "", true, "Ếch Xào Sả Ớt", 100000f, 4 },
                    { 60, 1, "Bia Tiger chai/ly, lựa chọn nóng hoặc lạnh.", "", true, "Bia Tiger Nóng/Lạnh", 25000f, 4 },
                    { 61, 0, "Đậu hũ mềm sốt cà chua thanh nhẹ, thích hợp cho bữa trưa.", "", true, "Đậu Hũ Sốt Cà", 45000f, 5 },
                    { 62, 0, "Nấm kho tiêu cay nhẹ, đậm vị, rất đưa cơm.", "", true, "Nấm Kho Tiêu", 50000f, 5 },
                    { 63, 0, "Cơm chiên chay với đậu hũ, cà rốt, đậu Hà Lan và bắp.", "", true, "Cơm Chiên Chay", 55000f, 5 },
                    { 64, 0, "Lẩu nấm thanh đạm, nước dùng ngọt tự nhiên từ rau củ.", "", true, "Lẩu Nấm Chay", 160000f, 5 },
                    { 65, 0, "Bún riêu chay với đậu hũ, chả chay và nước dùng thơm nhẹ.", "", true, "Bún Riêu Chay", 55000f, 5 },
                    { 66, 0, "Gỏi ngó sen giòn, trộn cùng rau củ và đậu phộng rang.", "", true, "Gỏi Ngó Sen Chay", 60000f, 5 },
                    { 67, 0, "Bánh mì chay với nhân nấm, đậu hũ và rau tươi.", "", true, "Bánh Mì Chay", 30000f, 5 },
                    { 68, 0, "Phở chay nước trong, ngọt từ rau củ và quế hồi.", "", true, "Phở Chay", 55000f, 5 },
                    { 69, 0, "Miến xào chay với nấm, cải và đậu hũ chiên.", "", true, "Miến Xào Chay", 50000f, 5 },
                    { 70, 0, "Đậu hũ chiên giòn trộn sả ớt thơm lừng.", "", true, "Đậu Hũ Chiên Sả", 45000f, 5 },
                    { 71, 0, "Rau củ luộc chấm kho quẹt chay đậm đà, thơm mùi tiêu.", "", true, "Rau Củ Luộc Chấm Kho Quẹt Chay", 55000f, 5 },
                    { 72, 0, "Bánh xèo chay giòn rụm, nhân nấm và rau củ.", "", true, "Bánh Xèo Chay", 60000f, 5 },
                    { 73, 0, "Đậu hũ non mềm mịn kết hợp nấm đông cô sốt đậm vị.", "", true, "Đậu Hũ Non Sốt Nấm Đông Cô", 55000f, 5 },
                    { 74, 0, "Chả giò chay giòn rụm bên ngoài, nhân rau củ thơm ngon.", "", true, "Chả Giò Chay", 50000f, 5 },
                    { 75, 0, "Súp chay nhẹ nhàng từ cà rốt, khoai tây, bắp và nấm.", "", true, "Súp Rau Củ Chay", 45000f, 5 }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Description", "DiscountType", "DiscountValue", "EndDate", "Image", "RestaurantId", "StartDate", "TargetType", "Title", "VoucherCode" },
                values: new object[,]
                {
                    { 1, "Khuyến mãi 20% cho tất cả món hải sản trong menu.", 0, 20f, new DateTime(2025, 12, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8878), null, 1, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8878), 2, "Giảm 20% Hải Sản", "ABC20" },
                    { 2, "Khuyến mãi 20.000 cho tất cả món hải sản trong menu.", 1, 20000f, new DateTime(2025, 12, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8887), null, 1, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8887), 2, "Giảm 20k cho Hải Sản", "ABC20k" },
                    { 3, "Giảm 15k cho đơn hàng từ 50k trở lên.", 1, 15000f, new DateTime(2026, 1, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8890), null, 2, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8890), 1, "Combo Sinh Viên", "CBA15k" },
                    { 4, "Áp dụng cho tất cả đồ uống trong menu.", 0, 33.3f, new DateTime(2025, 12, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8893), null, 2, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8892), 0, "Mua 2 Tặng 1", "CBABuy2Get1" },
                    { 5, "Ưu đãi 20% cho tất cả các loại cafe và thức uống tại Cafe Góc Phố. Áp dụng mọi ngày trong tuần.", 0, 20f, new DateTime(2026, 2, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8895), null, 3, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8894), 2, "Giảm 20% toàn bộ menu nước", "CAFE20OFF" },
                    { 6, "Nhập mã để giảm ngay 15,000đ cho đơn hàng có giá trị tối thiểu 50,000đ tại Cafe Góc Phố.", 1, 15000f, new DateTime(2026, 2, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8897), null, 3, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8897), 2, "Giảm 15,000đ cho đơn từ 50,000đ", "CAFE15K" },
                    { 7, "Ưu đãi 10% cho các món nhậu đặc biệt như gỏi bò, chân gà sả tắc, ếch xào sa tế. Áp dụng tất cả các ngày trong tuần.", 0, 10f, new DateTime(2026, 1, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8899), null, 4, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8899), 2, "Giảm 10% các món nhậu đặc biệt", "NHAU10" },
                    { 8, "Nhập mã để giảm ngay 30,000đ áp dụng cho hóa đơn tổng từ 200,000đ trở lên. Không áp dụng kèm ưu đãi khác.", 1, 30000f, new DateTime(2026, 1, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8902), null, 4, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8901), 2, "Giảm 30,000đ cho hóa đơn từ 200,000đ", "NHAU30K" },
                    { 9, "Ưu đãi 15% cho các món chay dinh dưỡng: phở chay, bún Huế chay, rau củ luộc, cơm thập cẩm.", 0, 15f, new DateTime(2026, 2, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8904), null, 5, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8904), 2, "Giảm 15% các món chay tốt cho sức khỏe", "CHAY15" },
                    { 10, "Mã ưu đãi giảm 20,000đ cho hóa đơn tối thiểu 100,000đ tại Nhà Hàng Chay Tâm An. Áp dụng từ thứ 2 đến thứ 6.", 1, 20000f, new DateTime(2026, 2, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8907), null, 5, new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8907), 2, "Giảm 20,000đ cho đơn từ 100,000đ", "TAMAN20" }
                });

            migrationBuilder.InsertData(
                table: "RecipeReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "Rating", "RecipeId", "UserId" },
                values: new object[,]
                {
                    { 1, "Món ăn rất ngon và dễ làm!", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9137), 5, 1, 3 },
                    { 2, "Sốt thịt bò thơm, mì mềm vừa ăn.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9139), 4, 1, 5 },
                    { 3, "Công thức chi tiết, làm xong ngon y như nhà hàng.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9141), 5, 1, 7 },
                    { 4, "Gia vị vừa miệng, mình sẽ thử lại lần nữa.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9142), 4, 1, 9 },
                    { 5, "Rất hài lòng với món spaghetti này!", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9143), 5, 1, 11 },
                    { 6, "Gỏi cuốn tươi mát, ăn cực đã.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9145), 5, 2, 3 },
                    { 7, "Nhân đầy đủ, nước chấm ngon.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9147), 4, 2, 5 },
                    { 8, "Rất dễ làm theo hướng dẫn, thành công 100%.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9148), 5, 2, 7 },
                    { 9, "Thích nhất phần rau sống tươi.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9150), 4, 2, 9 },
                    { 10, "Ăn ngon và healthy, sẽ làm lại nhiều lần.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9151), 5, 2, 11 },
                    { 11, "Bánh flan mềm mịn, caramel ngon tuyệt.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9152), 5, 3, 3 },
                    { 12, "Mình thích vị béo vừa phải, không ngọt quá.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9154), 4, 3, 5 },
                    { 13, "Công thức đơn giản, thành công ngay lần đầu.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9155), 5, 3, 7 },
                    { 14, "Caramel thơm, bánh mịn, ngon.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9157), 4, 3, 9 },
                    { 15, "Rất thích món tráng miệng này!", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9158), 5, 3, 11 },
                    { 16, "Trà sữa thơm ngon, trân châu mềm.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9159), 5, 4, 3 },
                    { 17, "Đường vừa phải, không quá ngọt.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9161), 4, 4, 5 },
                    { 18, "Mình làm theo công thức, cực ngon!", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9162), 5, 4, 7 },
                    { 19, "Thích nhất vị trà đậm, béo vừa.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9164), 4, 4, 9 },
                    { 20, "Trân châu mềm dẻo, uống cực đã.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9165), 5, 4, 11 },
                    { 21, "Cơm chiên hải sản vừa miệng, ngon.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9166), 5, 5, 3 },
                    { 22, "Món chiên thơm, hải sản tươi.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9168), 4, 5, 5 },
                    { 23, "Chiên vừa lửa, cơm tơi xốp.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9169), 5, 5, 7 },
                    { 24, "Món ngon, dễ làm theo hướng dẫn.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9171), 4, 5, 9 },
                    { 25, "Hải sản đầy đủ, ăn rất đã.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9172), 5, 5, 11 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "Rating", "RestaurantId", "UserId" },
                values: new object[,]
                {
                    { 1, "Hải sản rất tươi, nêm nếm vừa miệng, không gian sang trọng.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8949), 5, 1, 3 },
                    { 2, "Tôm hùm ngon, giá hơi cao nhưng đáng tiền.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8951), 4, 1, 5 },
                    { 3, "Phục vụ chu đáo, món ăn lên nhanh, rất hài lòng.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8953), 5, 1, 7 },
                    { 4, "Không gian đẹp, phù hợp đi gia đình, sẽ quay lại.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8954), 4, 1, 9 },
                    { 5, "Mực hấp siêu ngon, cực kỳ tươi!", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8956), 5, 1, 11 },
                    { 6, "Hải sản ngon nhưng đông khách quá, đợi hơi lâu.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8957), 3, 1, 13 },
                    { 7, "Không gian sang, hải sản tươi, nhân viên thân thiện.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8959), 5, 1, 15 },
                    { 8, "Lẩu hải sản ngon, nước dùng ngọt tự nhiên.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8960), 4, 1, 17 },
                    { 9, "Chất lượng tuyệt vời, lần sau sẽ dẫn bạn bè tới.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8962), 5, 1, 19 },
                    { 10, "Bạch tuộc nướng siêu đỉnh, đáng thử!", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8963), 5, 1, 3 },
                    { 11, "Đồ ăn ngon, giá rẻ, hợp sinh viên.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8965), 4, 2, 5 },
                    { 12, "Bánh tráng trộn cực ngon, đậm vị.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8966), 5, 2, 7 },
                    { 13, "Ngon nhưng hơi đông, phục vụ chậm.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8967), 3, 2, 9 },
                    { 14, "Trà đào rẻ và ngon, rất đáng thử.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8969), 4, 2, 11 },
                    { 15, "Xiên nướng vừa miệng, giá ổn.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8970), 4, 2, 13 },
                    { 16, "Đồ ăn lên nhanh, bán đúng giá sinh viên.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8971), 5, 2, 15 },
                    { 17, "Bánh tráng cuốn bơ ngon xuất sắc.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8973), 4, 2, 17 },
                    { 18, "Quán hơi nhỏ nhưng đồ ăn ngon.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8974), 3, 2, 19 },
                    { 19, "Giá mềm, rất đáng để thử.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8975), 4, 2, 3 },
                    { 20, "Ăn vặt chất lượng, nhất định quay lại.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8977), 5, 2, 5 },
                    { 21, "Không gian yên tĩnh, rất thích hợp để làm việc.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8978), 5, 3, 7 },
                    { 22, "Cà phê ngon, giá hợp lý.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8979), 4, 3, 9 },
                    { 23, "Trà sữa machiato ngon bất ngờ.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8981), 5, 3, 11 },
                    { 24, "Không gian đẹp, nhiều góc sống ảo.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8982), 4, 3, 13 },
                    { 25, "Phục vụ lịch sự, nước mang ra nhanh.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8983), 5, 3, 15 },
                    { 26, "Âm nhạc nhẹ nhàng, relaxing.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8985), 4, 3, 17 },
                    { 27, "Cafe trứng rất ngon, đậm vị.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8986), 5, 3, 19 },
                    { 28, "Wifi mạnh, phù hợp làm việc online.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8988), 4, 3, 3 },
                    { 29, "Frappuccino ngon, giá mềm.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8990), 5, 3, 5 },
                    { 30, "View đường Nguyễn Huệ quá đẹp.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8991), 5, 3, 7 },
                    { 31, "Món nhậu ngon, giá bình dân, hợp nhóm bạn.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8992), 4, 4, 9 },
                    { 32, "Ếch xào sa tế xuất sắc, ăn là ghiền.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8994), 5, 4, 11 },
                    { 33, "Quán rộng rãi, phục vụ ổn.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8995), 4, 4, 13 },
                    { 34, "Chân gà sả tắc chuẩn vị.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8996), 5, 4, 15 },
                    { 35, "Đồ ăn ngon nhưng hơi ồn.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8998), 3, 4, 17 },
                    { 36, "Bia lạnh, món lên nhanh.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(8999), 4, 4, 19 },
                    { 37, "Đồ ăn rất hợp khẩu vị, đáng thử.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9000), 5, 4, 3 },
                    { 38, "Giá rẻ, phù hợp tụ tập bạn bè.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9002), 4, 4, 5 },
                    { 39, "Lẩu thái ngon, đậm đà.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9003), 5, 4, 7 },
                    { 40, "Không gian thoải mái, đồ ăn ổn.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9004), 4, 4, 9 },
                    { 41, "Đồ chay thanh đạm, ăn rất nhẹ bụng.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9006), 5, 5, 11 },
                    { 42, "Không gian yên tĩnh, rất thư giãn.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9007), 4, 5, 13 },
                    { 43, "Món cơm thập cẩm rất ngon, giá hợp lý.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9008), 5, 5, 15 },
                    { 44, "Phở chay thơm, nước dùng ngon.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9010), 4, 5, 17 },
                    { 45, "Đồ ăn sạch, cảm giác rất healthy.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9011), 5, 5, 19 },
                    { 46, "Mình rất thích hủ tiếu chay ở đây.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9012), 5, 5, 3 },
                    { 47, "Không gian đẹp, nhẹ nhàng, thanh tịnh.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9014), 4, 5, 5 },
                    { 48, "Rau củ luôn tươi, chế biến ngon.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9015), 5, 5, 7 },
                    { 49, "Giá hợp lý, món đa dạng.", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9016), 4, 5, 9 },
                    { 50, "Ăn chay mà vị vẫn rất hấp dẫn!", new DateTime(2025, 11, 19, 20, 26, 38, 120, DateTimeKind.Utc).AddTicks(9018), 5, 5, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingCustomers_ReservationId",
                table: "BookingCustomers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_CODPayments_PaymentId",
                table: "CODPayments",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_DishPromotions_DishId",
                table: "DishPromotions",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishPromotions_PromotionId",
                table: "DishPromotions",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_RestaurantId",
                table: "Favorites",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DishId",
                table: "OrderItems",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPromotions_PromotionId",
                table: "OrderPromotions",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPromotions_RestaurantId",
                table: "OrderPromotions",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_UserId",
                table: "PasswordResetTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactionLogs_PaymentId",
                table: "PaymentTransactionLogs",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_RestaurantId",
                table: "Promotions",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReviews_RecipeId",
                table: "RecipeReviews",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReviews_UserId",
                table: "RecipeReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserId",
                table: "Recipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_PaymentId",
                table: "Refunds",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId",
                table: "Reservations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationStatusHistories_ReservationId",
                table: "ReservationStatusHistories",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BusinessOwnerId",
                table: "Users",
                column: "BusinessOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VNPayPayments_PaymentId",
                table: "VNPayPayments",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZaloPayPayments_PaymentId",
                table: "ZaloPayPayments",
                column: "PaymentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCustomers");

            migrationBuilder.DropTable(
                name: "CODPayments");

            migrationBuilder.DropTable(
                name: "DishPromotions");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderPromotions");

            migrationBuilder.DropTable(
                name: "PasswordResetTokens");

            migrationBuilder.DropTable(
                name: "PaymentTransactionLogs");

            migrationBuilder.DropTable(
                name: "RecipeReviews");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropTable(
                name: "ReservationStatusHistories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "VNPayPayments");

            migrationBuilder.DropTable(
                name: "ZaloPayPayments");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
