using AutoMapper;
using AutoMapper.QueryableExtensions;
using SupplyScopeMVC.Application.Interfaces;
using SupplyScopeMVC.Application.Mapping;
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
        private readonly IMapper _mapper;

        public RecipientService(IRecipientRepository recipientRepository, IMapper mapper)
        {
            _recipientRepository = recipientRepository;
            _mapper = mapper;
        }

        public int AddRecipient(NewRecipientVm recipient)
        {
            throw new NotImplementedException();
        }

        public ListRecipientForListVm GetAllRecipientsForList()
        {
            var recipients = _recipientRepository.GetAllActiveRecipients().ProjectTo<RecipientForListVm>(_mapper.ConfigurationProvider).ToList();
            var recipientList = new ListRecipientForListVm()
            {
                Recipients = recipients,
                Count = recipients.Count,
            };
            return recipientList;
        }

        public RecipientDetailsVm GetRecipientDetails(int recipientId)
        {
            var recipient = _recipientRepository.GetRecipient(recipientId);
            var recipientVm = _mapper.Map<RecipientDetailsVm>(recipient);

            if (recipient.Addresses != null)
            {
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
            }
            return recipientVm;
        }
    }
}
