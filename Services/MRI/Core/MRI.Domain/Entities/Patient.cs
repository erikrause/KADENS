using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Patient : Entity
    {
        public Patient
            (
            int doctorId,
            string cardNumber
            )
        {
            DoctorId = doctorId;
            CardNumber = cardNumber;
        }
        // Убрал круговую связь.
        //public int ClinicId { get; protected set; }
        //public virtual Clinic Clinic { get; protected set; }
        public int DoctorId { get; protected set; }
        public virtual Doctor Doctor { get; protected set; }
        public string CardNumber { get; protected set; }
        public virtual List<Inspection> Inspections { get; protected set; }
    }
}
