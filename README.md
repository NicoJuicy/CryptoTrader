# CryptoTrader
A neural crypto trader

                  Class Diagram

          Neuron              -- Decision maker
            |
            |
        Brain Part            -- Holds Neurons
            |
            |
          Trader              -- Hold Brain Parts & makes trades & views market
            |   \
            |    |
          Trade  |            -- Executes a buy or sell
            |    |
            |   /
          Market              -- Interacts with the blockchain API and sends data to market data class
          /     \
         /       \
    Currency      |           -- Holds info about the currency being traded
                Market Data   -- Interacts with Database & generates charts
                
