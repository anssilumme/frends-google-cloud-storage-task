using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions
{
    /// <summary>
    /// Details of the object.
    /// </summary>
    public class ObjectDetails
    {
        /// <summary>
        /// Bucket's name where object is being stored in Cloud Storage.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "Text")]
        public string BucketName { get; set; }

        /// <summary>
        /// Object's name in Cloud Storage.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "Text")]
        public string ObjectName { get; set; }
    }
}
