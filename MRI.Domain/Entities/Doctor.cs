using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Doctor : Entity
    {
        public int ClinicId { get; protected set; }
        public virtual Clinic Clinic { get; protected set; }
        public int UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public string Surname { get; protected set; }
        public string Name { get; protected set; }
        public string Patronymic { get; protected set; }
        public string Phone { get; protected set; }
    }
}
