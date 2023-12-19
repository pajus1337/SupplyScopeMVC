using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application.ViewModels.Recipient
{
    public class RecipientDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CEOFullName { get; set; }
        public string FirstLineOfContactInformation { get; set; }
        public List<AddressForListVm> Addresses { get; set; }
        public List<ContactDetailListVm> Emails { get; set; }
        public List<ContactDetailListVm> PhoneNumbers { get; set; }
    }
}
