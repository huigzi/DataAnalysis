using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis.Foundamentation
{
    public class ReadRecordHeaderDescription : IReadDescription
    {
        public UInt16 Id { get; set; }
        public UInt16 Version { get; set; }
        public UInt32 BlockLength { get; set; }
        public UInt32 RecordLength { get; set; }
        public UInt16 Year { get; set; }
        public Byte Month { get; set; }
        public Byte DayofMonth { get; set; }
        public UInt16 Hour { get; set; }
        public Byte Minute { get; set; }
        public Byte Second { get; set; }
        public UInt32 NanoSecond { get; set; }


        public void ReadData(byte[] readbuf, int offsetl)
        {
            int offset = offsetl;

            Id = BitConverter.ToUInt16(readbuf, offset);
            offset += 2;
            Version = BitConverter.ToUInt16(readbuf, offset);
            offset += 2;
            BlockLength = BitConverter.ToUInt32(readbuf, offset);
            offset += 4;
            RecordLength = BitConverter.ToUInt32(readbuf, offset);
            offset += 4;
            Year = BitConverter.ToUInt16(readbuf, offset);
            offset += 2;
            Month = readbuf[offset];
            offset += 1;
            DayofMonth = readbuf[offset];
            offset += 1;
            Hour = BitConverter.ToUInt16(readbuf, offset);
            offset += 2;
            Minute = readbuf[offset];
            offset += 1;
            Second = readbuf[offset];
            offset += 1;
            NanoSecond = BitConverter.ToUInt32(readbuf, offset);

        }
    }
}
