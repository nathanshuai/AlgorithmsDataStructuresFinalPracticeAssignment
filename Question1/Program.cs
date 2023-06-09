// Question1:
//A vending machine has a set of coins to handle purchase operations.

using System;
using System.Collections.Generic;



Dictionary<string, decimal> itemAndPrices = new Dictionary<string, decimal>
    {
        { "A", 3.00m },
        { "B", 2.00m },
        { "C", 1.50m },
        { "D", 10.00m },
        { "E", 20.00m },
        { "F", 30.00m },
        { "G", 40.00m }
    };

Dictionary<decimal, int> remainingCoin = new Dictionary<decimal, int>
    {
        { 20.00m, 5 },
        { 10.00m, 10 },
        { 5.00m, 15 },
        { 2.00m, 20 },
        { 1.00m, 25 }
    };


Console.WriteLine("Welcome to the Vending Machine!");
bool isTransactionInProgress = true;

while (isTransactionInProgress)
{
    Console.Write("Enter the amount of money: $");
    string input = Console.ReadLine().ToUpper();

    if (input == "CANCEL")
    {
        Console.WriteLine("Transaction canceled. Thank you!");
        break;
    }

    if (!decimal.TryParse(input, out decimal money) || money <= 0)
    {
        Console.WriteLine("Invalid amount. Please enter a positive amount.");
        continue;
    }

    Console.Write("Enter the item name: ");
    string enteredItem = Console.ReadLine().ToUpper();

    if (enteredItem == "CANCEL")
    {
        Console.WriteLine("Transaction canceled. Thank you!");
        break;
    }

    if (!itemAndPrices.ContainsKey(enteredItem))
    {
        Console.WriteLine("Item not found. Please enter a valid item.");
        continue;
    }

    decimal itemPrice = itemAndPrices[enteredItem];

    if (money < itemPrice)
    {
        Console.WriteLine($"Insufficient funds. Please enter at least ${itemPrice}.");
        continue;
    }

    decimal change = money - itemPrice;

    Console.WriteLine($"Vending {enteredItem}...");

    Dictionary<decimal, int> changeCoins = new Dictionary<decimal, int>();

    foreach (KeyValuePair<decimal, int> KeyValuePair in remainingCoin)
    {
        decimal coinDenomination = KeyValuePair.Key;
        int coinQuantity = KeyValuePair.Value;

        int coinsToReturn = (int)(change / coinDenomination);

        if (coinsToReturn > 0 && coinQuantity >= coinsToReturn)
        {
            changeCoins.Add(coinDenomination, coinsToReturn);
            change -= coinsToReturn * coinDenomination;
            remainingCoin[coinDenomination] -= coinsToReturn;
        }
    }

    if (changeCoins == null)
    {
        Console.WriteLine("Insufficient change. Transaction canceled.");
        continue;
    }

    Console.WriteLine("Returning change:");
    foreach (KeyValuePair<decimal, int> KeyValuePair in changeCoins)
    {
        decimal coinDenomination = KeyValuePair.Key;
        int coinCount = KeyValuePair.Value;

        Console.WriteLine($"{coinDenomination:C} : {coinCount} piece(s)");
    }

    isTransactionInProgress = false;
}








