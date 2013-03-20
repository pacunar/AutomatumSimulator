#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace AutomatumSimulator
{
    public class Class1
    {
        public int counter;
        public Class1()
        {
            counter++;
        }

        public void addCounter()
        {
            counter++;
        }

        public int getCounter()
        {
            return counter;
        }
    }
}
