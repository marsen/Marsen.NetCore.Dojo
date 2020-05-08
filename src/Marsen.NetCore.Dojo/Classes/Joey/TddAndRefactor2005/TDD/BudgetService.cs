using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005.TDD
{
    public class BudgetService
    {
        private readonly IBudgetRepo _budgetRepo;

        public BudgetService(IBudgetRepo budgetRepo)
        {
            _budgetRepo = budgetRepo;
        }

        public decimal Query(string start, string end)
        {
            return _budgetRepo
                .GetAll()
                .Sum(budget => budget.GetAmount(new Period(start, end)));
        }
    }
}