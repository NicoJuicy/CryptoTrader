using System;
using System.IO;
using System.Collections.Generic;

namespace CryptoTrader
{
	public class MarketData
	{
		struct Ticker
		{	
			public string name;		// not sure if this is the best way 
			public double _15m;		// to represent the price?
			public double last;		// maybe put it in the Currency class instead????
			public double buy;
			public double sell;
			public char symbol;
		};

		string currency;
		List<Ticker> ticker;

		public MarketData (string currency)
		{
			this.currency = currency;
			ticker = new List<Ticker>();
		}

		public void Export () 
		{
			
		}

		public void Import () 
		{
			
		}
	}
}

