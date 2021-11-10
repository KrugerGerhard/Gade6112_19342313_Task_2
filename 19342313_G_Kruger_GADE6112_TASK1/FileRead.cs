using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    class FileRead
    {
        public Object ReadData<type>()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }
            string file = openFileDialog.FileName;
            Stream stream = File.Open(file, FileMode.Open);

            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (type)binaryFormatter.Deserialize(stream);
        }
    }
}
