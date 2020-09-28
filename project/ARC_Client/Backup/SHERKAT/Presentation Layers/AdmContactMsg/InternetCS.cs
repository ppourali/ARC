using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime ;
using System.Runtime.InteropServices ; 

namespace Mehr
{
    public class InternetCS
    {
        // API declaration
        [DllImport("wininet.dll")]
        public extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        // API using
        public static bool IsConnected()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

    }
}