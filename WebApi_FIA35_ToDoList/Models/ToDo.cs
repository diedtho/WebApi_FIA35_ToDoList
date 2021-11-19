using System;

namespace WebApi_FIA35_ToDoList.Models
{
    public class ToDo
    {
        public int TDId { get; set; }
        public DateTime Enddatum { get; set; }
        public string Taetigkeit { get; set; }
        public int Prioritaet { get; set; }
        public bool IstFertig { get; set; }
    }
}
