using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions.List
{
    /// <summary>
    /// Cloud Storage related properties.
    /// </summary>
    public class CloudStorageProperties : Common.CloudStorageProperties
    {
        /// <summary>
        /// The prefix to match. Only objects with names that start with this string will be returned. This parameter may be empty, in which case no filtering is performed.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Prefix { get; set; }
    }
}
