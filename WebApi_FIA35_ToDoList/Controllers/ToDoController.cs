using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi_FIA35_ToDoList.AccessLayers;
using WebApi_FIA35_ToDoList.Data;
using WebApi_FIA35_ToDoList.Models;

namespace WebApi_FIA35_ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        ToDoBusinessLayer toDoBl;
        public ToDoController()
        {
            //toDoBl = new ToDoBusinessLayer(new MockupDataLayer());
            toDoBl = new ToDoBusinessLayer(new SqlDAL());
        }

        [HttpGet]
        [Route("[controller]/SelectAll")]
        public List<ToDo> GetAllToDo()
        {
            return toDoBl.GetAllToDo();
        }

        [HttpGet]
        [Route("[controller]/SelectById")]
        public ToDo GetToDoById(int Id)
        {
            return toDoBl.GetToDoById(Id);
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public int AddToDo(ToDo toDo)
        {
            return toDoBl.AddToDo(toDo);
        }

        [HttpPut]
        [Route("[controller]/Update")]
        public bool UpdateToDo(ToDo toDo)
        {
            return toDoBl.UpdateToDo(toDo);
        }

        [HttpDelete]
        [Route("[controller]/Delete")]
        public bool DeleteToDo(ToDo toDo)
        {
            return toDoBl.DeleteToDo(toDo);
        }

    }
}
