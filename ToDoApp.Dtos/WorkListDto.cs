using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dtos.Interfaces;

namespace ToDoApp.Dtos
{
    public class WorkListDto: IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsComplete { get; set; }
    }
}
