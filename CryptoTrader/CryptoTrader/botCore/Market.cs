/*
	ToDo:
	Methods for executing different types of orders
		e.g. Long, short, market order, stop loss etc
					or maybe put these in Trade class?
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
		public string currentPrice { get; set; }

		public Market () 
		{			
            // Ticker should be updated regularly to keep data up to date.
			UpdateTicker();
		}
		
        /*
         * Updates all currencies with the appropriate data from blockchain.
         */
		public void UpdateTicker ()
		{
            string tickerURL = "https://blockchain.info/ticker";
            string tickerData = MakeAPIRequest(tickerURL);
            
            string debug = tickerData.Split('\n')[2]; //splitting string into lines
            // Console.WriteLine(debug);
            // Regex to split string into lines
            var tickerDataLines = Regex.Split(tickerData, "\r\n|\r|\n");
            // Iterates over all the lines with useful data
            for (int i = 2; i <= 22; i++)
            {
                // Parse important infomation out
                Console.WriteLine(tickerDataLines[i]);
            }
            /*
             * Once we get data from JSON string we can put the data into the respective fields for each currency.
             */
            
            
            // Kept serialization stuff incase we want use it still
            //JavaScriptSerializer data = new JavaScriptSerializer ();
            //data.Deserialize<string> (tickerData); // ?? no idea what im doing here ??				
		}

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

