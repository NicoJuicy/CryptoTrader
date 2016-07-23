using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTrader.botCore
{
    public static class Currencies
    {
        public static Currency USD = new Currency("USD", "$");
        public static Currency ISK = new Currency("ISK","kr");
        public static Currency HKD = new Currency("HKD", "$");
        public static Currency TWD = new Currency("TWD", "NT$");
        public static Currency CHF = new Currency("CHF", "CHF");
        public static Currency EUR = new Currency("EUR", "€");
        public static Currency DKK = new Currency("DKK", "kr");
        public static Currency CLP = new Currency("CLP", "$");
        public static Currency CAD = new Currency("CAD", "$");
        public static Currency CNY = new Currency("CNY", "¥");
        public static Currency THB = new Currency("THB", "฿");
        public static Currency AUD = new Currency("AUD", "$");
        public static Currency SGD = new Currency("SGD", "$");
        public static Currency KRW = new Currency("KRW", "₩");
        public static Currency JPY = new Currency("JPY", "¥");
        public static Currency PLN = new Currency("PLN", "zł");
        public static Currency GBP = new Currency("GBP", "£");
        public static Currency SEK = new Currency("SEK", "kr");
        public static Currency NZD = new Currency("NZD", "$");
        public static Currency BRL = new Currency("BRL", "R$");
        public static Currency RUB = new Currency("RUB", "RUB");

        public static Currency[] list = { USD, ISK, HKD, TWD, CHF, EUR, DKK, CLP, CAD, CNY, THB,
                                          AUD, SGD, KRW, JPY, PLN, GBP, SEK, NZD, BRL, RUB };

        public static void PrintCurrencies(){
            foreach (Currency c in list)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
