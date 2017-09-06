using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility
{
    public abstract class OrderPrintedResultsChainOfResponsibility
    {
        protected OrderPrintedResultsChainOfResponsibility Succcessor;

        public abstract void SetSuccessor(OrderPrintedResultsChainOfResponsibility succcessor);

        public abstract string OrderPrintedResults(EncapsulatedListOfGrouppedShapes encapsulatedListOfGrouppedShapes);
    }
}
