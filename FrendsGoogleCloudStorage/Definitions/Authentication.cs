using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace FrendsGoogleCloudStorage.Definitions
{
    /// <summary>
    /// Contains references to available authentication methods.
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// Authentication method.
        /// </summary>
        [DefaultValue(AuthenticationMethod.ServiceAccount)]
        public AuthenticationMethod AuthenticationMethod { get; set; }

        /// <summary>
        /// Service account authentication specific properties.
        /// </summary>
        [UIHint(nameof(AuthenticationMethod), "", AuthenticationMethod.ServiceAccount)]
        public ServiceAccount ServiceAccount { get; set; }
    }
}
