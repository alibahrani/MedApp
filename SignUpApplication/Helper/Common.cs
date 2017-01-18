using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUpApplication.Helper
{
    class Common
    {
        private static string DB_NAME = "meddb";
        private static string COLLECTION_NAME = "patient";
        public static string API_KEY = "IcTXoX-joep1V9-PJvW3R9Iq3sl2p20y";

        public static string API_DOCUMENTS_LINK = $"https://api.mlab.com/api/1/databases/{DB_NAME}/collections/{COLLECTION_NAME}";
        public static string API_SELECT_DOCUMENTS_LINK = $"https://api.mlab.com/api/1/databases/{DB_NAME}/collections/{COLLECTION_NAME}?apiKey={API_KEY}";
    }
}
