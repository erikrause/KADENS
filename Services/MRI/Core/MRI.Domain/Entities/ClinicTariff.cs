using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class ClinicTariff : Entity
    {
        public int TariffId { get; protected set; }
        public virtual Tariff Tariff { get; protected set; }
        ///////public int ClinicId { get; protected set; }
        public virtual Clinic Clinic { get; protected set; }
        public DateTime DateStart { get; protected set; }
        public DateTime DateEnd { get; protected set; }
    }
}
