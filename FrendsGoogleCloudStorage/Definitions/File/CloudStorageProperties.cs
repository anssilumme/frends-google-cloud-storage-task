using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions.File
{
    /// <summary>
    /// Cloud Storage related properties.
    /// </summary>
    public class CloudStorageProperties : Common.CloudStorageProperties
    {
        /// <summary>
        /// Object's name in Cloud Storage.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "Text")]
        public string ObjectName { get; set; }
    }
}
