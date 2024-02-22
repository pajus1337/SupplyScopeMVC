using SupplyScopeMVC.Application.Interfaces;
using SupplyScopeMVC.Application.ViewModels.Recipient;
using SupplyScopeMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application.Services
{
    public class RecipientService : IRecipientService
    {
        private readonly IRecipientRepository _recipientRepository;
        public int AddRecipient(NewRecipientVm recipient)
        {
            throw new NotImplementedException();
        }

        public ListRecipientForListVm GetAllRecipientsForList()
        {
            var recipients = _recipientRepository.GetAllActiveRecipients();
            ListRecipientForListVm result = new ListRecipientForListVm();
            result.Recipients = new List<RecipientForListVm>();
            foreach (var recipient in recipients)
            {
                var recipientVm = new RecipientForListVm()
                {
                    Id = recipient.Id,
                    Name = recipient.Name
                };
                result.Recipients.Add(recipientVm);
            }
            result.Count = result.Recipients.Count;
            return result;
        }

        public RecipientDetailsVm GetRecipientDetails(int recipientId)
        {
            var recipient = _recipientRepository.GetRecipient(recipientId);
            var recipientVm = new RecipientDetailsVm();
            recipientVm.Id = recipient.Id;
            recipientVm.Name = recipient.Name;
            recipientVm.CEOFullName = recipient.CEOFirstName + " " + recipient.CEOLastName;
            var recipientContactInformation = recipient.RecipientContactInformation;
            recipientVm.FirstLineOfContactInformation = recipientContactInformation.FirstName + " " + recipientContactInformation.LastName;

            recipientVm.Addresses = new List<AddressForListVm>();
            recipientVm.PhoneNumbers = new List<ContactDetailListVm>();
            recipientVm.Emails = new List<ContactDetailListVm>();

            foreach (var address in recipient.Addresses)
            {
                var add = new AddressForListVm()
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City
                };
                recipientVm.Addresses.Add(add);
            }

            return recipientVm;
        }
    }
}
