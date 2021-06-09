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
            ClientsData data = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            return clientDTO;
        }

        public List<WishDTO> MapWishListModelToWishListDTO(List<WishModel> wishListModel)
        {
            ClientsData data = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");

            var config = new MapperConfiguration(cfg => cfg.CreateMap<WishModel, WishDTO>());
            Mapper mapper = new Mapper(config);
            List<WishDTO> wishListDTO = mapper.Map<List<WishDTO>>(wishListModel);
            return wishListDTO;
        }

        public void MapAddressesListModelToAddressesListDTO(List<String> addressesList, int id)
        {
            AddressesData data = new AddressesData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            foreach (String address in addressesList)
            {
                data.AddAddress(id, address);
            }
        }

    }

}
