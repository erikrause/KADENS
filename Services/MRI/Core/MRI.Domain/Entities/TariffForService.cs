using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class TariffForService : Entity
    {
        public TariffForService
            (
            int tariffId,
            int serviceId,
            int transactionsCount
            )
        {
            TariffId = tariffId;
            ServiceId = serviceId;
            TransactionsCount = transactionsCount;
        }
        public int TariffId { get; protected set; }
        public virtual Tariff Tariff { get; protected set; }
        public int ServiceId { get; protected set; }
        public virtual Service Service { get; protected set; }
        public int TransactionsCount { get; protected set; }
    }
}
