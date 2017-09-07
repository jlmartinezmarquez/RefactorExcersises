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

        private static Func<GrouppedShapes, bool> ShapeInList(IBasicShape basicShape) => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == basicShape.GetType();

        public bool HasShapeIn(IBasicShape basicShape)
        {
            return _instance.Any(ShapeInList(basicShape));
        }

        public GrouppedShapes GetShapeElement(IBasicShape basicShape)
        {
            return _instance.FirstOrDefault(ShapeInList(basicShape));
        }

        public void Add(GrouppedShapes grouppedShapes)
        {
            _instance.Add(grouppedShapes);
        }

        public int NumberOf(IBasicShape basicShape)
        {
            var element = GetShapeElement(basicShape);

            return element?.NumberOf ?? 0;
        }
    }
}
