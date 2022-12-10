using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WARCFileViewer
{
    class WarcFileItem
    {
        public string url = "";
        public string Filename = "";
        public string FilePath = "";
        public string MimeType = "";
        public long FileSize = 0;
        public string HttpHeaders = "";
        public string FileContent = "";
        public string RetrievedAt = "";
        public string Host = "";

        public long WarcFileStartPosition = 0;
        public long WarcFileEndPosition = 0;
    }
}
