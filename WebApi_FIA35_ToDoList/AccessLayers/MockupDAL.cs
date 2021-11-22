using System;
using System.Collections.Generic;
using System.Linq;
using WebApi_FIA35_ToDoList.Interfaces;
using WebApi_FIA35_ToDoList.Models;

namespace WebApi_FIA35_ToDoList.Data
{
    public class MockupDAL : IData
    {
        List<ToDo> ToDoListe;

        public MockupDAL()
        {
            ToDoListe = new List<ToDo>
            {
                new ToDo {TDId = 1, Enddatum=new DateTime(2021,11,11), Taetigkeit="Einkaufen", Prioritaet=3, IstFertig=false},
                new ToDo {TDId = 1, Enddatum=new DateTime(2021,11,11), Taetigkeit="Wäsche waschen", Prioritaet=4, IstFertig=false}
            };
        }


        public bool DeleteToDo(ToDo todo)
        {
            ToDoListe.Remove(todo);

            return true;
        }

        public int InsertToDo(ToDo todo)
        {
            ToDoListe.Add(todo);

            return 1;
        }

        public List<ToDo> SelectAllToDo()
        {
            return ToDoListe;            
        }

        public List<ToDo> SelectToDoByDate(DateTime start, DateTime end)
        {
            return ToDoListe.FindAll(p => p.Enddatum > start && p.Enddatum < end);
        }

        public ToDo SelectToDoById(int Id)
        {
            return ToDoListe.FirstOrDefault(td => td.TDId == Id);
        }

        public List<ToDo> SelectToDoBySubject(string searchString)
        {            
            return ToDoListe.FindAll(p => p.Taetigkeit.Contains("searchString"));            
        }

        public bool UpdateToDo(ToDo todo)
        {
            ToDo toDoNew = ToDoListe.FirstOrDefault(p => p.TDId == todo.TDId);

            toDoNew.TDId = todo.TDId;
            toDoNew.Enddatum = todo.Enddatum;
            toDoNew.Taetigkeit = todo.Taetigkeit;
            toDoNew.Prioritaet = todo.Prioritaet;
            toDoNew.IstFertig = todo.IstFertig;

            if (ToDoListe.Remove(todo))
            {
                ToDoListe.Add(toDoNew);

                return true;
            }

            return false;

        }
    }
}
