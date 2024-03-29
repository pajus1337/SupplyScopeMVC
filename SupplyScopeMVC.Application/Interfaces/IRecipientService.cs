﻿using SupplyScopeMVC.Application.ViewModels.Recipient;
using SupplyScopeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application.Interfaces
{
    public interface IRecipientService
    {
        ListRecipientForListVm GetAllRecipientsForList(int pageSize, int pageNumber, string saerchString);
        int AddRecipient(NewRecipientVm recipient);
        RecipientDetailsVm GetRecipientDetails(int recipientId);
        NewRecipientVm GetRecipientForEdit(int id);
        void UpdateRecipient(NewRecipientVm model);
        void DeleteRecipient(int recipientId);
    }
}
