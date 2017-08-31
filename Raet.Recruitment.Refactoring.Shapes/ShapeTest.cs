using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refactoring.Shapes
{
    [TestClass()]
    public class ShapeTest
    {
        private List<Shape> _shapes;

        [TestInitialize]
        public void Initialize()
        {
            _shapes = new List<Shape>();
        }

        [TestMethod]
        public void givenEmptyList_whenPrint_thenReturnEmptyMessage()
        {
            Assert.AreEqual("Empty list of shapes!", Shape.Print(_shapes));
        }

        [TestMethod]
        public void givenOneSquare_whenPrint_thenReturnShapePrint()
        {
            _shapes.Add(new Shape(Shape.SQUARE, 2));
            Assert.AreEqual("Squares: 1, Area: 4, Perimeter: 8.", Shape.Print(_shapes));
        }

        [TestMethod]
        public void givenOneShapePerType_whenPrint_thenReturnOrderedShapesPrint()
        {
            _shapes.Add(new Shape(Shape.TRIANGLE, 3));
            _shapes.Add(new Shape(Shape.SQUARE, 1));
            _shapes.Add(new Shape(Shape.CIRCLE, 2));
            Assert.AreEqual("Squares: 1, Area: 1, Perimeter: 4.\nCircles: 1, Area: 3.14, Perimeter: 6.28.\nTriangles: 1, Area: 3.9, Perimeter: 9.", Shape.Print(_shapes));
        }

        [TestMethod]
        public void givenMultipleShapes_whenPrint_thenReturnOrderedSumShapesPrint()
        {
            _shapes.Add(new Shape(Shape.SQUARE, 1));
            _shapes.Add(new Shape(Shape.TRIANGLE, 8));
            _shapes.Add(new Shape(Shape.CIRCLE, 2));
            _shapes.Add(new Shape(Shape.TRIANGLE, 3));
            _shapes.Add(new Shape(Shape.CIRCLE, 4));
            _shapes.Add(new Shape(Shape.CIRCLE, 2));
            _shapes.Add(new Shape(Shape.CIRCLE, 3));
            _shapes.Add(new Shape(Shape.SQUARE, 3));
            _shapes.Add(new Shape(Shape.TRIANGLE, 1));
            Assert.AreEqual("Circles: 4, Area: 25.92, Perimeter: 34.56.\nTriangles: 3, Area: 32.04, Perimeter: 36.\nSquares: 2, Area: 10, Perimeter: 16.", Shape.Print(_shapes));
        }
    }
}
