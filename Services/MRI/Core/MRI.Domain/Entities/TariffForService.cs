using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class TariffForService : Entity
    {
        public int TariffId { get; protected set; }
        public virtual Tariff Tariff { get; protected set; }
        public int ServiceId { get; protected set; }
        public virtual Service Service { get; protected set; }
        public int TransactionsCount { get; protected set; }
    }
}
