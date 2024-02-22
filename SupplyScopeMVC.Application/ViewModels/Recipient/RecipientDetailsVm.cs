using AutoMapper;
using SupplyScopeMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application.ViewModels.Recipient
{
    public class RecipientDetailsVm : IMapFrom<SupplyScopeMVC.Domain.Model.Recipient>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CEOFullName { get; set; }
        public string FirstLineOfContactInformation { get; set; }
        public List<AddressForListVm> Addresses { get; set; }
        public List<ContactDetailListVm> Emails { get; set; }
        public List<ContactDetailListVm> PhoneNumbers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SupplyScopeMVC.Domain.Model.Recipient, RecipientDetailsVm>()
                .ForMember(s => s.CEOFullName, opt => opt.MapFrom(d => d.CEOFirstName + " " + d.CEOLastName))
                .ForMember(s => s.FirstLineOfContactInformation, opt => opt.MapFrom(d => d.RecipientContactInformation.FirstName
                + " " + d.RecipientContactInformation.LastName))

                .ForMember(d => d.Addresses, opt => opt.Ignore())
                .ForMember(d => d.Emails, opt => opt.Ignore())
                .ForMember(d => d.PhoneNumbers, opt => opt.Ignore());
        }
    }
}
