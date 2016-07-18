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
		public string exchangeName { get; private set; }
		public double currentPrice { get; set; }
		MarketData data;

		public enum Currencies { BTC, GBP };
		public enum Exchanges { BLOCKCHAIN };

		public Market (string name) 
		{
			this.exchangeName = name;
			//this.currentPrice = UpdateTicker ("GBP", exchangeName);
		}
			
		public string UpdateTicker (string currency, string exchange) 
		{
			if (exchange == exchangeName) {
				string tickerURL = "https://blockchain.info/ticker";
				string tickerObj = MakeAPIRequest (tickerURL);

				//JavaScriptSerializer serializedData = new JavaScriptSerializer ();
				//serializedData.Deserialize<Currency> (tickerObj); // ?? no idea what im doing here ??
				//Console.WriteLine (serializedData);

				return tickerObj;
			} else { 
				return "error: Unknown exchange"; 
			}
		} 

		public string GetStats () 
		{
			string statsURL = "https://blockchain.info/stats?format=json";
			string stats = MakeAPIRequest (statsURL);

			//formatting
			stats = stats.Replace (",", ",\n");
			stats = stats.Replace ("{", "{\n");
			stats = stats.Replace ("}", "\n}");
			return stats;
		}

		public Int64 GetTotalBTC () 
		{
			string totalSatoshiURL = "https://blockchain.info/q/totalbc";
			Int64 totalBtc = Int64.Parse (MakeAPIRequest(totalSatoshiURL)) / 100000000;
			return totalBtc;
		}
			
		public float TimeTillNextBlock () 
		{
			string etaURL = "https://blockchain.info/q/eta";
			float eta = float.Parse (MakeAPIRequest (etaURL));
			return eta; // in seconds
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

