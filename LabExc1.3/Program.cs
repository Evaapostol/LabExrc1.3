using System;

namespace LabExc1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Account newone = new Account("eva", 270, 1);
            Console.WriteLine(newone.ToString());
            StoreAccount acnt1 = new StoreAccount("eva", 28000, 1, "STORE1", "Senior");
            Console.WriteLine(acnt1.ToString());
            bool doneWithdrow = acnt1.Withdraw(15000);
            bool doneDeposit = acnt1.Deposit(27000);

            double neaBalance = acnt1.balance;
            acnt1.ChangeCategory();
            Console.WriteLine(acnt1.ToString());
        }

        
    }

    class Account
    {
        const double depositLimit = 5000;

        public string owner { get; set; }
        public double balance { get; set; }
        public int numberOfTransations { get; set; }

        public Account()
        {

        }
        public Account(string owner, double balance, int numberOfTransations)
        {
            this.owner = owner;
            this.balance = balance;
            this.numberOfTransations = numberOfTransations;
        }

        public override string ToString()
        {
            return "Owner = " + owner + " Balance = " + balance + " numberOfTransations = " + numberOfTransations;
        }

        public bool Withdraw(double amount)
        {
            if (balance > amount)
            {
                balance -= amount;
                numberOfTransations++;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Deposit(double amount)
        {
            if (amount > depositLimit)
            {
                balance += amount;
                numberOfTransations++;
                return true;
            }
            else
            {
                return false;
            }


        }
    }

    class StoreAccount : Account
    {
        public string storeName;
        public string accountCategory;
        
        public StoreAccount()
        {

        }

        public StoreAccount(string owner, double balance, int numberOfTransations, string storeName, string accountCategory): base(owner, balance, numberOfTransations)
        {
            this.storeName = storeName;
            this.accountCategory = accountCategory;
        }

        public void ChangeCategory()
        {
            if (balance > 0 && balance <= 10000)
            {
                accountCategory = "Basic";
            }
            else if (balance > 10000 && balance <= 20000)
            {
                accountCategory = "Mid";
            }
            else if (balance > 20000 && balance <= 30000)
            {
                accountCategory = "Senior";
            }
            else if (balance > 30000)
            {
                accountCategory = "Lead";
            }
        }

        public override string ToString()
        {
            return base.ToString() + " Store Name = " + storeName + " Account Category = " + accountCategory;
        }
    }
}
