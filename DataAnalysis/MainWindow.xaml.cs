using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAnalysis.Foundamentation;

namespace DataAnalysis
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<UInt16, IReadDataBlock> _readDataBlockDictionary;
        private readonly ReadConfigBlock _readConfigDataBlock;
        private readonly ReadScanInfoBlock _readScanInfo;
        private byte[] _dataBuf = null;

        private long _count = 0;

        public MainWindow()
        {
            _readDataBlockDictionary = new Dictionary<ushort, IReadDataBlock>();
            _readConfigDataBlock = new ReadConfigBlock();
            _readScanInfo = new ReadScanInfoBlock();

            _readDataBlockDictionary.Add(0x0460, _readConfigDataBlock);
        
            _readDataBlockDictionary.Add(0x04ef, _readScanInfo);

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = ""
            };

            var result = openFileDialog.ShowDialog();

            if (result == false)
            {
                return;
            }

            FileStream file = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);

            var filecount = file.Length;

            byte[] readBuf = new byte[filecount];
           

            BinaryReader binaryReader = new BinaryReader(file);

            binaryReader.Read(readBuf, 0, (int) filecount);

            ReadRecordHeaderDescription readRecordHeader = new ReadRecordHeaderDescription();
            ReadDataDescription readDataDescription = new ReadDataDescription();


            while (_count < filecount)
            {
                readRecordHeader.ReadData(readBuf, (int)_count);

                _dataBuf = new byte[readRecordHeader.RecordLength];
                Array.Copy(readBuf, _count+24, _dataBuf, 0, readRecordHeader.RecordLength);

                long dataCount = 0;

                while (dataCount < readRecordHeader.RecordLength - readRecordHeader.BlockLength)
                {
                    readDataDescription.ReadData(_dataBuf, (int)dataCount);

                    if (readDataDescription.Id == 0x04ef)
                    {
                        _readDataBlockDictionary[readDataDescription.Id]
                            .ReadData(_dataBuf, (int) dataCount, (int) readDataDescription.BlockLength);
                    }

                    dataCount += readDataDescription.BlockLength;
                }

                _dataBuf = null;

                _count += readRecordHeader.RecordLength;

            }
        }
    }
}
