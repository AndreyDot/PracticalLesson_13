using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticalLesson_13
{
    [DataContract]
    public class Citrus : Fruit
    {
        private int _vitaminC;

        public Citrus() { }

        public Citrus(string name, string color, int vitaminC) : base(name, color)
        {
            _vitaminC = vitaminC;
        }

        [DataMember]
        public int VitaminC
        {
            get { return _vitaminC; }
            set { _vitaminC = value; }
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Enter Vitamin C in grams: ");
            VitaminC = int.Parse(Console.ReadLine());
        }
        public override void Print()
        {
            Console.WriteLine($"{Name}, {Color}, {VitaminC} grams");
        }

    }
}
