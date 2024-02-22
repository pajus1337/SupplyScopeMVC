using SupplyScopeMVC.Domain.Interfaces;
using SupplyScopeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Infrastructure.Repositories
{
    public class RecipientRepository : IRecipientRepository
    {
        public IQueryable<Recipient> GetAllActiveRecipients()
        {
            throw new NotImplementedException();
        }

        public Recipient GetRecipient(int recipientId)
        {
            throw new NotImplementedException();
        }
    }
}
