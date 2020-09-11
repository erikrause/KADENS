using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Inspection : Entity
    {
        public int PatientId { get; protected set; }
        public virtual Patient Patient { get; protected set; }
        public DateTime InspectionDate { get; protected set; }
        // Id МРТ-снимка
        public int MriId { get; protected set; }
        public virtual Mri Mri { get; protected set; }
    }
}
