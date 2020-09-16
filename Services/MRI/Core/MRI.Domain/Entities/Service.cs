using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Service : Entity
    {
        public Service
            (
            string name,
            string description,
            decimal priceForTransaction
            )
        {
            Name = name;
            Description = description;
            PriceForTransaction = priceForTransaction;
        }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        // было double.
        public decimal PriceForTransaction { get; protected set; }
        public virtual List<TransactionsLeftovers> TransactionsLeftovers { get; protected set; }
        public virtual List<TariffForService> TariffForServices { get; protected set; }
    }
}
