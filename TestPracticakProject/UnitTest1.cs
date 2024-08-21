using System;
using PracticalLesson_13;
using System.IO;

namespace TestPracticakProject
{
    [TestClass]
    public class FruitTests
    {
        [TestMethod]
        public void TestFruitCtor()
        {
            string name = "Apple";
            string color = "Green";

            Fruit fruit = new Fruit(name, color);

            Assert.AreEqual(name, fruit.Name);
            Assert.AreEqual(color, fruit.Color);
        }

        [TestMethod]
        public void TestFruitInput()
        {
            string name = "Apple";
            string color = "Green";
            var fruit = new Fruit();

            using (var input = new StringWriter())
            {
                Console.SetOut(input);
                using (var inputStream = new StringReader($"{name}\n{color}\n"))
                {
                    Console.SetIn(inputStream);
                    fruit.Input();
                }
            }

            Assert.AreEqual(name, fruit.Name);
            Assert.AreEqual(color, fruit.Color);
        }

        [TestMethod]
        public void TestFruitPrint()
        {
            string name = "Apple";
            string color = "Green";
            var fruit = new Fruit(name, color);

            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                fruit.Print();

                string result = output.ToString().Trim();
                Assert.AreEqual($"{name}, {color}", result);
            }
        }
    }

    [TestClass]
    public class CitrusTest
    {
        [TestMethod]
        public void TestCitrusCtor()
        {
            string name = "Lemon";
            string color = "Yellow";
            int vitaminC = 30;

            Citrus citrus = new Citrus(name, color, vitaminC);

            Assert.AreEqual(name, citrus.Name);
            Assert.AreEqual(color, citrus.Color);
            Assert.AreEqual(vitaminC, citrus.VitaminC);
        }
        
    }
}
