using System;

namespace CryptoTrader
{
	public class Currency
	{
		string name { get; set; }
		double last { get; set; }
		double buy { get; set; }
		double sell { get; set; }
		char symbol { get; set; }

		public Currency () {}

		double convert ( double newCurrency )
		{
			return buy;
		}
	}
}

