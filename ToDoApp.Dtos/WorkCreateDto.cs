using System.ComponentModel.DataAnnotations;
using ToDoApp.Dtos.Interfaces;

namespace ToDoApp.Dtos
{
    public class WorkCreateDto: IDto
    {
        //[Required(ErrorMessage ="Definition alanı zorunludur..")]
        public string Definition { get; set; }
        public bool IsComplete { get; set; }
    }
}
