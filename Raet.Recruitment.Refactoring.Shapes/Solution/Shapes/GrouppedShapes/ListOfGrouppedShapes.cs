using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Shapes.Solution.Shapes.GrouppedShapes
{
    public class ListOfGrouppedShapes
    {
        private readonly List<IGrouppedShapes> _instance;

        public ListOfGrouppedShapes(List<IGrouppedShapes> instance)
        {
            _instance = instance;
        }

        private static Func<IGrouppedShapes, bool> ShapeInList(IShape shape) => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == shape.GetType();

        public bool HasShapeIn(IShape shape)
        {
            return _instance.Any(ShapeInList(shape));
        }

        public IGrouppedShapes GetShapeElement(IShape shape)
        {
            return _instance.FirstOrDefault(ShapeInList(shape));
        }

        public void Add(IGrouppedShapes grouppedShapes)
        {
            _instance.Add(grouppedShapes);
        }
    }
}
