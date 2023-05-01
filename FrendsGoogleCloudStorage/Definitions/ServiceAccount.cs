﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions
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
        [DisplayFormat(DataFormatString = "Json")]
        public string ServiceAccountJson { get; set; }
    }
}
