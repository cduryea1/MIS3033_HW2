//Mis 3033
//HW2 Task 3
//Camille Duryea
//113529005

string qStr = "Another receipt? (y/n) ";
Console.WriteLine(qStr);

string userChoiceStr = Console.ReadLine();
userChoiceStr = userChoiceStr.ToLower();

string outMesStr;

List<Receipt> receiptsList = new List<Receipt>();

//Collect receipt or orders


while (userChoiceStr == "y" || userChoiceStr == "yes")
{
    outMesStr = "Customer ID: ";
    Console.Write(outMesStr);
    string customerIDStr = Console.ReadLine();
    int customerIDInt = Convert.ToInt32(customerIDStr);

    Console.Write("Number of cogs: ");
    string numCogsStr = Console.ReadLine();
    int numCogsInt = Convert.ToInt32(numCogsStr);

    Console.Write("Number of gears: ");
    string numGearsStr = Console.ReadLine();
    int numGearsInt = Convert.ToInt32(numGearsStr);

    Receipt newReceipt = new Receipt(customerIDInt, numCogsInt, numGearsInt);

    newReceipt.PrintReceipt();

    receiptsList.Add(newReceipt);

    Console.WriteLine();
    Console.Write(qStr);
    userChoiceStr = Console.ReadLine();
    userChoiceStr = userChoiceStr.ToLower();
}

////four options
//    1.print all receipt of one customer
//    2. print all receipt for today
//    3. pint the highest total ceipt
//    presss other keys to end

userChoiceStr = "1";
while(userChoiceStr == "1" || userChoiceStr == "2" || userChoiceStr == "3")
{
    Console.WriteLine("Please chose from the options:");
    Console.WriteLine("1: Print all receipts of one customer");
    Console.WriteLine("2: Print all receipts for today");
    Console.WriteLine("3: Print the highest total receipt");
    Console.WriteLine("Press other keys to end");

    userChoiceStr = Console.ReadLine();
    userChoiceStr = userChoiceStr.ToLower();

    if (userChoiceStr == "1")
    {
        Console.Write("Input customer id: ");
        string inputCustomerIDStr = Console.ReadLine();
        int inputCustomerIDInt = Convert.ToInt32(inputCustomerIDStr);

        for (int i = 0; i < receiptsList.Count; i++)
        {
            if (receiptsList[i].CustomerID == inputCustomerIDInt)
            {
                receiptsList[i].PrintReceipt();
            }
        }
    }
    else if (userChoiceStr == "2")
    {
        DateTime tdDT = DateTime.Now;

        for (int i = 0; i < receiptsList.Count; i++)
        {
            if (receiptsList[i].SaleDate.ToString("d") == tdDT.ToString("d"))
            {
                receiptsList[i].PrintReceipt();
            }
        }
    }
    else if (userChoiceStr == "3")
    {
        if(receiptsList.Count > 0)
        {
            Receipt highestR = receiptsList[0];
            for (int i = 0; i < receiptsList.Count; i++)
            {
                if (receiptsList[i].CalculateTotal()> highestR.CalculateTotal())
                {
                    highestR = receiptsList[i];
                }
            }
            Console.WriteLine("HIGHEST:");
            highestR.PrintReceipt();
        }
    }
}

Console.ReadLine();

public class Receipt
{
    public int CustomerID;
    public int CogQuantity;
    public int GearQuantity;
    public DateTime SaleDate;
    private double SalesTaxPercent;
    private double CogPrice;
    private double GearPrice;



    public Receipt()
    {
        this.SalesTaxPercent = 8.9 / 100;
        this.CogPrice = 79.99;
        this.GearPrice = 250.00;
        this.SaleDate = DateTime.Now;

    }

    public Receipt(int id, int cog, int gear)
    {
        this.SalesTaxPercent = 8.9 / 100;
        this.CogPrice = 79.99;
        this.GearPrice = 250.00;
        this.CustomerID = id;
        this.CogQuantity = cog;
        this.GearQuantity = gear;
        this.SaleDate = DateTime.Now;

    }
    public void PrintReceipt()
    {
        Console.WriteLine("==========================");

        Console.WriteLine("RECEIPT");
        string outMesStr;
        outMesStr = string.Format($"# cogs: {this.CogQuantity}");
        Console.WriteLine(outMesStr);

        outMesStr = string.Format($"# gears: {this.GearQuantity}");
        Console.WriteLine(outMesStr);

        outMesStr = string.Format($" Net amount: {this.CalculateNetAmount():C2}");
        Console.WriteLine(outMesStr);

        outMesStr = string.Format($" Tax amount: {this.CalculateTaxAmount():C2}");
        Console.WriteLine(outMesStr);

        outMesStr = string.Format($" Total amount: {this.CalculateTotal():C2}");
        Console.WriteLine(outMesStr);

        outMesStr = String.Format($"Time: {this.SaleDate}");
        Console.WriteLine(outMesStr);

        Console.WriteLine("==========================");



    }
    private double CalculateNetAmount()
    {
        double netAmountDdb;
        if (this.CogQuantity > 10 || this.GearQuantity > 10 || this.CogQuantity + this.GearQuantity > 16)
        {
            netAmountDdb = (this.CogPrice * CogQuantity + this.GearPrice * this.GearQuantity) * (1+0.125);
        }
        else
        {
            netAmountDdb = (this.CogPrice * CogQuantity + this.GearPrice * this.GearQuantity) * (1 + 0.15);

        }
        return netAmountDdb;
        
    }
    private double CalculateTaxAmount()
    {
        return this.SalesTaxPercent * this.CalculateNetAmount();
    }
    public double CalculateTotal()
    {
        return this.CalculateNetAmount() + this.CalculateTaxAmount();
    }
}
