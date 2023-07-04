using FrendsGoogleCloudStorage.Definitions.Common;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("FrendsGoogleCloudStorageTest")]

namespace FrendsGoogleCloudStorage
{
    public class ListObjectsTask
    {
        /// <summary>
        /// This Task fetches list of objects in specified bucket from Google Cloud Storage.
        /// </summary>
        /// <param name="properties">Google Cloud Storage related properties.</param>
        /// <param name="authentication">Authentication details.</param>
        /// <param name="options">Options for ListObjects operations. <see href="https://cloud.google.com/dotnet/docs/reference/Google.Cloud.Storage.V1/latest/Google.Cloud.Storage.V1.ListObjectsOptions">Documentation</see></param>
        /// <param name="cancellationToken"></param>
        /// <returns>An asynchronous sequence of objects in the specified bucket.</returns>
        public static Task<IAsyncEnumerable<Google.Apis.Storage.v1.Data.Object>> ListObjects([PropertyTab] Definitions.List.CloudStorageProperties properties, [PropertyTab] Authentication authentication, [PropertyTab] ListObjectsOptions options, CancellationToken cancellationToken)
        {
            var storageClient = StorageClient.Create(GoogleCredential.FromJson(authentication.ServiceAccount.ServiceAccountJson));
            return GetObjectsList(storageClient, properties, options, cancellationToken);
        }

        internal static async Task<IAsyncEnumerable<Google.Apis.Storage.v1.Data.Object>> GetObjectsList(StorageClient storageClient, Definitions.List.CloudStorageProperties properties, ListObjectsOptions options, CancellationToken cancellationToken)
        {
            return storageClient.ListObjectsAsync(properties.BucketName, properties.Prefix, options);
        }
           
    }
}
