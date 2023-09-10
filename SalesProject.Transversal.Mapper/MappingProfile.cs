using AutoMapper;
using SalesProject.Application.DTO.buy.buy;
using SalesProject.Application.DTO.buy.buy_detail;
using SalesProject.Application.DTO.buy_order.buy_order;
using SalesProject.Application.DTO.buy_order.buy_order_detail;
using SalesProject.Application.DTO.buy_return.buy_return;
using SalesProject.Application.DTO.buy_return.buy_return_detail;
using SalesProject.Application.DTO.cellar;
using SalesProject.Application.DTO.cellar_transfer.cellar_transfer;
using SalesProject.Application.DTO.cellar_transfer.cellar_transfer_det;
using SalesProject.Application.DTO.customer.category;
using SalesProject.Application.DTO.customer.customer;
using SalesProject.Application.DTO.document.document;
using SalesProject.Application.DTO.document.documentType;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.DTO.product.brand;
using SalesProject.Application.DTO.product.category;
using SalesProject.Application.DTO.product.measure;
using SalesProject.Application.DTO.product.min_max;
using SalesProject.Application.DTO.product.product;
using SalesProject.Application.DTO.sale.sale;
using SalesProject.Application.DTO.sale.sale_detail;
using SalesProject.Application.DTO.sale_order.sale_order;
using SalesProject.Application.DTO.sale_order.sale_order_detail;
using SalesProject.Application.DTO.sale_price_category;
using SalesProject.Application.DTO.sale_return.sale_return;
using SalesProject.Application.DTO.sale_return.sale_return_det;
using SalesProject.Application.DTO.supplier.category;
using SalesProject.Application.DTO.supplier.supplier;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Entity.Models.pagination;

namespace SalesProject.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();
            CreateMap<PaginationParametersDTO, PaginationParameters>();

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
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();

            CreateMap<ProductCat, ProductCatDTO>();
            CreateMap<ProductCatCreateDTO, ProductCat>();
            CreateMap<ProductCatUpdateDTO, ProductCat>();

            CreateMap<Brand, ProductBrandDTO>();
            CreateMap<ProductBrandCreateDTO, Brand>();
            CreateMap<ProductBrandUpdateDTO, Brand>();

            CreateMap<Measure, ProductMeasureDTO>();
            CreateMap<ProductMeasureCreateDTO, Measure>();
            CreateMap<ProductMeasureUpdateDTO, Measure>();

            CreateMap<MinMaxProd, MinMaxProductUnitsDTO>();
            CreateMap<MinMaxProductUnitsCreateDTO, MinMaxProd>();
            CreateMap<MinMaxProductUnitsUpdateDTO, MinMaxProd>();

            CreateMap<DocumentType, DocumentTypeDTO>();
            CreateMap<DocumentTypeCreateDTO, DocumentType>();
            CreateMap<DocumentTypeUpdateDTO, DocumentType>();

            CreateMap<Document, DocumentDTO>();
            CreateMap<DocumentCreateDTO, Document>();
            CreateMap<DocumentUpdateDTO, Document>();

            CreateMap<CategorySalePrice, SalePriceCatDTO>();
            CreateMap<SalePriceCatCreateDTO, CategorySalePrice>();
            CreateMap<SalePriceCatUpdateDTO, CategorySalePrice>();

            CreateMap<BuyOrder, BuyOrderDTO>();
            CreateMap<BuyOrderCreateDTO, BuyOrder>();
            CreateMap<BuyOrderUpdateDTO, BuyOrder>();

            CreateMap<BuyOrderDet, BuyOrderDetDTO>();
            CreateMap<BuyOrderDetCreateDTO, BuyOrderDet>();
            CreateMap<BuyOrderDetUpdateDTO, BuyOrderDet>();

            CreateMap<Buy, BuyDTO>();
            CreateMap<BuyCreateDTO, Buy>();
            CreateMap<BuyUpdateDTO, Buy>();

            CreateMap<BuyDet, BuyDetDTO>();
            CreateMap<BuyDetCreateDTO, BuyDet>();
            CreateMap<BuyDetUpdateDTO, BuyDet>();

            CreateMap<BuyOrder, Buy>();
            CreateMap<BuyOrderDet, BuyDet>();

            CreateMap<SaleOrder, SaleOrderDTO>();
            CreateMap<SaleOrderCreateDTO, SaleOrder>();
            CreateMap<SaleOrderUpdateDTO, SaleOrder>();

            CreateMap<SaleOrderDet, SaleOrderDetDTO>();
            CreateMap<SaleOrderDetCreateDTO, SaleOrderDet>();
            CreateMap<SaleOrderDetUpdateDTO, SaleOrderDet>();

            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleCreateDTO, Sale>();
            CreateMap<SaleUpdateDTO, Sale>();

            CreateMap<SaleDet, SaleDetDTO>();
            CreateMap<SaleDetCreateDTO, SaleDet>();
            CreateMap<SaleDetUpdateDTO, SaleDet>();

            CreateMap<SaleOrder, Sale>();
            CreateMap<SaleOrderDet, SaleDet>();

            CreateMap<BuyReturn, BuyReturnDTO>();
            CreateMap<BuyReturnCreateDTO, BuyReturn>();
            CreateMap<BuyReturnUpdateDTO, BuyReturn>();

            CreateMap<BuyReturnDet, BuyReturnDetDTO>();
            CreateMap<BuyReturnDetCreateDTO, BuyReturnDet>();
            CreateMap<BuyReturnDetUpdateDTO, BuyReturnDet>();

            CreateMap<SaleReturn, SaleReturnDTO>();
            CreateMap<SaleReturnCreateDTO, SaleReturn>();
            CreateMap<SaleReturnUpdateDTO, SaleReturn>();

            CreateMap<SaleReturnDet, SaleReturnDetDTO>();
            CreateMap<SaleReturnDetCreateDTO, SaleReturnDet>();
            CreateMap<SaleReturnDetUpdateDTO, SaleReturnDet>();

            CreateMap<CellarTransfer, CellarTransferDTO>();
            CreateMap<CellarTransferCreateDTO, CellarTransfer>();
            CreateMap<CellarTransferUpdateDTO, CellarTransfer>();

            CreateMap<CellarTransferDet, CellarTransferDetDTO>();
            CreateMap<CellarTransferDetCreateDTO, CellarTransferDet>();
            CreateMap<CellarTransferDetUpdateDTO, CellarTransferDet>();

        }
    }
}