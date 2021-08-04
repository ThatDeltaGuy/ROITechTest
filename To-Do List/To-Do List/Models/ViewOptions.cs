using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace To_Do_List.Models
{
    [Verb("view", true, HelpText = "Views Tasks")]
    public class ViewOptions
    {
        [Option('c', "complete", Required = false, HelpText = "Sets Returned Tasks To Complete")]
        public bool Complete { get; set; }

        [Option('f', "filter", Required = false, HelpText = "Filters Tasks By Title or Due Date.")]
        public string Filter { get; set; }

        [Option('s', "sort", Required = false, HelpText = "Sort Tasks By Field.")]
        public string Sort { get; set; }
    }
}
