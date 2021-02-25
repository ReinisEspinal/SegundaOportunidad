using System;
using System.Collections.Generic;
using System.Text;

namespace SegundaOportunidad.Domain.BaseEntity
{
    public class BaseEntities
    {
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UserMod { get; set; }
        public DateTime? MoodifyDate { get; set; }

        public BaseEntities()
        {
            this.CreationDate = DateTime.Now;

        }

    }
}
