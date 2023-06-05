using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Note { get; set; } = string.Empty;

        public double Fee { get; set; }

        public DateTime PaymentDate { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();

       public Client? Client { get; set; }

    }
}
