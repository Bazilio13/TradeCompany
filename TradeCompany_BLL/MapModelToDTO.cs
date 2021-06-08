using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL
{
    class MapModelToDTO
    {
        public ProductDTO MapProductModelToProductDTO(ProductModel productModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductModel, ProductDTO>());
            Mapper mapper = new Mapper(config);
            ProductDTO productDTO = mapper.Map<ProductDTO>(productModel);
            return productDTO;
        }

        public ProductGroupDTO MapProductGroupModelToProductGroupDTO(ProductGroupModel productGroupModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductGroupModel, ProductGroupDTO>());
            Mapper mapper = new Mapper(config);
            ProductGroupDTO productGroupDTO = mapper.Map<ProductGroupDTO>(productGroupModel);
            return productGroupDTO;
        }
    }
}
