using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swtGlossarSortierer
{
    class EntryCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            x = x.Replace(" ", "");
            y = y.Replace(" ", "");
            if(x == null || y == null) MessageBox.Show("there is a null in there somewhere","ERROR");
            else
            {
                return x.ToLower().CompareTo(y.ToLower());
            }
            return 0;
        }
    }
}
