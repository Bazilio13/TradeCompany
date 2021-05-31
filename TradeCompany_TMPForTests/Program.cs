using System;
using System.Collections.Generic;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_TMPForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ClientDTO> clients = new List<ClientDTO>();
            ClientsData cd = new ClientsData();
            clients = cd.GetClients();
        }
    }
}
