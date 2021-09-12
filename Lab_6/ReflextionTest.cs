using System;
namespace Lab_6
{
    public class ReflextionTest
    {
        public ReflextionTest() { }

        public ReflextionTest(string model)
        {
            Model = model;
        }

        public ReflextionTest(string model, string color)
        {
            Color = color;
            Model = model;
        }

        public ReflextionTest(string model, string color, int cost)
        {
            Color = color;
            Model = model;
            Cost = cost;
        }

        [NewAttribute("The color of a car")]
        public string Color { get; set; } = "";

        [NewAttribute("The model of a car")]
        public string Model { get; set; } = "";

        public int Cost { get; set; } = 0;

        public string Description()
        {
            string result;
            result = "Model: " + Model + "\nColor:" + Color + "\nCost: " + Cost + "\n";
            return result;
        }

        public void ChangeColor(string color)
        {
            Color = color;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NewAttribute : Attribute
    {
        public NewAttribute() { }
        public NewAttribute(string DescriptionParam)
        {
            Description = DescriptionParam;
        }
        public string Description { get; set; }
    }
}
