#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrendsGoogleCloudStorage
{
    public enum AuthenticationType { ServiceAccount };
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

    public class DestinationDetails
    {
        /// <summary>
        /// Path where object would be stored.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "Text")]
        public string Path { get; set; }

        /// <summary>
        /// Name of the object.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "Text")]
        public string Name { get; set; }
    }

    public class Authentication
    {
        [DefaultValue(AuthenticationType.ServiceAccount)]
        public AuthenticationType AuthenticationType { get; set; }

        /// <summary>
        /// Service account authentication specific properties.
        /// </summary>
        [UIHint(nameof(AuthenticationType), "", AuthenticationType.ServiceAccount)]
        public ServiceAccountAuthentication ServiceAccount { get; set; }
    }

    /// <summary>
    /// Service account authentication specific properties.
    /// </summary>
    public class ServiceAccountAuthentication
    {
        [Required]
        [DisplayFormat(DataFormatString = "Json")]
        public string ServiceAccountJson { get; set; }
    }

    public class Result
    {
        /// <summary>
        /// Contains the result message.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string Message;
    }
}
