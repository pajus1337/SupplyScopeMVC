using AutoMapper;
using AutoMapper.QueryableExtensions;
using SupplyScopeMVC.Application.Interfaces;
using SupplyScopeMVC.Application.Mapping;
using SupplyScopeMVC.Application.ViewModels.Recipient;
using SupplyScopeMVC.Domain.Interfaces;
using SupplyScopeMVC.Domain.Model;
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
            var newRecipient = _mapper.Map<Recipient>(recipient);
            var id = _recipientRepository.AddRecipient(newRecipient);
            return id;
        }

        public ListRecipientForListVm GetAllRecipientsForList(int pageSize, int pageNumber, string searchString)
        {
            var recipients = _recipientRepository.GetAllActiveRecipients().Where(p => p.Name.StartsWith(searchString)).ProjectTo<RecipientForListVm>(_mapper.ConfigurationProvider).ToList();
            var recipientsToShow = recipients.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var recipientList = new ListRecipientForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                SearchString = searchString,
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

        public NewRecipientVm GetRecipientForEdit(int id)
        {
            var recipient = _recipientRepository.GetRecipient(id);
            var recipientVm = _mapper.Map<NewRecipientVm>(recipient);
            return recipientVm;
        }

        public void UpdateRecipient(NewRecipientVm model)
        {
            var recipient = _mapper.Map<Recipient>(model);
            _recipientRepository.UpdateRecipient(recipient);
        }
    }
}
