using SupplyScopeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Domain.Interfaces
{
    public interface IRecipientRepository
    {
        IQueryable<Recipient> GetAllActiveRecipients();
        Recipient GetRecipient(int recipientId);
        int AddRecipient(Recipient recipient);
        void UpdateRecipient(Recipient recipient);
        void DeleteRecipient(int recipientId);
    }
}
