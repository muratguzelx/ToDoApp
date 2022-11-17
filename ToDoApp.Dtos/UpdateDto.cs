using System.ComponentModel.DataAnnotations;
using ToDoApp.Dtos.Interfaces;

namespace ToDoApp.Dtos
{
    public class UpdateDto: IDto
    {
        //[Range(1,int.MaxValue,ErrorMessage = "İd alanı bıoş olamaz")]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Definition Gereklidir...")]
        public string Definition { get; set; }
        public bool IsComplete { get; set; }
    }
}
