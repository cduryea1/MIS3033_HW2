//HW2
//Camille Duryea
//113529005

//DataType[] arr_name;
//arr_name = new DataType[5];


string[] fruitNameArr;
fruitNameArr = new string[5];

double[] fruitPriceArr;
fruitPriceArr = new double[5];

fruitNameArr[0] = "apples";
fruitNameArr[1] = "oranges";
fruitNameArr[2] = "bananas";
fruitNameArr[3] = "grapes";
fruitNameArr[4] = "blueberries";

fruitPriceArr[0] = 0.99;
fruitPriceArr[1] = 0.5;
fruitPriceArr[2] = 0.5;
fruitPriceArr[3] = 1.99;
fruitPriceArr[4] = 1.99;

Console.WriteLine("Fruits names:");
for (int i = 0; i < fruitNameArr.Length; i++) 
{
    Console.Write(fruitNameArr[i] + "  ");
}

Console.WriteLine("\n");
Console.WriteLine("Input the name of the fruit:");
string userChoiceStr = Console.ReadLine();

bool isMatched = false;


for(int i = 0; i < fruitNameArr.Length; i++)
{
    if (fruitNameArr[i] == userChoiceStr)
    {
        string outMesStr = string.Format($"The price of {fruitNameArr[i]} is {fruitPriceArr[i]:C2}");
        Console.WriteLine(outMesStr);
        isMatched = true;
    }
}

if(isMatched == false)
{
    Console.WriteLine("Sorry wrong name");
}

Console.ReadLine();
