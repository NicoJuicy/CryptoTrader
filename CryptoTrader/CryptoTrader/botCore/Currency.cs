using System;

namespace CryptoTrader
{
	public class Currency
	{
		private string type;
        private double last;
        private double buy;
        private double sell;
		private string symbol;
        /*
         * Initialise a currency with its type and symbol.
         * eg. type:"GBP" symbol:"£"
         * Symbol is string since there are symbols with 
         * multiple characters, suchs as "kr" or "RUB"
         */
		public Currency (string type, string symbol) 
		{
            this.type = type;
            this.symbol = symbol;
		}

        /// <summary>
        /// The convert method takes an amount and a currency. 
        /// This amount is related to the instance of currency and converts the amount
        /// into the other currency.
        /// </summary>
        /// <param name="currency"> This is the currency we want to convert to.</param>
        /// <param name="amount"> This is the amount we want to convert.</param>
        /// <returns> Returns the value of the amount of .this currency in the specified currency.</returns>
		public double convert ( Currency currency, double amount )
		{
			double profit = 0;
			//...
			return profit;
		}
	}
}

