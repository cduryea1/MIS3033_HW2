﻿//MIs 3033
//HW2 T2
//Camille DUryea
//113529005

//dictionary<key, value> dict_name;
//dict_name = new Dictionary<key, value>();

Dictionary<string, double> fruitDic = new Dictionary<string, double>();

fruitDic.Add("apples", 0.99);
fruitDic.Add("oranges", 0.5);
fruitDic.Add("bananas", 0.5);
fruitDic.Add("grapes", 2.99);
fruitDic.Add("blueberries", 1.99);

Console.WriteLine("Fruit names:");
//foreach(string key in fruitDic.Keys)
//{
//    Console.Write(key + "  ");

//}

for(int i = 0; i < fruitDic.Count;i++)
{
    Console.Write(fruitDic.Keys.ElementAt(i) + "  ");
}


Console.WriteLine("\n");
Console.WriteLine("Input the fruit name: ");

string userInputStr = Console.ReadLine();

if(fruitDic.ContainsKey(userInputStr))
{
    string outMesStr = string.Format($"The price of {userInputStr} is {fruitDic[userInputStr]:C2}");
    Console.WriteLine(outMesStr);
}
else
{
    Console.WriteLine("Sorry Wrong Fruit Name!");
}

Console.ReadLine();



