using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Ch6.NewFunction
{
    public class TransactionGate
    {
        public void postEntries(List<Entry> entries)
        {
            foreach (var entry in entries)
            {
                entry.postData();
            }
        }
    }
}