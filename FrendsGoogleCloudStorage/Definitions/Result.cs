using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions
{
    /// <summary>
    /// Task result.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Indicates whether the execution was successful or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Contains the result message.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Message;
    }
}
