using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRW.CommonLibraries.Xml
{
    public interface IXmlData
    {
        void ReadXml(string filePath);

        void WriteXml(string filePath);


    }
}
