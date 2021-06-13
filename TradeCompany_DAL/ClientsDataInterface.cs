using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_DAL
{
    public interface ClientsDataInterface
    {
        public List<ClientDTO> GetClients();

        public List<ClientDTO> GetClientsByParams(int? person, int? sale, DateTime? minData, DateTime? maxData);

        public ClientDTO GetClientByID(int id);

        public ClientDTO GetLastClient();

        public void AddClient(ClientDTO client);

        public void DeleteClientByID(int id);

        public void UpdateClientByID(ClientDTO client);

        public List<ClientDTO> GetClientsByName(string partOfTheName);

        public List<WishDTO> GetWishesListByClientID(int id);

        public void DeleteWishListByID(int id);

        public void AddWishByID(int id, int productsID);

        public List<ClientsStatisticsDTO> GetClientsStatistics();

        public List<ClientsStatisticsDTO> GetClientsStatisticsByParams(int? FromCount, int? OrdersCount, byte? Type,
                    DateTime? FromLastOrderDate, DateTime? UntilLastOrderDate, DateTime? MinDate,
                    DateTime? MaxDate, float? FromAmount, float? ToAmount);

        public List<ClientsStatisticsDTO> GetClientsStatisticsByProductGroups(int? ID, DateTime? FromDate, DateTime? UntilDate,
                    DateTime? FromLastOrder, DateTime? UntilLastOrder, byte? Type,
                    float? FromAmount, float? ToAmount, int? FromOrdersCount, int? ToOrdersCount);
        

    }

}
