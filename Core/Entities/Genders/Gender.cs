using Core.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Gender
{
    public class Gender:AuditEntity
    {
        public string Name { get; set; }
    }
}
