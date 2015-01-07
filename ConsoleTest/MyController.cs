using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class MyController
    {

        protected internal MyViewResult MyView()
        {
            MyViewResult mvr = new MyViewResult();
            return mvr;
        }
    }
}
