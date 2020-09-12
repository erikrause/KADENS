using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Bill : Entity
    {
        public Bill
            (
            int id,
            int billNumber,
            DateTime billDate,
            DateTime paymentDate,
            bool isPayed,
            string statusDescription,
            decimal amount,
            int billStatus
            )
        {
            Id = id;
            BillNumber = billNumber;
            BillDate = billDate;
            PaymentDate = paymentDate;
            IsPayed = isPayed;
            StatusDescription = statusDescription;
            Amount = amount;
            BillStatus = billStatus;
        }
        public int BillNumber { get; protected set; }
        public virtual Payment Payment { get; protected set; }
        public DateTime BillDate { get; protected set; }
        public DateTime PaymentDate { get; protected set; }
        public bool IsPayed { get; protected set; }
        public string StatusDescription { get; protected set; }
        public decimal Amount { get; protected set; }
        public int BillStatus { get; protected set; }
    }
}
