using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_BLL.Maps;
using TradeCompany_BLL.Models;
using TradeCompany_DAL;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_BLL
{
    public class FeedbacksDataAccess
{
        private FeedBacksData _feetbacksData = new FeedBacksData(@"Persist Security Info=False;User ID=DevEd;Password=qqq!11;Initial Catalog=Sandbox.Test;Server=80.78.240.16");
        private MapsDTOtoModel _map = new MapsDTOtoModel();
        private FeedbackMaps _feedbackMaps = new FeedbackMaps();

        public List<FeedbackModel> GetFeedbacksByClientID(int id)
        {
            List<FeedBacksDTO> feedbackDTOs;
            feedbackDTOs = _feetbacksData.GetFeedbackByClientID(id);
            List<FeedbackModel> feedbackModels = _map.MapFeedbackDTOToFeedbackModel(feedbackDTOs);
            return feedbackModels;
        }
        public void AddFeedbackByOrderId(int id, FeedbackModel feedback)
        {
            FeedBacksDTO feedBacksDTO = _feedbackMaps.MapsFeedbackModelToFeedbackDTO(feedback);
            _feetbacksData.AddFeedback(feedBacksDTO);
        }

    }
}
