using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UdemyCourse
{
    public class ContainerClass
    {
        public string ClassName;
        public Dictionary<string, string> TypeList = new Dictionary<string, string>();

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"public class {ClassName}");
            output.AppendLine("{");

            foreach (var e in TypeList)
            {
                output.AppendLine("  " + $"public {e.Key} {e.Value}");
            }

            output.Append("}");
            return output.ToString();
        }

        public ContainerClass() { }

        public ContainerClass(string className)
        {
            ClassName = className;
        }
    }

    public class CodeBuilder
    {
        protected ContainerClass container = new ContainerClass(); // this is a reference!

        //public FieldBuilder AddField => new FieldBuilder(container);

        public FieldBuilder AddField(string name, string type)
        {
            FieldBuilder field = new FieldBuilder(container);
            field.AddField(name, type);
            return field;
        }

        public CodeBuilder()
        {

        }

        public CodeBuilder(string className)
        {
            container = new ContainerClass(className);
        }

        //public CodeBuilder(ContainerClass container)
        //{
        //    this.container = container;
        //}

        //public static implicit operator ContainerClass(CodeBuilder cb)
        //{
        //    return cb.container;
        //}
    }


    public class FieldBuilder : CodeBuilder
    {
        public FieldBuilder(ContainerClass container)
        {
            this.container = container;
        }

        public FieldBuilder AddField(string name, string type)
        {
            this.container.TypeList.Add(type, name);
            return this;
        }
    }

    public class Demo
    {
        public static void Main()
        {
            //var dict = new Dictionary<string, string>()
            //{
            //    {"string", "Name" },
            //    {"int", "Age" }
            //};
            //var container = new ContainerClass("Person", dict);
            //WriteLine(container);

            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
