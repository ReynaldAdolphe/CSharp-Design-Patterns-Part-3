using System;

/// <summary>
/// This code demonstrates the State pattern which allows an Account
/// to behave differently depending on its balance. The difference in 
/// behavior is delegated to State objects called OverdrawnState, 
/// StandardState and PremiumState. These states represent overdrawn 
/// accounts, starter accounts, and accounts in good standing.
/// </summary>
namespace State.Demonstration
{
    /// <summary>
    /// State Design Pattern.
    /// </summary>
    class client
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Open a new account
            Account account = new Account("Reynald Adolphe");

            // Apply transacitons
            account.Deposit(490.0);
            account.Deposit(390.0);
            account.Deposit(540.0);
            account.PayInterest();
            account.Withdraw(2200.0);
            account.Withdraw(1300.0);

            // Wait
            Console.ReadKey();

        }
    }

    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    abstract class State
    {
        protected Account account;
        protected double balance;

        protected double interest;
        protected double lowerLimit;
        protected double upperLimit;

        // Properties
        public Account Account
        {
            get { return account; }
            set { account = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();
    }


    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Overdrawn indicates that account is overdrawn 
    /// </remarks>
    /// </summary>
    class OverdrawnState : State
    {
        private double _serviceFee;

        // Constructor
        public OverdrawnState(State state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }

        private void Initialize()
        {
            // Should come from a datasource
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            _serviceFee = 15.00;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            amount = amount - _serviceFee;
            Console.WriteLine("No funds available for withdrawal!");
            
            // Disable withdrawn functionality
        }

        public override void PayInterest()
        {
            // No interest is paid
        }

        private void StateChangeCheck()
        {
            if (balance > upperLimit)
            {
                account.State = new StandardState(this);
            }
        }
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Standard indicates a non-interest bearing state
    /// </remarks>
    /// </summary>
    class StandardState : State
    {
        // Overloaded constructors

        public StandardState(State state) :
          this(state.Balance, state.Account)
        {
        }

        public StandardState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            // Should come from a datasource
            interest = 0.0;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < lowerLimit)
            {
                account.State = new OverdrawnState(this);
            }
            else if (balance > upperLimit)
            {
                account.State = new PremiumState(this);
            }
        }
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Premium indicates an interest bearing state
    /// </remarks>
    /// </summary>
    class PremiumState : State
    {
        // Overloaded constructors
        public PremiumState(State state)
          : this(state.Balance, state.Account)
        {
        }

        public PremiumState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {
            // Should come from a database
            interest = 0.05;
            lowerLimit = 1000.0;
            upperLimit = 10000000.0;
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < 0.0)
            {
                account.State = new OverdrawnState(this);
            }
            else if (balance < lowerLimit)
            {
                account.State = new StandardState(this);
            }
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class Account
    {
        private State _state;
        private string _owner;

        // Constructor
        public Account(string owner)
        {
            // New accounts are 'Standard' by default
            this._owner = owner;
            this._state = new StandardState(0.0, this);
        }

        // Properties
        public double Balance
        {
            get { return _state.Balance; }
        }

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void Deposit(double amount)
        {
            _state.Deposit(amount);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}",
              this.State.GetType().Name);
            Console.WriteLine("");
        }

        public void Withdraw(double amount)
        {
            _state.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
              this.State.GetType().Name);
        }

        public void PayInterest()
        {
            _state.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
              this.State.GetType().Name);
        }
    }
}