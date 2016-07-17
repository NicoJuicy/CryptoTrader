/*
	ToDo:
	Methods for executing different types of orders
		e.g. Long, short, market order, stop loss etc
					or maybe put these in Trade class?
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
			//MarketData data = new MarketData ();
			this.currentPrice = GetMarketPrice (Currencies.BTC, Exchanges.BLOCKCHAIN);
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

						}
					}
				}
			}
			return currentPrice;
		}

		public Int64 GetTotalBTC () 
		{
			string totalSatoshi = "https://blockchain.info/q/totalbc";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (totalSatoshi);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
			using (StreamReader resStream = new StreamReader (response.GetResponseStream ())) {
				Int64 totalBtc = Int64.Parse (resStream.ReadToEnd ()) / 100000000; 		// <-- convert to btc 
				return totalBtc;
			}
		}
			
		// Returns estimated time in seconds
		public float TimeTillNextBlock () 
		{
			string etaURL = "https://blockchain.info/q/eta";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (etaURL);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
			using (StreamReader stream = new StreamReader (response.GetResponseStream ())) {
				float eta = float.Parse (stream.ReadToEnd ());
				return eta;
			}
		}
	}
}

