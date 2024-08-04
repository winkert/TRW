using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TRW.CommonLibraries.Serialization;

namespace TRW.CommonLibraries.Audio.Streaming
{
    public abstract class AudioReader : FileReader
    {
        public AudioReader(string sourceFile)
            : base(sourceFile) 
        { }

        /// <summary>
        /// Goes through the file and writes out the bytes as int\char
        /// </summary>
        /// <returns></returns>
        public string Test()
        {
            StringBuilder builder = new StringBuilder();

            while(true)
            {
                char c = ReadNextChar(out byte byteVal, out bool endOfFile);
                if (endOfFile)
                    break;

                builder.AppendLine($"{byteVal}\t{c}");
            }

            return builder.ToString();
        }

        public abstract AudioDetails GetDetails();
        
    }

}
