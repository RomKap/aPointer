using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class Control : MyController
    {
        public MyActionResult CheckResult()
        {
            return MyView();
        }
    }
}
