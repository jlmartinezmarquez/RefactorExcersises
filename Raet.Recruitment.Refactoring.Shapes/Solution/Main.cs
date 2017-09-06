using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution
{
    public class Main
    {
        public String Print(List<Shape> shapes)
        {
            if (shapes.Count == 0)
            {
                return ("Empty list of shapes!").Trim();
            }

            var grouppedIShapesByConcreteShape = new List<IGrouppedShapes>();

            foreach (IShape shape in shapes)
            {
                if (!HasShapeInList(grouppedIShapesByConcreteShape, shape)) grouppedIShapesByConcreteShape.Add(new GrouppedShapes(shape));

                var currentGrouppedShapes = GetShapeFromList(grouppedIShapesByConcreteShape, shape);

                currentGrouppedShapes.ComputeCalculations();
            }


        }

        private static Func<IGrouppedShapes, bool> ShapeInList(IShape shape) => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == shape.GetType();

        private bool HasShapeInList(List<IGrouppedShapes> listOfGrouppedShapes, IShape shape)
        {
            return listOfGrouppedShapes.Any(ShapeInList(shape));
        }

        private IGrouppedShapes GetShapeFromList(List<IGrouppedShapes> listOfGrouppedShapes, IShape shape)
        {
            return listOfGrouppedShapes.FirstOrDefault(ShapeInList(shape));
        }
    }
}
