using MRI.Domain.Entities.Abstract;
using System.Collections.Generic;

namespace MRI.Domain.Entities
{
    public class Tariff : Entity
    {
        public ulong RequestsCount { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public bool IsEnabled { get; protected set; }
        public string Description { get; protected set; }
        public int Duration { get; protected set; }
        public virtual List<ClinicTariff> ClinicTariffs { get; protected set; }
        public virtual List<TariffForService> TariffsForService { get; protected set; }
    }
}