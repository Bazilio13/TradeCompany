using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_DAL
{
    public interface PotentialClientDataInterface
    {
        public List<PotentialClientDTO> GetPotentialClientDTOs(List<int> idsList, DateTime dateTime, int groupMatchNumber, string clientSearch = null);

    }
}
