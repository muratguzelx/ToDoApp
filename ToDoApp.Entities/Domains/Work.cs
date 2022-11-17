using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Entities.Domains
{
    public class Work: BaseEntity
    {
        
        public string Definition { get; set; }
        public bool IsComplete { get; set; }

    }
}
