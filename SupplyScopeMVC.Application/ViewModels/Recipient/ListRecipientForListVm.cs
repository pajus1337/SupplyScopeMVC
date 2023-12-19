using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application.ViewModels.Recipient
{
    public class ListRecipientForListVm
    {
        public List<RecipientForListVm> Recipients { get; set; }
        public int Count { get; set; }
    }
}
