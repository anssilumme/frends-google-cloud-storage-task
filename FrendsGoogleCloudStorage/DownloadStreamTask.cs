using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("FrendsGoogleCloudStorageTest")]

namespace FrendsGoogleCloudStorage
{
    public class DownloadStreamTask
    {
        /// <summary>
        /// This Task fetches object from Google Cloud Storage into a specified Stream.
        /// </summary>
        /// <param name="properties">Google Cloud Storage related properties.</param>
        /// <param name="stream">Writable Stream.</param>
        /// <param name="authentication">Authentication details.</param>
        /// <param name="options">Options for Download operations. <see href="https://cloud.google.com/dotnet/docs/reference/Google.Cloud.Storage.V1/latest/Google.Cloud.Storage.V1.DownloadObjectOptions">Documentation</see></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<Google.Apis.Storage.v1.Data.Object> DownloadStream([PropertyTab] Definitions.Stream.CloudStorageProperties properties, [PropertyTab] Definitions.Stream.Stream stream, [PropertyTab] Definitions.Common.Authentication authentication, [PropertyTab] DownloadObjectOptions options, CancellationToken cancellationToken)
        {
            var storageClient = StorageClient.Create(GoogleCredential.FromJson(authentication.ServiceAccount.ServiceAccountJson));
            return OpenDownloadStream(storageClient, properties, stream, options, cancellationToken);
        }

        internal static async Task<Google.Apis.Storage.v1.Data.Object> OpenDownloadStream(StorageClient storageClient, Definitions.Stream.CloudStorageProperties properties, Definitions.Stream.Stream stream, DownloadObjectOptions options, CancellationToken cancellationToken)
        {
            if (stream.TargetStream != null && stream.TargetStream.CanWrite)
            {
                return await storageClient.DownloadObjectAsync(properties.BucketName, properties.ObjectName, stream.TargetStream, options, cancellationToken);
            }
            else
            {
                throw new ArgumentException("Given Stream is either null or non-writable.");
            }
        }
    }
}
