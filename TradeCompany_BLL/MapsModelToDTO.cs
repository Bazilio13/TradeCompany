using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL
{
    public class MapsModelToDTO
    {

        public ClientDTO MapClientModelToClientDTO(ClientModel clientModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientModel, ClientDTO>());
            Mapper mapper = new Mapper(config);
            ClientDTO clientDTO = mapper.Map<ClientDTO>(clientModel);
            return clientDTO;
        }

        public List<WishDTO> MapWishListModelToWishListDTO(List<WishModel> wishListModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WishModel, WishDTO>());
            Mapper mapper = new Mapper(config);
            List<WishDTO> wishListDTO = mapper.Map<List<WishDTO>>(wishListModel);
            return wishListDTO;
        }





    }

}
