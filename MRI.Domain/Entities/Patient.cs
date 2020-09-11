using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Patient : Entity
    {
        // Убра круговую связь.
        //public int ClinicId { get; protected set; }
        //public virtual Clinic Clinic { get; protected set; }
        public int DockerId { get; protected set; }
        public virtual Doctor Doctor { get; protected set; }
        public string CardNumber { get; protected set; }
        public virtual List<Inspection> Inspections { get; protected set; }
    }
}
