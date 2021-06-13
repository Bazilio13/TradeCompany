using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany_DAL.DTOs;

namespace TradeCompany_DAL
{
    public interface FeedbacksDataInterface
    {
        public void AddFeedback(FeedBacksDTO feedBacksDTO);

        public void DeleteFeedbackById(int id);

        public void DeleteFeedbackByOrderID(int orderID);

        public void DeleteAllFeedbacksByClientId(int clientID);

        public FeedBacksDTO GetFeedbackByID(int feedbackId);

        public void UpdateFeedBackById(FeedBacksDTO feedBacksDTO);

        public List<FeedBacksDTO> GetFeedbackByClientID(int id);

        public List<FeedBacksDTO> GetFeedbackByOrderID(int orderId);
    }
}
