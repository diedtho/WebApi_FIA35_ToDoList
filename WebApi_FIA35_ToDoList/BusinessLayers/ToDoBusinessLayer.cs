using System;
using System.Collections.Generic;
using WebApi_FIA35_ToDoList.Interfaces;
using WebApi_FIA35_ToDoList.Models;

namespace WebApi_FIA35_ToDoList.AccessLayers
{
    public class ToDoBusinessLayer
    {
        IData DataAccess;

        // Dependency injection
        public ToDoBusinessLayer(IData DataAccess)

        {
            this.DataAccess = DataAccess;

        }

        public List<ToDo> GetAllToDo()
        {
            return DataAccess.SelectAllToDo();
        }

        public List<ToDo> GetByDate(DateTime start, DateTime end)
        {
            return DataAccess.SelectToDoByDate(start, end);
        }

        public List<ToDo> GetBySubject(string searchString)
        {
            return DataAccess.SelectToDoBySubject(searchString);
        }

        public ToDo GetToDoById(int Id)
        {
            return DataAccess.SelectToDoById(Id);
        }

        public int AddToDo(ToDo toDo)
        {
            return DataAccess.InsertToDo(toDo);
        }

        public bool UpdateToDo(ToDo toDo)
        {
            return DataAccess.UpdateToDo(toDo);
        }

        public bool DeleteToDo(ToDo toDo)
        {
            return DataAccess.DeleteToDo(toDo);
        }

    }
}
