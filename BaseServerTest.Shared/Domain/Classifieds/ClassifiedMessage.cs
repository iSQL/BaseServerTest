using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServerTest.Shared.Domain.Classifieds
{
    public class ClassifiedMessage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int ClassifiedAdId { get; set; }

        // Navigation Properties
        public ClassifiedUser Sender { get; set; }
        public ClassifiedUser Receiver { get; set; }
        public ClassifiedAd ClassifiedAd { get; set; }
    }
}
