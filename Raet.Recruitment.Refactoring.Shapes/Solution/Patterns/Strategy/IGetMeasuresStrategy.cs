using Refactoring.Shapes.Solution.Shapes;

namespace Refactoring.Shapes.Solution.Patterns.Strategy
{
    public interface IGetMeasuresStrategy
    {
        double GetArea(IShape shape);

        double GetPerimeter(IShape shape);
    }
}
