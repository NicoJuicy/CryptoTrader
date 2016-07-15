using System;

namespace cryptoTrader {

    public static float globalCash;

    enum Currencies { BITCOIN, LITECOIN, ETHEREUM, GBP, EUR, USD };

    class Market {
        public float currentPrice;

        public float getMarketPrice (currency, exchange) { return currentPrice; }
    }

    class Currency {
        string name;
        float price;

        float convert (newCurrency) {}
    }

    class Trade {
        float boughtPrice; // exchange rate
        float newPrice;
        float calculateProfit () { return profit; }
    }

    class Trader {
        float cash;

        void buy ( currency, exchange ) { return errorCode; }
        void sell ( currency, exchange ) { return errorCode; }

        Market market = new Market ();
        x = market.getMarketPrice(currency, exchange);
    }

    class Neuron {
        list<MarketData> data;

        void set () {}
        void learn () {}
    }

    class BrainPart {
        void set () {}
        void learn () {}
    }

    class MarketData {
        // import and export to xml/json
        // and visualise
        void drawChart () {}
        void import () {}
        void export () {}
    }

    int main (void) {

    }
}
