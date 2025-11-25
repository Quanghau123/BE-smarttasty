using AutoMapper;
using backend.Domain.Models;
using backend.Application.DTOs.Promotion;
using backend.Application.DTOs.Restaurant;
using backend.Application.DTOs.Recipe;
using backend.Application.DTOs.KafkaPayload;
using backend.Application.DTOs.Dish;
using backend.Application.DTOs.DishPromotion;
using backend.Application.DTOs.OrderPromotion;
using backend.Application.DTOs.Payment;
using backend.Application.DTOs.Order;
using backend.Application.DTOs.User;
using backend.Domain.Enums;
using backend.Domain.Models.Requests.Restaurant;
using backend.Domain.Models.Requests.Promotion;
using backend.Domain.Models.Requests.Notifications;
using backend.Domain.Models.Requests.DishPromotion;

namespace backend.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantSimpleDto>();
            CreateMap<User, StaffDto>()
                .ForMember(dest => dest.BusinessOwnerName,
                opt => opt.MapFrom(src => src.BusinessOwner != null ? src.BusinessOwner.UserName : null))
                .ForMember(dest => dest.Restaurants,
                opt => opt.MapFrom(src => src.Restaurants));
            CreateMap<CreateRestaurantRequest, Restaurant>()
                .ForMember(dest => dest.ImagePublicId, opt => opt.Ignore())
                .ForMember(dest => dest.OwnerId, opt => opt.Ignore());
            CreateMap<UpdateRestaurantRequest, Restaurant>()
                .ForMember(dest => dest.ImagePublicId, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OwnerId, opt => opt.Ignore());
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(dest => dest.OwnerEmail, opt => opt.MapFrom(src => src.Owner.Email))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.Owner.UserName))
                .ForMember(dest => dest.OwnerPhone, opt => opt.MapFrom(src => src.Owner.Phone));

            CreateMap<Dish, DishDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()));
            CreateMap<Restaurant, RestaurantForDishDto>();

            CreateMap<CreatePromotionRequest, Promotion>();
            CreateMap<Promotion, PromotionDto>();
            CreateMap<Restaurant, RestaurantForPromotionDto>();

            CreateMap<Recipe, RecipeDto>()
             .ForMember(recipe => recipe.Category, opt => opt.MapFrom(src => src.Category.ToString()));
            CreateMap<User, UserForRecipeDto>();

            CreateMap<SendNotificationRequest, SendNotificationPayload>()
      .ForMember(dest => dest.TargetRoles, opt => opt.MapFrom(src =>
          src.TargetRoles == null ? null :
          src.TargetRoles
            .Where(r => Enum.IsDefined(typeof(UserRole), r)) // lọc các giá trị hợp lệ
            .Select(r => (UserRole)Enum.Parse(typeof(UserRole), r, true))
            .ToList()
      ))
            .ForMember(dest => dest.Type, opt => opt.Ignore())
            .ForMember(dest => dest.Priority, opt => opt.Ignore())
            .ForMember(dest => dest.RequestedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.RequestedByRole, opt => opt.Ignore());

            // ====== DishPromotion Mapping ======
            CreateMap<CreateDishPromotionRequest, DishPromotion>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<DishPromotion, DishPromotionDto>()
                .ForMember(dest => dest.RestaurantId, opt => opt.MapFrom(src => src.Dish.RestaurantId))
                .ForMember(dest => dest.DishName, opt => opt.MapFrom(src => src.Dish.Name))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Dish.Image))
                .ForMember(dest => dest.PromotionTitle, opt => opt.MapFrom(src => src.Promotion.Title))
                .ForMember(dest => dest.DiscountType, opt => opt.MapFrom(src => src.Promotion.DiscountType))
                .ForMember(dest => dest.DiscountValue, opt => opt.MapFrom(src => src.Promotion.DiscountValue))
                .ForMember(dest => dest.OriginalPrice, opt => opt.MapFrom(src => src.OriginalPrice ?? 0))
                .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.AppliedPrice ?? 0));

            // ====== OrderPromotion Mapping ======
            CreateMap<OrderPromotion, OrderPromotionDto>()
           .ForMember(dest => dest.PromotionTitle, opt => opt.MapFrom(src => src.Promotion.Title))
           .ForMember(dest => dest.DiscountType, opt => opt.MapFrom(src => src.Promotion.DiscountType))
           .ForMember(dest => dest.DiscountValue, opt => opt.MapFrom(src => src.Promotion.DiscountValue))
           .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant != null ? src.Restaurant.Name : null));

            CreateMap<Payment, PaymentDto>();
            CreateMap<CODPayment, CODPaymentDto>();
            CreateMap<Payment, InfoPaymentDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Items,
                            opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.Restaurant,
                        opt => opt.MapFrom(src => src.Restaurant));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.OriginalPrice,
                        opt => opt.MapFrom(src => src.OriginalPrice))
                .ForMember(dest => dest.DishName,
                        opt => opt.MapFrom(src => src.Dish != null ? src.Dish.Name : null))
                .ForMember(dest => dest.Image,
                        opt => opt.MapFrom(src => src.Dish != null ? src.Dish.Image : string.Empty));
        }
    }
}
