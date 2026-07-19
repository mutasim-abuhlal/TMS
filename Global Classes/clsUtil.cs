using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace TMS.Global_Classes
{
    internal class clsUtil
    {
        private static string _GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        private static string _AddExtentionToGeneratedGUID(string SourceFile)
        {
            FileInfo fi = new FileInfo(SourceFile);

            return _GenerateGUID() + fi.Extension;
        }

        private static bool _CreateFolderImagesWhenItIsntExist(string FolderPath)
        {
            try
            {
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong while creating images folder","Cannot Create Folder",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool CopyImageToFolderImages(ref string SourcePath)
        {
            string FolderPath = @"C:\TMS-People-Images";

            if (!_CreateFolderImagesWhenItIsntExist(FolderPath))
                return false;

            try
            {
                if (File.Exists(SourcePath))
                {
                    string DestPath = _AddExtentionToGeneratedGUID(SourcePath);
                    string FullDestPath = Path.Combine(FolderPath, DestPath);

                    File.Copy(SourcePath, FullDestPath);

                    SourcePath = FullDestPath;
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                MessageBox.Show("Something went wrong while copying a file","Cannot copy",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

           
        }
    }
}
