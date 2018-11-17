using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChunkyConsole
{
    public class ClassTemplate:Commands.MenuPromptCommand
    {
        public enum prompts { Name, Age,Whatever }

        public int Age { get { return Prompter.Get<int>((int)prompts.Age); } }

        public ClassTemplate()
        {
            foreach (var item in Enum.GetNames(typeof(prompts)))
            {
                Add(item);
            }

            foreach (var mem in ( from m in this.GetType().GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.DeclaredOnly) where !m.Name.StartsWith("get_") select m))
            {

                var newcmd = new Commands.DynamicPrompterCommand(mem, this);
                
                foreach (var par in mem.GetParameters())
                {
                    newcmd.Prompter.Add(new Prompts.PromptItem() { Prompt=par.Name, Validator = Validators.BaseValidator<string>.InstanceByType(par.ParameterType) });
                }

                Add(mem.Name, ConsoleKey.D0 + this.Menu.MenuItems.Count, newcmd);
            }
        }
        public override void Execute()
        {
            Console.WriteLine("Age: is: " + Age);
            Console.WriteLine(Prompter);
            Console.ReadKey();
        }
        public void Dyna_vis(int Dyna_Age, string Dyna_String)
        {
            Console.WriteLine("Age is:" + Dyna_Age);
            Console.WriteLine("str is:" + Dyna_String);
        }

        protected void Dyna_invis()
        {

        }
    }
}
