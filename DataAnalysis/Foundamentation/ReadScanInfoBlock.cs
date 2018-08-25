using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis.Foundamentation
{
    public class ReadScanInfoBlock : IReadDataBlock
    {
        public float FScanAzimuthDeg { get; set; }
        public float FScanElevationDeg { get; set; }
        public float FAzimuthRateDps { get; set; }
        public float FElevationRateDps { get; set; }
        public float FTargetAzimuthDeg { get; set; }
        public float FTargetElevationDeg { get; set; }
        public Int32 NScanEnabled { get; set; }
        public Int32 NCurrentIndex { get; set; }
        public Int32 NAcqScanState { get; set; }
        public Int32 NDriveScanState { get; set; }
        public Int32 NAcqDwellState { get; set; }
        public Int32 NScanPatternType { get; set; }
        public UInt32 NValidPos { get; set; }
        public Int32 NSsDoneState { get; set; }
        public UInt32 NErrorFlags { get; set; }

        public void ReadData(byte[] readbuf, int offset, int length)
        {
            int count = 8;
            byte[] result = new byte[(int)length];
            Array.Copy(readbuf, offset, result, 0, length);

            FScanAzimuthDeg = BitConverter.ToSingle(result, count);
            count += 4;

            FScanElevationDeg = BitConverter.ToSingle(result, count);
            count += 4;

            FAzimuthRateDps = BitConverter.ToSingle(result, count);
            count += 4;

            FElevationRateDps = BitConverter.ToSingle(result, count);
            count += 4;

            FTargetAzimuthDeg = BitConverter.ToSingle(result, count);
            count += 4;

            FTargetElevationDeg = BitConverter.ToSingle(result, count);
            count += 4;


        }
    }
}
