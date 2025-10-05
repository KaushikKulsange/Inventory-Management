using AutoMapper;
using Inventory_Management_System.DomainModel.DTO;
using Inventory_Management_System.DomainModel.Models;

namespace Inventory_Management_System.BusinessLogic.Mappings
{
    public class Mapclass : Profile
    {
        public Mapclass()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<AddUpdateProductDTO, Product>();
        }
    }
}
