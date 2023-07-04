using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions.Common
{
    /// <summary>
    /// Service account authentication specific properties.
    /// </summary>
    public class ServiceAccount
    {
        /// <summary>
        /// Service Account JSON.
        /// </summary>
        [Required]
        [PasswordPropertyText]
        public string ServiceAccountJson { get; set; }
    }
}
