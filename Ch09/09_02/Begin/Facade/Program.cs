using System;

/// <summary>
/// This code demonstrates the Facade pattern as a MortgageApplication 
/// object which provides a simplified interface to a large subsystem 
/// of classes measuring the creditworthyness of an applicant.
/// </summary>
namespace Facade.Demonstration
{
    /// <summary>
    /// Facade Design Pattern.
    /// </summary>
    class Client
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Facade
            CollegeLoan collegeLoan = new CollegeLoan();

            // Evaluate loan
            Student student = new Student("Hunter Sky");
            bool eligible = collegeLoan.IsEligible(student, 75000);

            Console.WriteLine("\n" + student.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class CollegeLoan
    {
        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();

        public bool IsEligible(Student stud, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",
              stud.Name, amount);

            bool eligible = true;

            // Verify creditworthyness of applicant
            if (!_bank.HasSufficientSavings(stud, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(stud))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(stud))
            {
                eligible = false;
            }

            return eligible;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    class Bank
    {
        public bool HasSufficientSavings(Student c, int amount)
        {
            Console.WriteLine("Verify bank for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    class Credit
    {
        public bool HasGoodCredit(Student c)
        {
            Console.WriteLine("Verify credit for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    class Loan
    {
        public bool HasNoBadLoans(Student c)
        {
            Console.WriteLine("Verify loans for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// Student class
    /// </summary>
    class Student
    {
        private string _name;

        // Constructor
        public Student(string name)
        {
            this._name = name;
        }

        // Gets the name
        public string Name
        {
            get { return _name; }
        }
    }
}