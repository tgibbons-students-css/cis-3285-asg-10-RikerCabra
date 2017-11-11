using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader.AdoNet
{
    public class AsyncTradeStorage : ITradeStorage
    {
        private ITradeStorage syncTradeStorage;
        private readonly ILogger logger;

        public AsyncTradeStorage(ILogger logger)
        {
            this.logger = logger;
            syncTradeStorage = new AdoNetTradeStorage(logger);
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            logger.LogInfo("Starting sync trade storage");
            syncTradeStorage.Persist(trades);
        }
    }
}
