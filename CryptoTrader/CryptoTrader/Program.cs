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
		static List<Market> markets = new List<Market> ();

		public static void Main (string[] args)
		{
			
		}

		static void CreateTrader (double startCash) 
		{
			Trader trader = new Trader (startCash);
			traders.Add (trader);
			//return trader;
		}

		static void CreateMarket () 
		{
			Market market = new Market ();
			markets.Add (market);
			//return market;
		}
	}
}
