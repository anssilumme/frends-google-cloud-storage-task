using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions
{
    /// <summary>
    /// Contains information where downloaded object should be stored
    /// </summary>
    public class Destination
    {
        /// <summary>
        /// Path where object would be stored.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "Text")]
        public string Path { get; set; }

        /// <summary>
        /// Flag whether to create directory if given directory does not exist.
        /// </summary>
        [Required]
        [DefaultValue(false)]
        public bool CreateDirectoryIfNotExist { get; set; }

        /// <summary>
        /// Flag whether to throw DirectoryNotFoundException if given directory does not exist.
        /// </summary>
        [Required]
        [DefaultValue(false)]
        [UIHint("Throw exception if directory does not exist and is chosen not to create one.")]
        public bool ThrowExceptionIfDirectoryNotExistAndNotCreated { get; set; }

        /// <summary>
        /// Name of the object.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "Text")]
        public string Name { get; set; }
    }
}
