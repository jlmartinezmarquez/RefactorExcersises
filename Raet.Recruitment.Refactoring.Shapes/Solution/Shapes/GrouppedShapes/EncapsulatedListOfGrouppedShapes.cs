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

        public bool HasGrouppedShapesInList(IBasicShape basicShape) => _instance.Any(GrouppedShapesInList(basicShape));
        
        public GrouppedShapes GetGrouppedShapesElement<T>() where T : IBasicShape => _instance.FirstOrDefault(GrouppedShapesInList<T>());
        
        public GrouppedShapes GetGrouppedShapesElement(IBasicShape basicShape) => _instance.FirstOrDefault(GrouppedShapesInList(basicShape));        

        public int NumberOf<T>() where T : IBasicShape => GetGrouppedShapesElement<T>()?.NumberOf ?? 0;

        public string TextToPrint<T>() where T : IBasicShape => GetGrouppedShapesElement<T>()?.TextToPrint ?? string.Empty;

        private static Func<GrouppedShapes, bool> GrouppedShapesInList(IBasicShape basicShape) => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == basicShape.GetType();        

        private static Func<GrouppedShapes, bool> GrouppedShapesInList<T>() where T : IBasicShape => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == typeof(T);       
    }
}
