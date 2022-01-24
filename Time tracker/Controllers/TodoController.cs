using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_tracker.Contexts;
using Time_tracker.Models;
using Time_tracker.Repository;

namespace Time_tracker.Controllers
{
    class TodoController : ITodoRepository
    {
        private readonly TodoDbContext _todoDbContext;
        public TodoController(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
        public void Add(Todo todo)
        {
            _todoDbContext.Todoes.Add(todo);
        }

        public void Delete(Todo todo)
        {
            _todoDbContext.Todoes.Remove(todo);
        }

        public void Edit(Todo todo)
        {
            
        }

        public void Save()
        {
            _todoDbContext.SaveChanges();
        }
    }
}
