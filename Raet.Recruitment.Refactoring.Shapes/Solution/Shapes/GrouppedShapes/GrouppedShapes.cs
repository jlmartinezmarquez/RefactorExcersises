using System;

namespace Refactoring.Shapes.Solution.Shapes.GrouppedShapes
{
    public class GrouppedShapes
    {
        public Type TypeOfTheGrouppedShapes { get; }

        public int NumberOf { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }

        public string TextToPrint { get; set; }

        public GrouppedShapes(Type typeOfTheGrouppedShapes)
        {
            NumberOf = 0;
            Area = 0;
            Perimeter = 0;
            TextToPrint = string.Empty;

            TypeOfTheGrouppedShapes = typeOfTheGrouppedShapes;
        }

        public void ComputeCalculations(IBasicShape basicShape)
        {
            NumberOf++;
            Area += basicShape.GetArea();
            Perimeter += basicShape.GetPerimeter();

            var textToPrint = TypeOfTheGrouppedShapes.GetProperty("TextToPrint");
            var textToPrintValue = textToPrint?.GetValue(basicShape).ToString();
            TextToPrint = string.Format(textToPrintValue, NumberOf, Area.ToString("#.##"), Perimeter.ToString("#.##"));
        }
    }
}
