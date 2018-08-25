using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis.Foundamentation
{
    public class ReadDataDescription : IReadDescription
    {
        public UInt16 Id { get; set; }
        public UInt16 Version { get; set; }
        public UInt32 BlockLength { get; set; }

        public void ReadData(byte[] readbuf, int offset1)
        {
            int offset = offset1;

            Id = BitConverter.ToUInt16(readbuf, offset);
            offset += 2;
            Version = BitConverter.ToUInt16(readbuf, offset);
            offset += 2;
            BlockLength = BitConverter.ToUInt32(readbuf, offset);
        }
    }
}
