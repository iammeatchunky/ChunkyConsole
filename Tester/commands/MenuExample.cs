using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// comment from bug 1
namespace Tester.commands
{
    class MenuExample:ChunkyConsole.Commands.MenuCommand
    {
        public MenuExample():base()
        {
            this.Order = ChunkyConsole.Commands.ExecuteOrder.BeforeMenu;
            this.MenuOrder = ChunkyConsole.Commands.MenuOrder.none;
            this.Menu.ExitOnBadSelection = true;
            Add("first maneu item", ConsoleKey.A, A);
            Add("second menu item", ConsoleKey.B, new PromptExample(), B);
        }
        private void A()
        {
            Console.WriteLine("You selected A");
            Console.Read();
        }
        private void B()
        {
            Console.WriteLine("You selected B");
            Console.Read();
        }
        public override void Execute()
        {
            Console.WriteLine("In Execute");
            Console.Read();            
        }
    }
}
