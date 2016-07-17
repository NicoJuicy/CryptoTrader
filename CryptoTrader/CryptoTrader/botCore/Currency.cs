using System;

namespace CryptoTrader
{
	public class Currency
	{
		struct Coin
		{
			string name;
			double _15m;
			double last;
			double buy;
			double sell;
			char symbol;
		};

		public Currency () 
		{
			Coin coin = new Coin ();
		}

		public double convert ( double newCurrency )
		{
			double profit = 0;
			//...
			return profit;
		}
	}
}

