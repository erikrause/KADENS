using MRI.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.Domain.Entities
{
    public class EventLog : Entity
    {
        // TODO: посмотреть альтернативы для записи логов в БД (запись в БД слишком медленная?)
        public string Event { get; protected set; }
        public string Entity { get; protected set; }
        public int UserCreatedId { get; protected set; }
    }
}
