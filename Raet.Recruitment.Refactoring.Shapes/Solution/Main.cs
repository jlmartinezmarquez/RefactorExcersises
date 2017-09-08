using System;
using System.Collections.Generic;
using Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility;
using Refactoring.Shapes.Solution.Patterns.Facade;
using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution
{
    public class Main
    {
        private readonly IFacadeListOfGrouppedShapes _facadeListOfGrouppedShapes;

        public Main(IFacadeListOfGrouppedShapes facadeListOfGrouppedShapes)
        {
            _facadeListOfGrouppedShapes = facadeListOfGrouppedShapes;
        }

        public String Print(List<IBasicShape> shapes)
        {
            if (shapes.Count == 0)
            {
                return ("Empty list of shapes!").Trim();
            }

            foreach (IBasicShape shape in shapes)
            {
                if (!_facadeListOfGrouppedShapes.HasGrouppedShapesInList(shape)) _facadeListOfGrouppedShapes.Add(new GrouppedShapes(shape.GetType()));

                var currentGrouppedShapes = _facadeListOfGrouppedShapes.GetGrouppedShapesElement(shape);

                _facadeListOfGrouppedShapes.ComputeCalculations(currentGrouppedShapes, shape);
            }

            var firstCheckToOrderThePrintedResults = new OrderPrintedResultsMoreSquaresThanCirclesAndTriangles();
            var secondCheckToOrderThePrintedResults = new OrderPrintedResultsMoreTrianglesThanCirclesAndSquares();
            var thirdCheckToOrderThePrintedResults = new OrderPrintedResultsDefault();

            firstCheckToOrderThePrintedResults.SetSuccessor(secondCheckToOrderThePrintedResults);
            secondCheckToOrderThePrintedResults.SetSuccessor(thirdCheckToOrderThePrintedResults);

            return firstCheckToOrderThePrintedResults.OrderPrintedResults(_facadeListOfGrouppedShapes).Trim();
        }
    }
}
