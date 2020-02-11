using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum ToolState
    {
        Destroyed = -3,
        Worse = -2,
        SlightlyWorse = -1,
        Same = 0,
        Better = 1
    }
}
