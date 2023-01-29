using AutoMapper;
using SalesProject.Domain.Entity;
using SalesProject.Application.DTO;
using SalesProject.Domain.Entity.Models;
using SalesProject.Application.DTO.cellar;
using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.customer.category;
using SalesProject.Application.DTO.supplier.category;
using SalesProject.Application.DTO.supplier.supplier;
using SalesProject.Application.DTO.product.product;
using SalesProject.Application.DTO.product.brand;
using SalesProject.Application.DTO.product.measure;
using SalesProject.Application.DTO.product.category;
using SalesProject.Application.DTO.document.documentType;
using SalesProject.Application.DTO.document.document;

namespace SalesProject.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();

            CreateMap<CustomerCat, CustomerCatDTO>();
            CreateMap<CustomerCatCreateDTO, CustomerCat>();
            CreateMap<CustomerCatUpdateDTO, CustomerCat>();

            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierCreateDTO, Supplier>();
            CreateMap<SupplierUpdateDTO, Supplier>();

            CreateMap<SupplierCat, SupplierCatDTO>();
            CreateMap<SupplierCatCreateDTO, SupplierCat>();
            CreateMap<SupplierCatUpdateDTO, SupplierCat>();

            CreateMap<Cellar, CellarDTO>();
            CreateMap<CellarCreateDTO, Cellar>();
            CreateMap<CellarUpdateDTO, Cellar>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductCreateDTO, Measure>();
            CreateMap<ProductUpdateDTO, Product>();

            CreateMap<ProductCat, ProductCatDTO>();
            CreateMap<ProductCatCreateDTO, ProductCat>();
            CreateMap<ProductCatUpdateDTO, ProductCat>();

            CreateMap<Brand, ProductBrandDTO>();
            CreateMap<ProductBrandCreateDTO, Product>();
            CreateMap<ProductBrandUpdateDTO, Product>();

            CreateMap<Measure, ProductMeasureDTO>();
            CreateMap<ProductMeasureCreateDTO, Measure>();
            CreateMap<ProductMeasureUpdateDTO, Measure>();

            CreateMap<DocumentType, DocumentTypeDTO>();
            CreateMap<DocumentTypeCreateDTO, DocumentType>();
            CreateMap<DocumentTypeUpdateDTO, DocumentType>();

            CreateMap<Document, DocumentDTO>();
            CreateMap<DocumentCreateDTO, Document>();
            CreateMap<DocumentUpdateDTO, Document>();


        }
    }
}