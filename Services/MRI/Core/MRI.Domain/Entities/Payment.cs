using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Payment : Entity
    {
        public Payment
            (
            string purpose,
            string bIK,
            string iNN,
            decimal amount,
            int clinicId,
            int operationStatus
            )
        {
            Purpose = purpose;
            BIK = bIK;
            INN = iNN;
            Amount = amount;
            ClinicId = clinicId;
            OperationStatus = operationStatus;
        }
        public string Purpose { get; protected set; }
        public string BIK { get; protected set; }
        public string INN { get; protected set; }
        public decimal Amount { get; protected set; }
        //public DateTime BillDate { get; protected set; }   дубликат, есть в Bill.
        public int ClinicId { get; protected set; }
        public virtual Clinic Clinic { get; protected set; }
        //public int? BillId { get; protected set; }    FK перенес в Bill
        public virtual Bill Bill { get; protected set; }
        // TODO: добавить enum.
        public int OperationStatus { get; protected set; }
    }
}
