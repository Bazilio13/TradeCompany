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
        public void MapClientModelToClientDTO(ClientModel clientModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientModel, ClientDTO>());
            Mapper mapper = new Mapper(config);
            ClientDTO clientDTO = mapper.Map<ClientDTO>(clientModel);
            ClientsData data = new ClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
            if(clientDTO.ID == -1)
            {
                data.AddClient(clientDTO);
            }
            else
            {
                data.UpdateClientByID(clientDTO);
            }
         
        }

    }
}
