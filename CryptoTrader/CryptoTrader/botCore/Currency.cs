using System;

namespace CryptoTrader
{
	public class Currency
	{
        private string _type;
        private double _15m;
        private double _last;
        private double _buy;
        private double _sell;
		private string _symbol;
        /*
         * Initialise a currency with its type and symbol.
         * eg. type:"GBP" symbol:"£"
         * Symbol is string since there are symbols with 
         * multiple characters, suchs as "kr" or "RUB"
         */
		public Currency (string type, string symbol) 
		{
            this._type = type;
            this._symbol = symbol;
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

        /*
         * Getters and setters for properties. 
         */
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double FifteenM
        {
            get { return _15m; }
            set { _15m = value; }
        }

        public double Last
        {
            get { return _last; }
            set { _last = value; }
        }

        public double Buy
        {
            get { return _buy; }
            set { _buy = value; }
        }

        public double Sell
        {
            get { return _sell; }
            set { _sell = value; }
        }

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

	}
}

