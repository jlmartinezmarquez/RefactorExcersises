using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Shapes.Solution.Shapes.GrouppedShapes
{
    public class EncapsulatedListOfGrouppedShapes
    {
        private readonly List<GrouppedShapes> _instance;

        public EncapsulatedListOfGrouppedShapes(List<GrouppedShapes> instance)
        {
            _instance = instance;
        }

        private static Func<GrouppedShapes, bool> ShapeInList(IShape shape) => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == shape.GetType();

        public bool HasShapeIn(IShape shape)
        {
            return _instance.Any(ShapeInList(shape));
        }

        public GrouppedShapes GetShapeElement(IShape shape)
        {
            return _instance.FirstOrDefault(ShapeInList(shape));
        }

        public void Add(GrouppedShapes grouppedShapes)
        {
            _instance.Add(grouppedShapes);
        }
    }
}
