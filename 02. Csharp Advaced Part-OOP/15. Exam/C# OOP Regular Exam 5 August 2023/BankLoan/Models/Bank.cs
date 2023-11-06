using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set => capacity = value;
        }

        public IReadOnlyCollection<ILoan> Loans
            => loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients
            => clients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            if (capacity <= clients.Count)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

            clients.Add(Client);
        }

        public void AddLoan(ILoan loan)
            => loans.Add(loan);

        public string GetStatistics()
            => $"Name: {Name}, Type: {this.GetType().Name}{Environment.NewLine}Clients: {(clients.Any()?string.Join(", ",clients.Select(x=>x.Name)):"none")}{Environment.NewLine}Loans: {loans.Count}, Sum of Rates: {this.SumRates()}";

        public void RemoveClient(IClient Client)
            =>clients.Remove(Client);

        public double SumRates()
            => loans.Sum(x => x.InterestRate);
    }
}
