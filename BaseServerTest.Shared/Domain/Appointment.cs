using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServerTest.Shared.Domain
{
    public class Appointment
    {
        public Appointment()
        {
            
        }
        public int AppointmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Caption { get; set; }
        public int Label { get; set; }
        public int Status { get; set; }
        public bool AllDay { get; set; }

        private static string ToString(DateTime dateTime)
        {
            return dateTime.ToString(CultureInfo.InvariantCulture);
        }
    }
}
