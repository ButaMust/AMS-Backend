using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Building  : BaseEntity
    {
        public required User Owner { get; set; }
    }
}