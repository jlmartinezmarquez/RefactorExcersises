using System;
using System.Collections.Generic;
using Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility;
using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution.Patterns.Facade
{
    public static class ShapeFacade
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
                if (!grouppedIShapesByConcreteShape.HasShapeIn(shape)) grouppedIShapesByConcreteShape.Add(new GrouppedShapes(shape));

                var currentGrouppedShapes = grouppedIShapesByConcreteShape.GetShapeElement(shape);

                currentGrouppedShapes.ComputeCalculations();
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
