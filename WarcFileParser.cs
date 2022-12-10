using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WARCFileViewer
{
    class WarcFileParserEventArgs : EventArgs
    {
        public decimal ProgressPercentage { get; set; }
    }

    class WarcFileParser
    {
        public event EventHandler<WarcFileParserEventArgs> OnProgress;

        private string _sWarcFileLocation = "";
        private int _iNbrOfFilesInArchive = 0;
        private List<WarcFileItem> _lstWarcFileItesms = new List<WarcFileItem>();

        private WarcFileItem _currentFile = null;

        public WarcFileParser(string sFilePath)
        {
            
            if (File.Exists(sFilePath)) {
                _sWarcFileLocation = sFilePath;
            }
        }


        public bool IsValidWarcFile()
        {
            bool bResult = false;
            System.IO.StreamReader file = new System.IO.StreamReader(_sWarcFileLocation);
            string sLinecontent = file.ReadLine();
            //very basic check, just check if it starts with a specific string
            if (sLinecontent.StartsWith("WARC/1.0"))
            {
                bResult = true;
            }


            return bResult;
        }

        public void ParseWARCFile()
        {
            int iLineCounter = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(_sWarcFileLocation);
            bool bAtWarcBlock, bAtWarcRequest, bAtWarcResponse, bAtHttpBlock, bAttHttpBody;
            bAtWarcBlock = bAtWarcRequest = bAtWarcResponse = bAtHttpBlock = bAttHttpBody = false;
            long filesize = new System.IO.FileInfo(_sWarcFileLocation).Length;
            decimal dLastProgressPercentage = 0;
            using (StreamReader sr = new StreamReader(_sWarcFileLocation))
            {
                string slineOfContent;
                long lPositionAtLastRead = 0;
                bool bPassedFirstContentLengthYet = false;
                while ((slineOfContent = sr.ReadLine()) != null)
                {
                   



                    //nbr of files is  given at content-length (line 8). Counter is zero based, so substract 1
                    if(bPassedFirstContentLengthYet == false && slineOfContent.StartsWith("Content-Length"))
                    {
                        _iNbrOfFilesInArchive = GetNbrOfFilesInWarcArchive(slineOfContent);
                        bPassedFirstContentLengthYet = true;
                    }

                    //this block is for when we know the nbr of files, 
                    //from here we can start making a list of the files
                    if (_iNbrOfFilesInArchive > 0)
                    {
                        //check if we are at new file
                        if (slineOfContent.StartsWith("WARC/1.0"))
                        {
                            if (_currentFile != null && _currentFile.WarcFileStartPosition > 0)
                            {
                                _currentFile.WarcFileEndPosition = lPositionAtLastRead;
                            }
                        }


                        if (slineOfContent.StartsWith("WARC-Type: response"))
                        {
                            bAtWarcBlock = true;
                            bAtHttpBlock = false;
                            //if we are at start of new file,
                            //add previous object to list and create new object
                            if (_currentFile != null)
                            {
                                //if we can't fetch filesize from header, calculate
                                if(_currentFile.FileSize == 0)
                                {
                                    _currentFile.FileSize = _currentFile.WarcFileEndPosition - _currentFile.WarcFileStartPosition;
                                }
                                //if no filename, rename to index.html
                                if(_currentFile.Filename.Length == 0)
                                {
                                    _currentFile.Filename = "index.html";
                                }

                                _lstWarcFileItesms.Add(_currentFile);
                                decimal dProgressPercentage = Math.Round(Convert.ToDecimal(((decimal)lPositionAtLastRead / (decimal)filesize) * 100), 2);
                                if (dLastProgressPercentage != dProgressPercentage && OnProgress != null)
                                {
                                    OnProgress(this, new WarcFileParserEventArgs { ProgressPercentage = dProgressPercentage });
                                }
                                dLastProgressPercentage = dProgressPercentage;
                            }
                            _currentFile = new WarcFileItem();
                        }

                        if (slineOfContent.StartsWith("HTTP/"))
                        {
                            bAtWarcBlock = false;
                            bAtHttpBlock = true;
                            bAttHttpBody = false;
                        }

                        //now that we know if we are at warc or http block,
                        //parse lines

                        //this is for when we are at warc block
                        if (bAtWarcBlock)
                        {
                            //determine if we are at the warc block for a request or a response
                            if (slineOfContent == "WARC-Type: request")
                            {
                                bAtWarcRequest = true;
                                bAtWarcResponse = false;
                            }

                            if (slineOfContent == "WARC-Type: response")
                            {
                                bAtWarcRequest = false;
                                bAtWarcResponse = true;
                            }


                            //now that we know where we are, start extracting data
                            //get the url
                            if (bAtWarcResponse && slineOfContent.StartsWith("WARC-Target-URI"))
                            {
                                string sUrl = slineOfContent.Replace("WARC-Target-URI: ", "");
                                sUrl = sUrl.Replace("<", "");
                                sUrl = sUrl.Replace(">", "");
                                
                                Uri uri = new Uri(sUrl);
                                _currentFile.Filename = System.IO.Path.GetFileName(sUrl);


                                //for files in the form of index.php?foobar, strip arguments from urls
                                if (_currentFile.Filename.Contains("?"))
                                {
                                    int index = _currentFile.Filename.IndexOf("?");
                                    _currentFile.Filename = ConverToSimplePath(_currentFile.Filename.Substring(0, index));
                                }




                                //store filepath to have export location later
                                _currentFile.FilePath = ConverToSimplePath(uri.AbsolutePath.Replace("/" + _currentFile.Filename, ""));



                                _currentFile.url = sUrl;
                                _currentFile.Host = uri.Host;
                            }

                            //get the date
                            if (bAtWarcResponse && slineOfContent.StartsWith("WARC-Date:"))
                            {
                                string sDateLine = slineOfContent.Replace("WARC-Date: ", "");
                                _currentFile.RetrievedAt = sDateLine;
                            }



                        }

                        //put everything for http data
                        if (bAtHttpBlock)
                        {
                            //get the mimetype
                            if (bAttHttpBody == false && slineOfContent.ToLower().StartsWith("content-type:"))
                            {
                                string sMimeType = slineOfContent.ToLower().Replace("content-type:", "");
                                _currentFile.MimeType = sMimeType.Trim();
                            }

                            if(bAttHttpBody == false && slineOfContent.ToLower().StartsWith("content-length:"))
                            {
                                _currentFile.FileSize = Convert.ToInt64(slineOfContent.ToLower().Replace("content-length:", "").Trim());
                            }


                            //HTTP Body part, set start of file location here
                            if (bAttHttpBody == false && slineOfContent == "")
                            {
                                bAttHttpBody = true;
                                _currentFile.WarcFileStartPosition = sr.GetPosition();
                            }
                        }








                    }


                    iLineCounter++;
                    lPositionAtLastRead = sr.GetPosition();

                }
                //add last file to list
                _lstWarcFileItesms.Add(_currentFile);
            }





        }


        public List<WarcFileItem> GetListOfFiles()
        {
            return _lstWarcFileItesms;
        }

        public int GetNbrOfFilesInWarcArchive()
        {
            return _iNbrOfFilesInArchive;
        }


        private int GetNbrOfFilesInWarcArchive(string sLine)
        {
            if(sLine.StartsWith("Content-Length: "))
            {
                return Convert.ToInt32(sLine.Replace("Content-Length: ", ""));
            }
            return 0;
        }

        public byte[] GetFileData(WarcFileItem fileitem)
        {
                using (FileStream fs = new FileStream(_sWarcFileLocation, FileMode.Open, FileAccess.Read))
                {
                    fs.Seek(fileitem.WarcFileStartPosition, SeekOrigin.Begin);

                    byte[] b = new byte[(fileitem.WarcFileEndPosition - fileitem.WarcFileStartPosition)];
                    fs.Read(b, 0, (int)(b.Length));
                    fs.Close();

                return b;
                }
         
        }

        private string ConverToSimplePath(string input)
        {
            return input.Replace("(", "").Replace(")", "").Replace(":","").Replace("=","");
        }

    }
}
