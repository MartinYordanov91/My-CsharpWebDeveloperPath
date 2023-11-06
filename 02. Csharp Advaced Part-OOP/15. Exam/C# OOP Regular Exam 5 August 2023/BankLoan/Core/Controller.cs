using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Linq;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans = new LoanRepository();
        private BankRepository banks = new BankRepository();
        public string AddBank(string bankTypeName, string name)
        {
            if (bankTypeName != "CentralBank" && bankTypeName != "BranchBank")
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }
            IBank bank = null;
            if (bankTypeName == "CentralBank")
            {
                bank = new CentralBank(name);
            }
            else if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);
            }

            banks.AddModel(bank);
            return $"{bankTypeName} is successfully added.";
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client = null;
            if (clientTypeName == "Adult")
            {
                client = new Adult(clientName, id, income);
            }
            else if (clientTypeName == "Student")
            {
                client = new Student(clientName, id, income);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = banks.FirstModel(bankName);
            string typeBank = bank.GetType().Name;

            if ((typeBank == "BranchBank" && clientTypeName == "Adult") ||
                (typeBank == "CentralBank" && clientTypeName == "Student"))
            {
                return "Unsuitable bank.";
            }

            banks.FirstModel(bankName).AddClient(client);
            return $"{clientTypeName} successfully added to {bankName}.";
        }

        public string AddLoan(string loanTypeName)
        {
            ILoan loan = null;

            if (loanTypeName == "StudentLoan")
            {
                loan = new StudentLoan();
            }
            else if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            loans.AddModel(loan);
            return $"{loanTypeName} is successfully added.";
        }

        public string FinalCalculation(string bankName)
        {
            decimal sum = 0;
            IBank bank = banks.FirstModel(bankName);

            sum += (decimal)bank.Clients.Sum(x => x.Income);
            sum += (decimal)bank.Loans.Sum(x => x.Amount);

            return $"The funds of bank {bankName} are {sum:f2}.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }
            IBank bank = banks.FirstModel(bankName);
            bank.AddLoan(loan);
            loans.RemoveModel(loan);

            return $"{loanTypeName} successfully added to {bankName}.";
        }

        public string Statistics()
            => $"{string.Join(Environment.NewLine, banks.Models.Select(x => x.GetStatistics()))}";

    }
}
