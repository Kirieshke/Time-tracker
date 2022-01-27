using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_tracker.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public Todo()
        {

        }
        public Todo(string Text)
        {
            this.Text = Text;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
