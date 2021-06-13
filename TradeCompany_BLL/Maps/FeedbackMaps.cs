using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Models;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL.Maps
{
    class FeedbackMaps
    {
        public FeedBacksDTO MapsFeedbackModelToFeedbackDTO(FeedbackModel feedback)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FeedbackModel, FeedBacksDTO>());

            Mapper mapper = new Mapper(config);
            FeedBacksDTO feedbackDTO;
            feedbackDTO = mapper.Map<FeedBacksDTO>(feedback);

            return feedbackDTO;
        }
    }
}
