using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServerTest.Shared.Domain.Classifieds
{
    public class ClassifiedAd
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        public DateTime DatePosted { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }

        // Navigation Properties
        public ClassifiedUser User { get; set; }
        public ICollection<ClassifiedMessage> Messages { get; set; }
    }

}
