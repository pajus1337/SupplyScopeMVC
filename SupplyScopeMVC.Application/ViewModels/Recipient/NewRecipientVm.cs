using AutoMapper;
using SupplyScopeMVC.Application.Mapping;
using SupplyScopeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application.ViewModels.Recipient
{
    public class NewRecipientVm : IMapFrom<SupplyScopeMVC.Domain.Model.Recipient>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewRecipientVm, SupplyScopeMVC.Domain.Model.Recipient>();
        }
    }
}
