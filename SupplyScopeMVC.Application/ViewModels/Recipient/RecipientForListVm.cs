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
    public class RecipientForListVm : IMapFrom<SupplyScopeMVC.Domain.Model.Recipient>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SupplyScopeMVC.Domain.Model.Recipient, RecipientForListVm>();
        }
    }
}
