using System;
using System.Collections.Generic;

namespace ContractPayment.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public int Months { get; set; }
        public List<Installment> Installments { get; set; }
        
        public Contract(int number, DateTime date, double totalValue, int quantityInstalmment)
        {
            Number = number;
            Date = date;
            Months = quantityInstalmment;
            TotalValue = totalValue;
            Installments = new List<Installment>();
        }
    }
}
