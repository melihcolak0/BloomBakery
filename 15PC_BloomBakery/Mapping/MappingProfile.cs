using _15PC_BloomBakery.DTOs.AboutDTOs;
using _15PC_BloomBakery.DTOs.CategoryDTOs;
using _15PC_BloomBakery.DTOs.ChefDTOs;
using _15PC_BloomBakery.DTOs.OrderDTOs;
using _15PC_BloomBakery.DTOs.ProductDTOs;
using _15PC_BloomBakery.DTOs.ServiceDTOs;
using _15PC_BloomBakery.DTOs.SliderDTOs;
using _15PC_BloomBakery.DTOs.TestimonialDTOs;
using _15PC_BloomBakery.Entities;
using AutoMapper;

namespace _15PC_BloomBakery.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();

            CreateMap<Chef, ResultChefDto>().ReverseMap();
            CreateMap<Chef, CreateChefDto>().ReverseMap();
            CreateMap<Chef, UpdateChefDto>().ReverseMap();
            CreateMap<Chef, GetChefDto>().ReverseMap();

            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<Service, GetServiceDto>().ReverseMap();

            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, GetSliderDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();

            //CreateMap<Product, ResultProductDto>().ReverseMap(); // İlişkili veri olduğu için bu şekilde kullanmadık
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            //CreateMap<Product, GetProductDto>().ReverseMap(); // İlişkili veri olduğu için bu şekilde kullanmadık
            CreateMap<Product, GetProductDto>()
    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap(); // İlişkili veri olduğu için bu şekilde kullandık
            CreateMap<Product, ResultProductDto>()
   .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();// İlişkili veri olduğu için bu şekilde kullandık

            CreateMap<Order, ResultOrderDto>()
   .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName)).ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();           
            CreateMap<Order, GetOrderDto>()
   .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName)).ReverseMap();
        }
    }
}
