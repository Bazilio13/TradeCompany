using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class SupplyDTO
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Comment { get; set; }
        public List<SupplyListDTO> SupplyLists { get; set; } = new List<SupplyListDTO>();

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is SupplyDTO dTO && SupplyLists.Count == dTO.SupplyLists.Count)
            {
                for (int i = 0; i < SupplyLists.Count; i++)
                {
                    if (SupplyLists[i] is null || dTO.SupplyLists[i] is null)
                    {
                        result = SupplyLists[i] == dTO.SupplyLists[i];
                    }
                    else if (!SupplyLists[i].Equals(dTO.SupplyLists[i]))
                    {
                        result = false;
                    }
                }
                return result &&
                   ID == dTO.ID &&
                   DateTime == dTO.DateTime &&
                   Comment == dTO.Comment;
            }
            return false;
        }
    }
}
