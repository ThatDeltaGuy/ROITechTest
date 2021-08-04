using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace To_Do_List.Models
{
    public class Task : ITask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }

        public static Task FromCsv(string csvLine, int index)
        {
            string[] values = csvLine.Split(',');
            Task task = new Task();
            task.Id = index;
            task.Title = values[0];
            task.Date = Convert.ToDateTime(values[1]);
            task.Description = values[2];
            task.Completed = Convert.ToBoolean(values[3]);
            return task;
        }
    }
}
