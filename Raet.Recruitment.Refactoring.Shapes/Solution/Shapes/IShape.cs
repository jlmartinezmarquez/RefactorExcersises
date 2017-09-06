namespace Refactoring.Shapes.Solution.Shapes
{
    public interface IShape
    {
        string TextToPrint { get; }

        double GetWidth();

        double GetArea();

        double GetPerimeter();
    }
}
