using System;
using System.Collections.Generic;

namespace CryptoTrader
{
	public class Trader
	{
		static int totalTraders = 0;
		int traderId;
		double cash;
		List<Trade> openTrades;

		//temp vars
		string currency = "GBP";
		string exchange = "BLOCKCHAIN";

		public Trader (double cash)
		{
			//BrainPart brain = new BrainPart ();
			traderId = totalTraders += 1;
			this.cash = cash;
			openTrades = new List<Trade>();
		}

		public void Buy () 
		{
			Trade trade = new Trade (currency, exchange);
			openTrades.Add (trade);
		}

		public void Sell () 
		{
			Trade trade = new Trade (currency, exchange);
			openTrades.Add (trade);
		}

		public void CloseAllTrades () 
		{
			// close any open connections...

			openTrades.Clear ();
		}
	}
}

