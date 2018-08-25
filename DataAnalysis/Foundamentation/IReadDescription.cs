using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis.Foundamentation
{
    public interface IReadDescription
    {
        void ReadData(byte[] readbuf, int offset);
    }
}
