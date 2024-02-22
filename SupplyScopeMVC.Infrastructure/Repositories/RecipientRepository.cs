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
        private readonly Context _contex;

        public RecipientRepository(Context context)
        {
            _contex = context;
        }

        public IQueryable<Recipient> GetAllActiveRecipients()
        {
            return _contex.Recipients.Where(p => p.IsActive);
        }

        public Recipient GetRecipient(int recipientId)
        {
            return _contex.Recipients.FirstOrDefault(p => p.Id == recipientId);
        }
    }
}
