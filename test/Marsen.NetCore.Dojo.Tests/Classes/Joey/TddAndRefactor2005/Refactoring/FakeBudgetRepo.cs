using System.Collections.Generic;
using Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005
{
    public class FakeBudgetRepo : IBudgetRepo
    {
        private List<Budget> _budgetList;

        public List<Budget> GetAll()
        {
            return _budgetList;
        }

        public void SetBudgets(List<Budget> budgets)
        {
            _budgetList = budgets;
        }
    }
}