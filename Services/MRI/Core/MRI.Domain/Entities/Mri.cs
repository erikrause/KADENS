using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Mri : Entity
    {
        // TODO: отделить в MongoDB.
        public string StrogaeKey { get; protected set; }
        public virtual Inspection Inspection { get; protected set; }
    }
}
