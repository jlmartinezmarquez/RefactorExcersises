namespace Refactoring.Shapes.Solution.Metrics
{
    public interface IMetrics
    {
        int NumberOf { get; set; }
        int TotalAreas { get; set; }
        int TotalPerimeters { get; set; }

        string ShapeString { get; set; }
    }
}
