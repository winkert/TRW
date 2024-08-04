using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRW.Apps.TrwAppsBase;
using TRW.GameLibraries.Maps;

namespace TRW.Apps.MapGenerator
{
    public partial class SaveMapDialog : TrwFormBase
    {
        Map _map;
        int _height;
        int _width;
        string _filePath;
        string _fileFormatFilter;

        public SaveMapDialog(Map map)
        {
            InitializeComponent();
            _map = map;
            // populate combobox with image formats enum
            cmbFileFormat.Items.Add(System.Drawing.Imaging.ImageFormat.Bmp);
            cmbFileFormat.Items.Add(System.Drawing.Imaging.ImageFormat.Jpeg);
            cmbFileFormat.Items.Add(System.Drawing.Imaging.ImageFormat.Gif);
            cmbFileFormat.Items.Add(System.Drawing.Imaging.ImageFormat.Png);

            _fileFormatFilter = "BitMap|*.bmp|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
        }

        public string SavedFile => _filePath;

        private bool ValidateSelections()
        {
            bool valid = true;
            // parse ints and verify file is named/matches selected file format
            if (String.IsNullOrEmpty(_filePath))
            {
                errorProvider1.SetError(txtFilePath, "Please select a save path.");
                errorProvider1.SetIconAlignment(txtFilePath, ErrorIconAlignment.MiddleRight);
                valid = false;
            }
            if (!int.TryParse(txtHeight.Text, out _height) && _height <= 0)
            {
                errorProvider1.SetError(txtHeight, "Please specify the image height.");
                errorProvider1.SetIconAlignment(txtHeight, ErrorIconAlignment.MiddleRight);
                valid = false;
            }
            if (!int.TryParse(txtWidth.Text, out _width) && _width <= 0)
            {
                errorProvider1.SetError(txtWidth, "Please specify the image width.");
                errorProvider1.SetIconAlignment(txtWidth, ErrorIconAlignment.MiddleRight);
                valid = false;
            }

            return valid;
        }

        private void SaveImage()
        {
            if (!ValidateSelections())
            {
                return;
            }

            using (Bitmap saveBitmap = MapRenderEngine.DrawMap(_map, _width, _height))
            {
                saveBitmap.Save(_filePath, (System.Drawing.Imaging.ImageFormat)cmbFileFormat.SelectedItem);
            }


        }

        private void SetFileFormatFromExtension(string extension)
        {
            switch (extension)
            {
                case ".bmp":
                    cmbFileFormat.SelectedItem = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
                case ".jpeg":
                    cmbFileFormat.SelectedItem = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;
                case ".gif":
                    cmbFileFormat.SelectedItem = System.Drawing.Imaging.ImageFormat.Gif;
                    break;
                case ".png":
                    cmbFileFormat.SelectedItem = System.Drawing.Imaging.ImageFormat.Png;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            // check the selected file format and act accordingly
            if (SaveFile(_fileFormatFilter, out _filePath))
            {
                txtFilePath.Text = _filePath;
                SetFileFormatFromExtension(System.IO.Path.GetExtension(_filePath));
            }
        }

        private void cmbFileFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // change filename extension
            System.Drawing.Imaging.ImageFormat format = cmbFileFormat.SelectedItem as System.Drawing.Imaging.ImageFormat;
            if (format == System.Drawing.Imaging.ImageFormat.Bmp)
            {
                _fileFormatFilter = "BitMap|*.bmp";
                if(!string.IsNullOrWhiteSpace(_filePath))
                {
                    System.IO.Path.ChangeExtension(_filePath, ".bmp");
                }
            }
            else if (format == System.Drawing.Imaging.ImageFormat.Jpeg)
            {
                _fileFormatFilter = "JPEG|*.jpeg";
                if (!string.IsNullOrWhiteSpace(_filePath))
                {
                    System.IO.Path.ChangeExtension(_filePath, ".jpeg");
                }
            }
            else if (format == System.Drawing.Imaging.ImageFormat.Gif)
            {
                _fileFormatFilter = "GIF|*.gif";
                if (!string.IsNullOrWhiteSpace(_filePath))
                {
                    System.IO.Path.ChangeExtension(_filePath, ".gif");
                }
            }
            else if (format == System.Drawing.Imaging.ImageFormat.Png)
            {
                _fileFormatFilter = "PNG|*.png";
                if (!string.IsNullOrWhiteSpace(_filePath))
                {
                    System.IO.Path.ChangeExtension(_filePath, ".png");
                }
            }
            txtFilePath.Text = _filePath;
        }
    }
}
