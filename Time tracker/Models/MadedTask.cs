using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_tracker.Models
{
    class MadedTask
    {
        [Key]
        public int MadedTaskId { get; set; }
        public string MadedTaskText { get; set; }
        public string MadedTaskDescription { get; set; }
        public DateTime? MadedTaskDeadline { get; set; }
        public DateTime? MadedTaskStartDate { get; set; }
    }
}
