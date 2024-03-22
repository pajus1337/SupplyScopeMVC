using AutoMapper;
using FluentValidation;
using SupplyScopeMVC.Application.Mapping;
using SupplyScopeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application.ViewModels.Recipient
{
    public class NewRecipientVm : IMapFrom<SupplyScopeMVC.Domain.Model.Recipient>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewRecipientVm, SupplyScopeMVC.Domain.Model.Recipient>().ReverseMap(); ;
        }
    }

    public class NewRecipientValidaton : AbstractValidator<NewRecipientVm>
    {
        public NewRecipientValidaton()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        }
    }
}
