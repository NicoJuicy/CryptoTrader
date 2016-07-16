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

namespace CryptoTrader
{
	class MainClass
	{
		public static double globalCash; // a.k.a RiskCapital

		public static void Main (string[] args)
		{
			Market market = new Market ();
			double x = market.GetMarketPrice ("GBP", "BLOCKCHAIN");
		}
			
	}
}
