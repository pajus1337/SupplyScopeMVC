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

        public int AddRecipient(Recipient recipient)
        {
            _contex.Recipients.Add(recipient);
            _contex.SaveChanges();
            return recipient.Id;
        }

        public IQueryable<Recipient> GetAllActiveRecipients()
        {
            return _contex.Recipients.Where(p => p.IsActive);
        }

        public Recipient GetRecipient(int recipientId)
        {
            return _contex.Recipients.FirstOrDefault(p => p.Id == recipientId);
        }

        public void UpdateRecipient(Recipient recipient)
        {
            _contex.Attach(recipient);
            _contex.Entry(recipient).Property("Name").IsModified = true;
            _contex.SaveChanges();
        }
    }
}
