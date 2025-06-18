using lab_4;

while (true)
{
    Console.Write("\nEnter a program number: ");
    int n = int.Parse(Console.ReadLine());
    switch (n)
    {
        case 1:
            // Write a program using method overloading by changing datatype of arguments to perform addition of two integer numbers and two float numbers.
            Sum sum = new Sum();
            sum.Add(5, 10); // Integer addition
            sum.Add(5.5f, 10.5f); // Float addition
            break;

        case 2:
            // Write a program using method overloading by changing number of arguments to calculate area of square and rectangle.
            Area square = new Area();
            square.CalculateArea(5);
            Area rectangle = new Area();
            rectangle.CalculateArea(5, 10);
            break;

        case 3:
            // Create a class named RBI with calculateInterest() method. Create another classes HDFC, SBI, ICICI which overrides calculateInterest() method.
            HDFC hdfc = new HDFC();
            hdfc.CalculateInterest(10000, 2);
            SBI sbi = new SBI();
            sbi.CalculateInterest(10000, 2);
            ICICI icici = new ICICI();
            icici.CalculateInterest(10000, 2);
            break;

        case 4:
            // Create a class Hospital with HospitalDetails() method. Create another classes Apollo, Wockhardt, Gokul_Superspeciality which overrides HospitalDetails() method.
            Apollo apolo = new Apollo();
            apolo.HospitalDetails();
            Wockhardt wockhardt = new Wockhardt();
            wockhardt.HospitalDetails();
            Gokul_Superspeciality gokul = new Gokul_Superspeciality();
            gokul.HospitalDetails();
            break;

        case 5:
            // Write a programs to Find Area of Square, Rectangle and Circle Method Overloading.
            Area2 area2 = new Area2();
            area2.CalculateArea(5);
            area2.CalculateArea(5, 10);
            area2.CalculateArea(7, true);
            break;

        case 6:
            // Create a BankAccount class having constructor accepting initialBalance and accountHolderName.Also create Deposite() and withdraw() overloaded methods by which user can deposit / withdraw amount using different types of parameters(ex.cash, check).
            BankAccount account = new BankAccount("John Doe", 1000);
            account.Deposit(500);
            account.Deposit("123456", 200.75);
            account.Withdraw(300);
            account.Withdraw("123456", 200.78);
            break;

        default:
            Console.WriteLine("Invalid program number.");
            return 0;
    }
}