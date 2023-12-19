using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Domain.Model
{
    public class Recipient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string  CEOFirstName { get; set; }
        public string CEOLastName { get; set; }
        public byte[] LogoPic { get; set; }

        public RecipientContactInformation RecipientContactInformation { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
