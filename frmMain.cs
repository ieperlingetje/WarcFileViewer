using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WARCFileViewer
{
    public partial class frmMain : Form
    {
        private string _sWarcFileLocation = "";
        private List<WarcFileItem> _lstFailedFiles = new List<WarcFileItem>();

        private WarcFileParser _fileparser = null;

        private DataTable _dtResult = new DataTable();

        public frmMain()
        {
            InitializeComponent();
        }

        private void tslFile_Click(object sender, EventArgs e)
        {

        }

        private void tsFileOpen_Click(object sender, EventArgs e)
        {
            OpenWarcFile();
        }


        private void OpenWarcFile()
        {
            OpenFileDialog ofdWarcFile = new OpenFileDialog
            {
                Title = "Open WARC file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "warc",
                Filter = "Web ARChive files (*.warc)|*.warc",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (ofdWarcFile.ShowDialog() == DialogResult.OK)
            {
                _sWarcFileLocation = "";
                _fileparser = null;
                dtgResult.Rows.Clear();
                dtgResult.Columns.Clear();
                _sWarcFileLocation = ofdWarcFile.FileName; 
            }

            if(File.Exists(_sWarcFileLocation))
            {
                _fileparser = new WarcFileParser(_sWarcFileLocation);
                if(_fileparser.IsValidWarcFile())
                {
                    prgProgress.Enabled = true;
                    prgProgress.Visible = true;
                    lblProgressInfo.Visible = true;
                    lblProgressInfo.Text = "Reading WARC file";
                    bgwParseFile.RunWorkerAsync();
                   








                } 
                else
                {
                    MessageBox.Show("The file at " + _sWarcFileLocation + " is not a valid WARC file. The content can not be retrieved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            else
            {
                MessageBox.Show("The file at " + _sWarcFileLocation + " does not exist or is not accessible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void bgwParseFile_DoWork(object sender, DoWorkEventArgs e)
        {
            _fileparser.OnProgress += OnProgress;
            _fileparser.ParseWARCFile();
            _dtResult = new DataTable();
            _dtResult.Columns.Add(new DataColumn("Export",typeof(bool)));
            _dtResult.Columns.Add("URL");
            _dtResult.Columns.Add("MimeType");
            _dtResult.Columns.Add("Date");
            _dtResult.Columns.Add("Filesize");
            int index = 0;
            foreach (WarcFileItem file in _fileparser.GetListOfFiles())
            {
                _dtResult.Rows.Add();

                _dtResult.Rows[index]["URL"] = file.url;
                _dtResult.Rows[index]["MimeType"] = file.MimeType;
                _dtResult.Rows[index]["Date"] = file.RetrievedAt;
                _dtResult.Rows[index]["Filesize"] = WARCFileReaderExtensions.ByteSize(file.FileSize);
                index++;
            }



        }

        private void OnProgress(object sender, WarcFileParserEventArgs e)
        {
            base.Invoke((Action)delegate
            {
                lblProgressInfo.Text = "Loading WARC File: " + Convert.ToString(e.ProgressPercentage) + "% done.";
                prgProgress.Value = (int)e.ProgressPercentage;

            });
        }

        private void bgwParseFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            prgProgress.Enabled = false;
            prgProgress.Visible = false;
            prgProgress.Style = ProgressBarStyle.Continuous;
            lblProgressInfo.Visible = false;

            //MessageBox.Show("Valid WARC File and has " + _fileparser.GetNbrOfFilesInWarcArchive().ToString() + " files.");
            List<WarcFileItem> lstFiles = _fileparser.GetListOfFiles();

            dtgResult.DataSource = _dtResult;

            if(dtgResult.RowCount >= 0)
            {
                UpdatePreviewWindow(0);
            }
        }

        private void dtgResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            UpdatePreviewWindow(e.RowIndex);

        }

        private void dtgResult_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dtgResult_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgResult.RowCount > 2)
            {
                int RowIndex = dtgResult.CurrentRow.Index;
                UpdatePreviewWindow(RowIndex);
            }


        }


        private void UpdatePreviewWindow(int RowIndex)
        {
            if (dtgResult.RowCount > 0 && RowIndex >= 0 && _fileparser != null)
            {
                DataGridViewRow row = dtgResult.Rows[RowIndex];
                string url = row.Cells["URL"].Value.ToString();


                WarcFileItem selectedItem = _fileparser.GetListOfFiles().Find(r => r.url == url);


                if (selectedItem.MimeType == "image/jpeg"
                    || selectedItem.MimeType == "image/gif")
                {
                    pictItem.Visible = true;
                    lblNoPreview.Visible = false;
                    try
                    {
                        byte[] imageData = _fileparser.GetFileData(selectedItem);
                        MemoryStream stream = new MemoryStream(imageData);
                        pictItem.Image = Image.FromStream(stream);
                    } catch {
                        pictItem.Visible = false;
                        lblNoPreview.Visible = true;
                    }


                } else
                {
                    pictItem.Visible = false;
                    lblNoPreview.Visible = true;
                }

                //update info tab
                lblFileInfo.Text = "File name: " + selectedItem.Filename +
                                   "\r\nURL: " + selectedItem.url +
                                   "\r\nFile size: " + WARCFileReaderExtensions.ByteSize(selectedItem.FileSize) +
                                   "\r\nMime type: " + selectedItem.MimeType +
                                   "\r\nDate archived: " + selectedItem.RetrievedAt; 
            }
        }

        private void chbxAll_CheckedChanged(object sender, EventArgs e)
        {
            chbxAudio.Enabled = !chbxAll.Checked;
            chbxImages.Enabled = !chbxAll.Checked;
            chbxVideo.Enabled = !chbxAll.Checked;
            chbxWebpages.Enabled = !chbxAll.Checked;
            chbxCustom.Enabled = !chbxAll.Checked;
            if(chbxCustom.Checked)
            {
                txtCustom.Enabled = !chbxAll.Checked;
            }
        }

        private void ExtractCurrentlySelected()
        {
            int RowIndex = (dtgResult.CurrentRow != null ? dtgResult.CurrentRow.Index : -1);
            if (RowIndex > -1)
            {
                DataGridViewRow row = dtgResult.Rows[RowIndex];
                string url = row.Cells["URL"].Value.ToString();


                WarcFileItem selectedItem = _fileparser.GetListOfFiles().Find(r => r.url == url);

                sfdCurrentFile.Title = "Save file";
                sfdCurrentFile.FileName = selectedItem.Filename;

                if(sfdCurrentFile.ShowDialog() == DialogResult.OK)
                {
                    if (sfdCurrentFile.FileName != "")
                    {

                        SaveFile(selectedItem, sfdCurrentFile.FileName);

                    }
                }
            }
            else
            {
                MessageBox.Show("Can't save file because no file selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExtractAllSelected()
        {
            List<WarcFileItem> lstCheckedItems = new List<WarcFileItem>();
            //get location where files can be saved
            fdbExportLocation.Description = "Select folder where files can be exported to";
            if(fdbExportLocation.ShowDialog() == DialogResult.OK)
            {
                string sOutputFolder = fdbExportLocation.SelectedPath;


                //now get all rows where files where checked
                foreach(DataGridViewRow r in dtgResult.Rows)
                {
                    if (Convert.ToBoolean(r.Cells[0].Value))
                    {
                        string url = r.Cells["URL"].Value.ToString();
                        WarcFileItem selectedItem = _fileparser.GetListOfFiles().Find(o => o.url == url);
                        lstCheckedItems.Add(selectedItem);
                    }
                }
                if(lstCheckedItems.Count > 0)
                {
                    List<Object> lstArguments = new List<Object>();
                    lstArguments.Add(lstCheckedItems);
                    lstArguments.Add(sOutputFolder);
                    lblProgressInfo.Text = "Exporting files: 0% complete";
                    lblProgressInfo.Visible = true;
                    prgProgress.Visible = true;
                    bgwExportItems.RunWorkerAsync(lstArguments);
                }
            }
            




        }

        private void ExtractAll()
        {
            //get location where files can be saved
            fdbExportLocation.Description = "Select folder where files can be exported to";
            if (fdbExportLocation.ShowDialog() == DialogResult.OK)
            {
                string sOutputFolder = fdbExportLocation.SelectedPath;
                if (_fileparser.GetListOfFiles().Count > 0)
                {
                    List<Object> lstArguments = new List<Object>();
                    lstArguments.Add(_fileparser.GetListOfFiles());
                    lstArguments.Add(sOutputFolder);
                    prgProgress.Visible = true;
                    lblProgressInfo.Text = "Exporting files: 0% complete";
                    lblProgressInfo.Visible = true;
                    bgwExportItems.RunWorkerAsync(lstArguments);
                }
            }
        }

        private void ExtractFilesFromList(List<WarcFileItem> lstItems,string sOutputLocation,bool bBackgroundworker = false)
        {
            int iPercentage = 0;
            int iNbrofFiles = lstItems.Count();
            int iCurrent = 0;
            foreach(WarcFileItem item in lstItems)
            {
                string sSite = item.Host;
                string sSaveFolderPath = sOutputLocation + @"\" + sSite + item.FilePath.Replace("/", @"\");
                string sOutputPath = sSaveFolderPath + @"\" + item.Filename;

                if (!Directory.Exists(sSaveFolderPath))
                {
                    Directory.CreateDirectory(sSaveFolderPath);
                    //put savefile statement in the same block so it waits until folder is created
                    SaveFile(item, sOutputPath);
                } 
                else
                {
                    SaveFile(item, sOutputPath);
                }

                //when run form backgroundworker, report progress
                if(bBackgroundworker)
                {
                    iCurrent++;
                    iPercentage = (int)(((double)iCurrent / (double)iNbrofFiles)*100);
                    bgwExportItems.ReportProgress(iPercentage);
                }
            }
        }

        private void SaveFile(WarcFileItem archiveItem,string sFileLocation)
        {
            byte[] rawData = _fileparser.GetFileData(archiveItem);
            bool bIsImage = (archiveItem.MimeType == "image/jpeg" || archiveItem.MimeType == "image/gif");

            if(bIsImage)
            {
                try
                {
                    MemoryStream stream = new MemoryStream(rawData);
                    Image.FromStream(stream).Save(sFileLocation);
                } catch
                {
                    _lstFailedFiles.Add(archiveItem);
                }
            } 
            else
            {
                System.IO.FileStream fs = new FileStream(sFileLocation, FileMode.Create);
                for (int i = 0; i < rawData.Length; i++)
                {
                    fs.WriteByte(rawData[i]);
                }
                fs.Close();
            }

        }

        private void tsExtractCurrenSelect_Click(object sender, EventArgs e)
        {
            ExtractCurrentlySelected();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.S)
            {
                ExtractCurrentlySelected();
            }
        }

        private void tsExtractAllSelected_Click(object sender, EventArgs e)
        {
            ExtractAllSelected();
            
        }

        private void tsExtractAll_Click(object sender, EventArgs e)
        {
            ExtractAll();
            
        }

        private void bgwExportItems_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Object> lstArguments = e.Argument as List<object>;
            List<WarcFileItem> lstFileItems = new List<WarcFileItem>();
            string sOutputFolder = "";
            foreach(Object argument in lstArguments)
            {
                if(argument.GetType() == typeof(List<WarcFileItem>))
                {
                    lstFileItems = (List<WarcFileItem>)argument;
                }

                if(argument.GetType() == typeof(string))
                {
                    sOutputFolder = (string)argument;
                }
            }
            ExtractFilesFromList(lstFileItems, sOutputFolder,true);
        }

        private void bgwExportItems_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("All the items are exported", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            prgProgress.Visible = false;
            lblProgressInfo.Visible = false;
        }

        private void bgwExportItems_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage > 0)
            {
                prgProgress.Value = e.ProgressPercentage;
                lblProgressInfo.Text = "Exporting files: " + e.ProgressPercentage.ToString() +"% complete";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _dtResult.DefaultView.RowFilter = string.Format("URL LIKE '%{0}%'", txtSearch.Text);
        }
    }
}
