using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.TableItems;

namespace ZeroAutomation
{
    public static class Extensions
    {
        public static string NameTrimmed(this TableCell cell)
        {
            return cell.Name.Split(new string[] { " Row" }, StringSplitOptions.None)[0];
        }
    }
}
