using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Domain.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int RecipientId { get; set; }
        public virtual Recipient Recipient { get; set; }
    }
}
