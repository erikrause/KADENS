﻿using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Clinic : Entity
    {
        public Clinic
            (
            string name,
            string contactAddress,
            string phone,
            string bIK,
            string iNN
            )
        {
            Name = name;
            ContactAddress = contactAddress;
            Phone = phone;
            BIK = bIK;
            INN = iNN;
        }
        public string Name { get; protected set; }
        public string ContactAddress { get; protected set; }
        public string Phone { get; protected set; }
        public string BIK { get; protected set; }
        public string INN { get; protected set; }
        public virtual ClinicTariff ClinicTariff { get; protected set; }
        // TODO: check for lazy loading.
        // TODO: protected set to List.
        public virtual List<Payment> Payments { get; protected set; }
        public virtual List<TransactionsLeftovers> TransactionsLeftovers { get; protected set; }
        public virtual List<Doctor> Doctors { get; protected set; }
    }
}