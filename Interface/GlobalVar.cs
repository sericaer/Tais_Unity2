using System;
using System.Collections.Generic;
using System.Text;

namespace Tais
{
    public static class GlobalVar
    {
        public static ((int m, int d) begin, (int m, int d) end) grown_date_range => ((2, 1), (9, 1));
        public static (int y, int m, int d) date { get; set; }
    }
}
