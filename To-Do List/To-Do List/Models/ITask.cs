using System;
using System.Collections.Generic;
using System.Text;

namespace To_Do_List.Models
{
    public interface ITask
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
