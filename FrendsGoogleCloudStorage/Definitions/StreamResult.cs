using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions
{
    /// <summary>
    /// DownloadStream -task result.
    /// </summary>
    public class StreamResult : Result
    {
        /// <summary>
        /// Contains the downloaded object as a Stream.
        /// </summary>
        public Stream Stream { get; set; }
    }
}
