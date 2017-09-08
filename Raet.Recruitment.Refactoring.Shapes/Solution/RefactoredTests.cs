using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Shapes.Solution.Patterns.Facade;
using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution
{
    [TestClass()]
    public class RefactoredTests
    {
        private List<IBasicShape> _shapes;

        private IFacadeListOfGrouppedShapes _grouppedIShapesByConcreteShape;

        private Main _main;

        [TestInitialize]
        public void Initialize()
        {
            _shapes = new List<IBasicShape>();
            _grouppedIShapesByConcreteShape = new FacadeListOfGrouppedShapes(new List<GrouppedShapes>());
            _main = new Main(_grouppedIShapesByConcreteShape);
        }

        [TestMethod]
        public void givenEmptyList_whenPrint_thenReturnEmptyMessage()
        {
            Assert.AreEqual("Empty list of shapes!", _main.Print(_shapes));
        }

        [TestMethod]
        public void givenOneSquare_whenPrint_thenReturnShapePrint()
        {
            _shapes.Add(new Square(2));
            Assert.AreEqual("Squares: 1, Area: 4, Perimeter: 8.", _main.Print(_shapes));
        }

        [TestMethod]
        public void givenOneShapePerType_whenPrint_thenReturnOrderedShapesPrint()
        {
            _shapes.Add(new Triangle(3));
            _shapes.Add(new Square(1));
            _shapes.Add(new Circle(2));
            Assert.AreEqual("Squares: 1, Area: 1, Perimeter: 4.\nCircles: 1, Area: 3.14, Perimeter: 6.28.\nTriangles: 1, Area: 3.9, Perimeter: 9.", _main.Print(_shapes));
        }

        [TestMethod]
        public void givenMultipleShapes_whenPrint_thenReturnOrderedSumShapesPrint()
        {
            _shapes.Add(new Square(1));
            _shapes.Add(new Triangle(8));
            _shapes.Add(new Circle(2));
            _shapes.Add(new Triangle(3));
            _shapes.Add(new Circle(4));
            _shapes.Add(new Circle(2));
            _shapes.Add(new Circle(3));
            _shapes.Add(new Square(3));
            _shapes.Add(new Triangle(1));
            Assert.AreEqual("Circles: 4, Area: 25.92, Perimeter: 34.56.\nTriangles: 3, Area: 32.04, Perimeter: 36.\nSquares: 2, Area: 10, Perimeter: 16.", _main.Print(_shapes));
        }
    }
}
