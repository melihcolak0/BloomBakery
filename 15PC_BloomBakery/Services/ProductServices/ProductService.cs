using _15PC_BloomBakery.Context;
using _15PC_BloomBakery.DTOs.AboutDTOs;
using _15PC_BloomBakery.DTOs.ProductDTOs;
using _15PC_BloomBakery.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _15PC_BloomBakery.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<GetProductDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                                .Include(p => p.Category)
                                .FirstOrDefaultAsync(p => p.ProductId == id);

            return _mapper.Map<GetProductDto>(product);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            // Auto Mapper Kullanarak İlişkili Veri Çekme ve Dönüştürme

            var products = await _context.Products
                                        .Include(p => p.Category)
                                        .OrderBy(x => x.ProductId)
                                        .ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(products);


            // Auto Mapper Kullanmadan İlişkili Veri Çekme ve Dönüştürme

            //var products = await _context.Products
            //                            .Include(p => p.Category)
            //                            .ToListAsync();

            //var result = products.Select(p => new ResultProductDto
            //{
            //    ProductId = p.ProductId,
            //    ProductName = p.ProductName,
            //    UnitPrice = p.UnitPrice,
            //    Stock = p.Stock,
            //    ImageUrl = p.ImageUrl,
            //    CategoryId = p.CategoryId,
            //    CategoryName = p.Category != null ? p.Category.CategoryName : "Kategori Yok"
            //}).ToList();

            //return result;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = await _context.Products.FindAsync(updateProductDto.ProductId);
            if (product == null) return;

            _mapper.Map(updateProductDto, product);
            await _context.SaveChangesAsync();
        }
    }
}
