namespace Refactoring.Shapes.Solution.Shapes
{
    public interface IBasicShape
    {
        string TextToPrint { get; }

        double GetWidth();

        double GetArea();

        double GetPerimeter();
    }
}
