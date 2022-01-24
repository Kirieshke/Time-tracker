using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_tracker.Models;

namespace Time_tracker.Repository
{
    interface ITodoRepository
    {
        void Add(Todo todo);
        void Edit(Todo todo);
        void Delete(Todo todo);
        void Save();
    }
}