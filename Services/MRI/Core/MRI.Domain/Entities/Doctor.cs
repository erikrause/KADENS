using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class Doctor : Entity
    {
        public Doctor
            (
            int clinicId,
            int userId,
            string surname,
            string name,
            string patronymic,
            string phone
            )
        {
            ClinicId = clinicId;
            UserId = userId;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Phone = phone;
        }
        public int ClinicId { get; protected set; }
        public virtual Clinic Clinic { get; protected set; }
        public int UserId { get; protected set; }       // TODO: to primary key.
        public virtual User User { get; protected set; }
        public string Surname { get; protected set; }
        public string Name { get; protected set; }
        public string Patronymic { get; protected set; }
        public string Phone { get; protected set; }
        public virtual List<Patient> Patients { get; protected set; }
    }
}
