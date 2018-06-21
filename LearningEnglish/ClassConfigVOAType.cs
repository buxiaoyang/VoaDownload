using System;
using System.Collections.Generic;
using System.Text;

namespace VOA
{
    class ClassConfigVOAType
    {
        private string typeName;

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        private string typeURL;

        public string TypeURL
        {
            get { return typeURL; }
            set { typeURL = value; }
        }

        private string typeCategory;

        public string TypeCategory
        {
            get { return typeCategory; }
            set { typeCategory = value; }
        }

        private Boolean tpyeIsDownload;

        public Boolean TpyeIsDownload
        {
            get { return tpyeIsDownload; }
            set { tpyeIsDownload = value; }
        }
    }
}
