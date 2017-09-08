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

        public void Add(GrouppedShapes grouppedShapes)
        {
            _instance.Add(grouppedShapes);
        }

        public bool HasShapeIn<T>() where T : IBasicShape => _instance.Any(ShapeInList<T>());        

        public bool HasShapeIn(IBasicShape basicShape) => _instance.Any(ShapeInList(basicShape));
        
        public GrouppedShapes GetShapeElement<T>() where T : IBasicShape => _instance.FirstOrDefault(ShapeInList<T>());
        
        public GrouppedShapes GetShapeElement(IBasicShape basicShape) => _instance.FirstOrDefault(ShapeInList(basicShape));        

        public int NumberOf<T>() where T : IBasicShape => GetShapeElement<T>()?.NumberOf ?? 0;

        public int NumberOf(IBasicShape basicShape) => GetShapeElement(basicShape)?.NumberOf ?? 0;        

        public string TextToPrint<T>() where T : IBasicShape => GetShapeElement<T>()?.TextToPrint ?? string.Empty;

        public string TextToPrint(IBasicShape basicShape) => GetShapeElement(basicShape)?.TextToPrint ?? string.Empty;

        private static Func<GrouppedShapes, bool> ShapeInList(IBasicShape basicShape) => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == basicShape.GetType();        

        private static Func<GrouppedShapes, bool> ShapeInList<T>() where T : IBasicShape => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == typeof(T);       
    }
}
