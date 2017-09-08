using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution.Patterns.Facade
{
    public class FacadeListOfGrouppedShapes : IFacadeListOfGrouppedShapes
    {
        private readonly List<GrouppedShapes> _instance;

        public FacadeListOfGrouppedShapes(List<GrouppedShapes> instance)
        {
            _instance = instance;
        }

        public void Add(GrouppedShapes grouppedShapes)
        {
            _instance.Add(grouppedShapes);
        }

        public bool HasGrouppedShapesInList(IBasicShape basicShape) => _instance.Any(GrouppedShapesInList(basicShape));
        
        public GrouppedShapes GetGrouppedShapesElement(IBasicShape basicShape) => _instance.FirstOrDefault(GrouppedShapesInList(basicShape));        

        public int NumberOf<T>() where T : IBasicShape => GetGrouppedShapesElement<T>()?.NumberOf ?? 0;

        public string TextToPrint<T>() where T : IBasicShape => GetGrouppedShapesElement<T>()?.TextToPrint ?? string.Empty;

        public void ComputeCalculations(GrouppedShapes grouppedShapes, IBasicShape basicShape)
        {
            grouppedShapes.ComputeCalculations(basicShape);
        }

        private GrouppedShapes GetGrouppedShapesElement<T>() where T : IBasicShape => _instance.FirstOrDefault(GrouppedShapesInList<T>());

        private static Func<GrouppedShapes, bool> GrouppedShapesInList(IBasicShape basicShape) => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == basicShape.GetType();        

        private static Func<GrouppedShapes, bool> GrouppedShapesInList<T>() where T : IBasicShape => grouppedShapes => grouppedShapes.TypeOfTheGrouppedShapes == typeof(T);       
    }
}
