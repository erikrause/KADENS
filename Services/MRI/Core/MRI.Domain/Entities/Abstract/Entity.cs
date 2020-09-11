using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities.Abstract
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }
    }
}
