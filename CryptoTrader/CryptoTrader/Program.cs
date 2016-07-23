/*
 	To-Do:
    Build methods that interface with the real world currency exhanges-
        - Getting current price for cryptocurrencies
        - Converting valueOf Currency to other Currency
    Something to find and parse historical data of cryptocurrencies value
        - That stores data in some easier to use format (XML or json?)
    Method to use historical data that can be used to train a neural network

	Bitcoin API: https://blockchain.info/api
*/

using System;
using System.Collections.Generic;

namespace CryptoTrader
{
	class MainClass
	{
		public static double globalCash = 1000; // a.k.a RiskCapital
		static List<Trader> traders = new List<Trader>();
		static List<Market> markets = new List<Market> (); // this could possibly be a dictionary

		public static void Main (string[] args)
		{
			Init ();

		}

		static void CreateTrader (double startCash) 
		{
			Trader trader = new Trader (startCash);
			traders.Add (trader);
		}

		static void CreateMarket () 
		{
			Market market = new Market ("BLOCKCHAIN");
			markets.Add (market);
		}

		static void Init () 
		{
			Console.Title = "Crypto Trader v0.1";
			Console.WriteLine ("CryptoTrader v0.1");
			Console.WriteLine ("Lets trade some bitcoins!\n");
			//Console.Write ("Current bitcoin ticker is:");
            Console.WriteLine("Creating markets...");
			if (markets.Count < 1) { CreateMarket (); }
			Console.WriteLine (markets[0].exchangeName + " market has been created.");
            Console.WriteLine(markets[0].exchangeName + ": Updating ticker...");
            markets[0].UpdateTicker();
            Console.WriteLine(markets[0].exchangeName + ": Ticker updated");
            Console.WriteLine();
			Console.WriteLine ("There are currently {0} Bitcoins in existence", markets[0].GetTotalBTC ());
			Console.WriteLine ("\nIf the formatting is messed up, try fullscreening the console");
			Console.WriteLine ("To see stats press 's' or press 'q' to quit");
			char x = (char)Console.Read ();
			if (x.Equals ('s')) {
				Console.WriteLine ("\n\nMarket stats:");
				Console.WriteLine (markets [0].GetStats ());
			}
		}
	}
}
