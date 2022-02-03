using System;
using ContractPayment.Entities;

namespace ContractPayment.Services
{
    class ContractService
    {
        private ITaxService _iTaxService;

        public ContractService(ITaxService iTaxService)
        {
            _iTaxService = iTaxService;
        }

        public void ProcessInvoice(Contract contract)
        {
            double basicQuota = contract.TotalValue / (double)contract.Months;
            for(int i =1; i<= contract.Months; i++)
            {
                double updatedQuota = basicQuota + _iTaxService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _iTaxService.PaymentFee(updatedQuota);
                contract.Installments.Add(new Installment(contract.Date.AddMonths(i), fullQuota));
            }
        }
    }
}
