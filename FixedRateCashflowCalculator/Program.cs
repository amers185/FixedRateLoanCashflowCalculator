using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedRateCashflowCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            double LoanAmount = GetLoanAmount();
            double NumberOfMonths = GetTerm();
            double Rate = GetInterest();

            Calculator calculator = new Calculator();
            Console.Write("Month"+"\t"+"Interest"+"\tPrincipal"+"\t"+"Rem Balance"+ "\n");
            Console.Write("\n");
            ;
            double RemainderIth = LoanAmount;
            for (int i = 1; i < NumberOfMonths + 1; i++)
            {
                double DisplayInterest = calculator.CalculateInterest(LoanAmount, Rate, NumberOfMonths, RemainderIth);
                double DisplayPrincipal = calculator.CalculatePrincipal(LoanAmount, Rate, NumberOfMonths, RemainderIth);
                double DisplayRemaining = RemainderIth - DisplayPrincipal;
                
                Console.Write(i+"\t"+ Math.Round(DisplayInterest, 2) + "\t\t" + Math.Round(DisplayPrincipal, 2) + "\t\t" + Math.Round(DisplayRemaining, 2));
                RemainderIth = DisplayRemaining;
                Console.Write("\n");
            }
            Console.Write("\n");
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();


        }

        static double GetLoanAmount()
        {
            Console.Write("Please enter your loan amount: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        static double GetTerm()
        {
            Console.Write("Please enter the number of months the loan will be paid out in: ");
            return Convert.ToDouble(Console.ReadLine());
        }
        static double GetInterest()
        {
            Console.Write("Please enter the interest you want to be charged: ");
            return Convert.ToDouble(Console.ReadLine());
        }


    }
}
