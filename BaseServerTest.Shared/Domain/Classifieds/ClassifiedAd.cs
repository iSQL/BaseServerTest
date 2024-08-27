using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServerTest.Shared.Domain.Classifieds
{
    public class ClassifiedAd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public DateTime DatePosted { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }

        // Navigation Properties
        public ClassifiedUser User { get; set; }
        public ICollection<ClassifiedMessage> Messages { get; set; }
    }
}
