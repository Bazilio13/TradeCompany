using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany_DAL.DTOs
{
    public class WishDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is WishDTO dTO &&
                   ID == dTO.ID &&
                   Name == dTO.Name;
        }
    }

}
