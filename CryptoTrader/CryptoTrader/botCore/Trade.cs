using System;

namespace CryptoTrader
{
	public class Trade
	{
		int tradeId;

		double boughtPrice; // exchange rate
		double askPrice;

		string currency;
		string exchange;

		public Trade (string currency, string exchange)
		{
			tradeId += 1; // assign a random id for security?
			this.currency = currency;
			this.exchange = exchange;
		}

		public bool MarketOrderBuy (double price, int qty) 
		{
			return true;
		}

		public bool MarketOrderSell (double price, int qty) 
		{
			return true;
		}

		public bool LimitOrderBuy (double limit, int qty)
		{
			return true;
		}

		public bool LimitOrderSell (double limit, int qty)
		{
			return true;
		}

		double CalculateProfit ()
		{
			double profit = 0;
			//...
			return profit;
		}
	}
}

