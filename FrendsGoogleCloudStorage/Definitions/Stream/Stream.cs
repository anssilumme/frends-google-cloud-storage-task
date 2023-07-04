using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions.Stream
{
    /// <summary>
    /// Stream
    /// </summary>
    public class Stream
    {
        /// <summary>
        /// Acts as both an input and an output when downloading Stream.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "Expression")]
        public System.IO.Stream TargetStream { get; set; }
    }
}
