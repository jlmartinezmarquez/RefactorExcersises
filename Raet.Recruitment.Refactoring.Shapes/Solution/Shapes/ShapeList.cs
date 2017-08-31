using System.Collections.Generic;

namespace Refactoring.Shapes.Solution.Models
{
    public class ShapeList : IShapeList
    {
        private readonly List<Shape> _list;

        public ShapeList(List<Shape> list)
        {
            _list = list;
        }

        public Metrics GetMetricsFor(IShape shape)
        {
            foreach (var element in _list)
            {
                
            }
        }
    }

    public interface IShapeList
    {

    }
}
