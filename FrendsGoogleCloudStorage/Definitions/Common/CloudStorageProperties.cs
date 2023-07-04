using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions.Common
{
    /// <summary>
    /// Cloud Storage related properties.
    /// </summary>
    public class CloudStorageProperties
    {
        /// <summary>
        /// Bucket's name where object is being stored in Cloud Storage.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "Text")]
        public string BucketName { get; set; }
    }
}

