using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServerTest.Shared.Domain.Classifieds
{
    public class ClassifiedUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateRegistered { get; set; }

        // Navigation Properties
        public ICollection<ClassifiedAd> ClassifiedAds { get; set; }
        public ICollection<ClassifiedMessage> SentMessages { get; set; }
        public ICollection<ClassifiedMessage> ReceivedMessages { get; set; }
    }

}
