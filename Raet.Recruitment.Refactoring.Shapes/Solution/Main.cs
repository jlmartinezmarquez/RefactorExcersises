using System;
using System.Collections.Generic;
using Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility;
using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution
{
    public class Main
    {
        private readonly IEncapsulatedListOfGrouppedShapes _encapsulatedListOfGrouppedShapes;

        public Main(IEncapsulatedListOfGrouppedShapes encapsulatedListOfGrouppedShapes)
        {
            _encapsulatedListOfGrouppedShapes = encapsulatedListOfGrouppedShapes;
        }

        public String Print(List<IBasicShape> shapes)
        {
            if (shapes.Count == 0)
            {
                return ("Empty list of shapes!").Trim();
            }

            foreach (IBasicShape shape in shapes)
            {
                if (!_encapsulatedListOfGrouppedShapes.HasGrouppedShapesInList(shape)) _encapsulatedListOfGrouppedShapes.Add(new GrouppedShapes(shape.GetType()));

                var currentGrouppedShapes = _encapsulatedListOfGrouppedShapes.GetGrouppedShapesElement(shape);

                currentGrouppedShapes.ComputeCalculations(shape);
            }

            var firstCheckToOrderThePrintedResults = new OrderPrintedResultsMoreSquaresThanCirclesAndTriangles();
            var secondCheckToOrderThePrintedResults = new OrderPrintedResultsMoreTrianglesThanCirclesAndSquares();
            var thirdCheckToOrderThePrintedResults = new OrderPrintedResultsDefault();

            firstCheckToOrderThePrintedResults.SetSuccessor(secondCheckToOrderThePrintedResults);
            secondCheckToOrderThePrintedResults.SetSuccessor(thirdCheckToOrderThePrintedResults);

            return firstCheckToOrderThePrintedResults.OrderPrintedResults(_encapsulatedListOfGrouppedShapes).Trim();
        }
    }
}
