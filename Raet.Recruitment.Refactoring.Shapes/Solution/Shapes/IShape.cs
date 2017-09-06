namespace Refactoring.Shapes.Solution.Shapes
{
    public interface IShape
    {
        double Width { get; }

        double Area { get; set; }

        double Perimeter { get; set; }


        

        void UpdateMeasures();
    }
}
