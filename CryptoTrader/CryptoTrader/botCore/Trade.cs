using System;

namespace CryptoTrader
{
	public class Trade
	{
		public int tradeId { get; private set;}

		double boughtPrice; // exchange rate
		double askPrice;

		string currency;
		string exchange;

		public Trade (string currency, string exchange)
		{
			tradeId = GenerateTradeId ();
			this.currency = currency;
			this.exchange = exchange;
		}

		int GenerateTradeId ()
		{
			int id = 0;
			//...
			return id;
		}

		public bool MarketOrderBuy (double price, double qty) 
		{
			return true;
		}

		public bool MarketOrderSell (double price, double qty) 
		{
			return true;
		}

		public bool LimitOrderBuy (double limit, double qty)
		{
			return true;
		}

		public bool LimitOrderSell (double limit, double qty)
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

