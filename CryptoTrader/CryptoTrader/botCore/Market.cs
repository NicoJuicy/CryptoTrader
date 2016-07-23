/*
	ToDo:
	Methods for executing different types of orders
		e.g. Long, short, market order, stop loss etc
*/

using CryptoTrader.botCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace CryptoTrader
{
	public class Market
	{
		public string exchangeName { get; private set; }
		public double currentPrice { get; set; }
		MarketData data;

		public Market (string name)
		{
			this.exchangeName = name;			
		}

        /*
         * Updates all currencies with the appropriate data from blockchain.
         */
		public void UpdateTicker ()
		{
            Console.WriteLine(exchangeName + ": Updating ticker...");
			string tickerURL = "https://blockchain.info/ticker";
	        string tickerData = MakeAPIRequest(tickerURL);
            tickerData = tickerData.Replace("{", "");
            tickerData = tickerData.Replace("}", "");
            tickerData = tickerData.Replace(" ", "");
            tickerData = tickerData.Replace("\"", "");
            // Regex to split string lines in an array
	        string[] tickerDataLines = Regex.Split(tickerData, "\r\n|\r|\n");
	        // Iterates over all the lines with useful data
	        for (int i = 2; i <= 22; i++)
	        {                
	            // Parse important infomation out
                string type = tickerDataLines[i].Substring(0, 3);     // Gets first 3 chars which will be the type.                
                tickerDataLines[i] = tickerDataLines[i].Substring(4); // Removes data we don't need anymore
                string[] data = tickerDataLines[i].Split(',');
                double ftm = Convert.ToDouble(data[0].Replace("15m:", ""));
                double last = Convert.ToDouble(data[1].Replace("last:", ""));
                double buy = Convert.ToDouble(data[2].Replace("buy:", ""));
                double sell = Convert.ToDouble(data[3].Replace("sell:", ""));
		        string symbol = data[4].Replace("symbol:", "");                             

                // Putting data into the correct Currency object
                foreach (Currency c in Currencies.list)
                {
                    if (c.Type == type)
                    {
                        c.FifteenM = ftm;
                        c.Last = last;
                        c.Buy = buy;
                        c.Sell = sell;
                    }
                }
                // Console.WriteLine(String.Format("type: {0}, 15m: {1}, last: {2}, buy: {3}, sell: {4}, symbol: {5}", type, ftm, last, buy, sell, symbol));                 
	        }
	    Console.WriteLine(exchangeName + ": Ticker updated.");
	}

		public string GetStats ()
		{
			string statsURL = "https://blockchain.info/stats?format=json";
			string stats = MakeAPIRequest (statsURL);

			//formatting
			stats = stats.Replace (",", ",\n");
			stats = stats.Replace ("{", "{\n");
			stats = stats.Replace ("}", "\n}");
			stats = stats.Replace (":", " : ");
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
