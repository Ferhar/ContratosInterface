using System;
using System.Globalization;
using ContractPayment.Entities;
using ContractPayment.Services;

namespace ContractPayment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int month = int.Parse(Console.ReadLine());

            Contract contract = new(number, date, totalValue, month);

            ContractService contractService = new(new PaypalTaxServices());

            contractService.ProcessInvoice(contract);
            Console.WriteLine("Installments:");
            foreach(Installment installment1 in contract.Installments)
            {
                Console.WriteLine(installment1.ToString());
            }
        }
    }
}
