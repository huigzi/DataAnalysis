using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis.Foundamentation
{
    public class ReadConfigBlock : IReadDataBlock
    {
        public void ReadData(byte[] readbuf, int offset, int length)
        {
            byte[] result = new byte[(int) length];
            Array.Copy(readbuf, offset, result, 0, length);
 
        }
    }
}
