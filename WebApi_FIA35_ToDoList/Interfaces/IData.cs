using System.Collections.Generic;
using WebApi_FIA35_ToDoList.Models;

namespace WebApi_FIA35_ToDoList.Interfaces
{
    public interface IData
    {
        public List<ToDo> SelectAllToDo();
        public ToDo SelectToDoById(int Id);
        public int InsertToDo(ToDo todo);
        public bool UpdateToDo(ToDo todo);
        public bool DeleteToDo(ToDo todo);

    }
}
