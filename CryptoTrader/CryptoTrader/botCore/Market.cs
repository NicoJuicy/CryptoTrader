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
			this.currentPrice = UpdateTicker ("GBP", "BLOCKCHAIN");
		}
			
		public double UpdateTicker (string currency, string exchange) 
		{	
			if (exchange == "BLOCKCHAIN") {
				string tickerURL = "https://blockchain.info/ticker";
				string priceObj = MakeAPIRequest (tickerURL);

				JavaScriptSerializer data = new JavaScriptSerializer ();
				data.Deserialize<Currency> (priceObj); // ?? no idea what im doing here ??

				return currentPrice;
			} else { return -1; }
		} // update MarketData and return price

		public string GetStats () 
		{
			string statsURL = "https://blockchain.info/stats?format=json";
			string stats = MakeAPIRequest (statsURL);
			return stats;
		}

		public Int64 GetTotalBTC () 
		{
			string totalSatoshiURL = "https://blockchain.info/q/totalbc";
			Int64 totalBtc = Int64.Parse (MakeAPIRequest(totalSatoshiURL)) / 100000000;
			return totalBtc;
		}

		// Returns estimated time in seconds
		public float TimeTillNextBlock () 
		{
			string etaURL = "https://blockchain.info/q/eta";
			float eta = float.Parse (MakeAPIRequest (etaURL));
			return eta;
		}

		string MakeAPIRequest (string url)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
			using (StreamReader stream = new StreamReader (response.GetResponseStream ())) {
				string responseStream = stream.ReadToEnd ();
				return responseStream;
			}
		}
	}
}

