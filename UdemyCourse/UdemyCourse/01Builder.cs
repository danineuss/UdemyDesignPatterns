using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyCourse
{
    public class Field
    {
        public string Name;
        public string Type;

        public Field(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    public class Class
    {
        public string Name;
        public List<Field> Fields = new List<Field>();

        public Class(string name)
        {
            Name = name;
        }
    }

    public class CodeBuilder
    {
        Class Class;

        public CodeBuilder()
        {

        }

        public CodeBuilder(string name)
        {
            Class = new Class(name);
        }

        public CodeBuilder AddField(string name, string type)
        {
            Class.Fields.Add(new Field(name, type));
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Class.Name}");
            sb.AppendLine("{");
            foreach (var field in Class.Fields)
            {
                sb.AppendLine($"  public {field.Type} {field.Name};");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class Demo
    {
        public static void Main()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
