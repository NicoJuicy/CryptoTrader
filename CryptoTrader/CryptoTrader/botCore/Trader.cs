﻿using System;
using System.Collections.Generic;

namespace CryptoTrader
{
	public class Trader
	{
		static int totalTraders = 0;
		int traderId;
		double cash;
		List<Trade> openTrades;
		List<Trade> pastTrades;

		//temp vars
		string currency = "GBP";
		string exchange = "BLOCKCHAIN";

		public Trader (double cash)
		{
			BrainPart brain = new BrainPart ();
			traderId = totalTraders += 1;
			openTrades = new List<Trade> ();
			pastTrades = new List<Trade> ();
			this.cash = cash;
		}

		public int Buy (double price, double qty, string tradeType) 
		{
			Trade trade = new Trade (currency, exchange);
			openTrades.Add (trade);

			switch (tradeType) {
			case "market":
				trade.MarketOrderBuy (price, qty);
				return trade.tradeId;
			case "limit":
				trade.LimitOrderBuy (price, qty);
				return trade.tradeId;
			default:
				Console.WriteLine ("Invalid trade type, Purchase failed");
				return -1;
			}
			pastTrades.Add (trade);
			openTrades.Remove (trade);
		}

		public void Sell (double price, double qty, string tradeType) 
		{
			Trade trade = new Trade (currency, exchange);
			openTrades.Add (trade);

			switch (tradeType) {
				case "market":
					trade.MarketOrderSell (price, qty);
					break;
				case "limit":
					trade.LimitOrderSell (price, qty);
					break;
				default:
					Console.WriteLine ("Invalid trade type, Purchase failed");
					break;
			}
		}

		public void CloseAllTrades () 
		{
			// close any open connections...

			openTrades.Clear ();
		}
	}
}

