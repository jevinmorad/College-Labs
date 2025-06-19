namespace lab_2
{
    internal class Account_Details
    {
        public string AccountHolderName;
        public string AccountNumber;
        public double Balance;
        public double RateOfInterest;
        public int Time;
        public void GetDetails()
        {
            Console.Write("Enter Account Holder Name: ");
            AccountHolderName = Console.ReadLine();

            Console.Write("Enter Account Number: ");
            AccountNumber = Console.ReadLine();

            Console.Write("Enter Balance: ");
            Balance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Rate of Interest (% per annum): ");
            RateOfInterest = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Time (in years): ");
            Time = Convert.ToInt32(Console.ReadLine());
        }
    }

    class Interest : Account_Details
    {
        double interest;

        public void CalculateInterest()
        {
            interest = (Balance * RateOfInterest * Time) / 100;
        }

        public void DisplayInterest()
        {
            Console.WriteLine("\n--- Account Summary ---");
            Console.WriteLine("Account Holder: " + AccountHolderName);
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Principal Amount: $" + Balance);
            Console.WriteLine("Rate of Interest: " + RateOfInterest + "%");
            Console.WriteLine("Time Period: " + Time + " years");
            Console.WriteLine("Total Interest: $" + interest);
        }
    }
}
