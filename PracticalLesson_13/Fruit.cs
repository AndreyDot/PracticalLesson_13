using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace PracticalLesson_13
{

    [DataContract]
    [KnownType(typeof(Citrus))]
    public class Fruit
    {

        private string _name;
        private string _color;


        [DataMember]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public String Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Fruit() { }

        public Fruit(string name, string color)
        {
            _name = name;
            _color = color;
        }

        public virtual void Input()
        {
            Console.Write("Enter fruit name: ");
            Name = Console.ReadLine();
            Console.Write("Enter fruit color: ");
            Color = Console.ReadLine();
        }

        public virtual void Print()
        {
            Console.WriteLine($"{Name}, {Color}");
        }

        public override string ToString()
        {
            return $"{_name}, {_color}";
        }
    }
}
