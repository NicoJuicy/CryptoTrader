/*
	ToDo:
	Methods for executing different types of orders
		e.g. Long, short, market order, stop loss etc
	
*/

using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace CryptoTrader
{
	public class Market
	{
		public enum Currencies { BTC, GBP };
		public enum Exchanges { BLOCKCHAIN };

		public double currentPrice { get; set; }

		public Market () 
		{
			
		}

		// Maybe rename to UpdateTicker?
		public double GetMarketPrice (string currency, string exchange) 
		{	
			if (exchange == "BLOCKCHAIN") {
				string tickerURL = "https://blockchain.info/ticker";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create (tickerURL);
				HttpWebResponse response = (HttpWebResponse)request.GetResponse ();

				string line;
				using (StreamReader stream = new StreamReader (response.GetResponseStream ())) {
					//line = stream.ReadToEnd ();

					// try serialization to Currency class object

					while ((line = stream.ReadLine ()) != null) {
						if (line.Contains (currency)) {
							Console.WriteLine (line);
							break;
						}
					}
				}
			}
			return currentPrice;
		}

		public void DispTotalBTC () 
		{
			string totalBTC = "https://blockchain.info/q/totalbc";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (totalBTC);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
			StreamReader resStream = new StreamReader (response.GetResponseStream ());

			Console.WriteLine ("Total BTC: " + resStream.ReadToEnd ());
			resStream.Dispose ();
		}
	}
}

