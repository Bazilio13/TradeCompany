using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Maps;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;

namespace TradeCompany_BLL.DataAccess
{
    public class PotentialClientsDataAccess
    {
        private PotentialClientDataInterface _data;

        private PotentialClientMaps _map = new PotentialClientMaps();

        public PotentialClientsDataAccess()
        {
            _data = new PotentialClientsData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");

        }

        public PotentialClientsDataAccess(PotentialClientDataInterface data)
        {
            _data = data;
        }

        public List<PotentialClientModel> GetPotentialClientsByProductsIDs(List<int> ids, string clientSearch = null)
        {
            DateTime clientsActivityStart = DateTime.Now;
            clientsActivityStart = clientsActivityStart.AddMonths(-3);
            return _map.MapPotentialClientDTOsToPotentialClientModels(_data.GetPotentialClientDTOs(ids, clientsActivityStart, 2, clientSearch));
        }
        public List<PotentialClientModel> GetPotentialClientsByProductsIDs(int id)
        {
            List<int> ids = new List<int> { id };
            return GetPotentialClientsByProductsIDs(ids);
        }
    }
}
