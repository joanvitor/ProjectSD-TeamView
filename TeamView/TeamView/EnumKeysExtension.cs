using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamView
{
    public static class EnumKeysExtension
    {
        public static string ConvertKeyToString(this Keys keys)
        {
            return $"{{{keys.ToString().ToUpper()}}}";
        }
    }
}
