using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin;

namespace BeerDrinkin.Core.ViewModels
{
    public class SendFeedbackViewModel
    {
        public SendFeedbackViewModel()
        {
        }

        public int UserInterfaceRating { get; set; }

        public int BeerSelectionRating { get; set; }

        public string Feedback { get; set; }

        public void SendFeedback()
        {
            Insights.Track("Feedback Provided", new Dictionary<string, string>
                {
                    { "User", ClientManager.Instance.BeerDrinkinClient.CurrentAccount.Email },
                    { "UI Rating", UserInterfaceRating.ToString() },
                    { "Beer Selection", BeerSelectionRating.ToString() },
                    { "Comment", Feedback }
                });

            Acr.UserDialogs.UserDialogs.Instance.ShowSuccess("Feedback sent!");
        }
    }
}

