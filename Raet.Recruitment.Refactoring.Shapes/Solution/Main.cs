using System;
using System.Collections.Generic;
using Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility;
using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution
{
    public static class Main
    {
        public static String Print(List<IBasicShape> shapes)
        {
            if (shapes.Count == 0)
            {
                return ("Empty list of shapes!").Trim();
            }

            var grouppedIShapesByConcreteShape = new EncapsulatedListOfGrouppedShapes(new List<GrouppedShapes>());

            foreach (IBasicShape shape in shapes)
            {
                if (!grouppedIShapesByConcreteShape.HasGrouppedShapesInList(shape)) grouppedIShapesByConcreteShape.Add(new GrouppedShapes(shape.GetType()));

                var currentGrouppedShapes = grouppedIShapesByConcreteShape.GetGrouppedShapesElement(shape);

                currentGrouppedShapes.ComputeCalculations(shape);
            }

            var firstCheckToOrderThePrintedResults = new OrderPrintedResultsMoreSquaresThanCirclesAndTriangles();
            var secondCheckToOrderThePrintedResults = new OrderPrintedResultsMoreTrianglesThanCirclesAndSquares();
            var thirdCheckToOrderThePrintedResults = new OrderPrintedResultsDefault();

            firstCheckToOrderThePrintedResults.SetSuccessor(secondCheckToOrderThePrintedResults);
            secondCheckToOrderThePrintedResults.SetSuccessor(thirdCheckToOrderThePrintedResults);

            return firstCheckToOrderThePrintedResults.OrderPrintedResults(grouppedIShapesByConcreteShape).Trim();
        }
    }
}
