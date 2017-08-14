using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayAround
{
    // this is a example of a singleton
    public static class Singleton
    {

        public static int number = 0;

        public static void increment()
        {
            number++;
        }
    }
}
