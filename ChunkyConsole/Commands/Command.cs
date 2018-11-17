using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChunkyConsole.Commands
{
    public abstract class Command:ICommand
    {
        public string Title { get; set; }
        public abstract void Execute();
    }
}
