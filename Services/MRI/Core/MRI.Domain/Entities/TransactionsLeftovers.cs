using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class TransactionsLeftovers : Entity
    {
        public int ClinicId { get; protected set; }
        public virtual Clinic Clinic { get; protected set; }
        public int ServiceId { get; protected set; }
        public virtual Service Service { get; protected set; }
        public int TransactionsLeft { get; protected set; }
    }
}
