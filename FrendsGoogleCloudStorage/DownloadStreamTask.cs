using FrendsGoogleCloudStorage.Definitions;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("FrendsGoogleCloudStorageTest")]

namespace FrendsGoogleCloudStorage
{
    public class DownloadStreamTask
    {
        /// <summary>
        /// This task fetches object from Google Cloud Storage and stores it into a Stream.
        /// </summary>
        /// <param name="objectDetails">Details of the downloadable object.</param>
        /// <param name="authentication">Authentication details.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>StreamResult -object.</returns>
        public static Task<StreamResult> DownloadStream([PropertyTab] ObjectDetails objectDetails, [PropertyTab] Authentication authentication, CancellationToken cancellationToken)
        {
            var storageClient = StorageClient.Create(GoogleCredential.FromJson(authentication.ServiceAccount.ServiceAccountJson));
            return OpenDownloadStream(storageClient, objectDetails, cancellationToken);
        }

        internal static async Task<StreamResult> OpenDownloadStream(StorageClient storageClient, ObjectDetails objectDetails, CancellationToken cancellationToken)
        {
            var stream = new MemoryStream();
            
            try
            {
                await storageClient.DownloadObjectAsync(objectDetails.BucketName, objectDetails.ObjectName, stream);
            }
            catch (Exception e)
            {
                return new StreamResult
                {
                    Success = false,
                    Message = e.Message,
                    Stream = null
                };
            }

            var output = new StreamResult
            {
                Success = true,
                Message = $"Downloaded {objectDetails.ObjectName} into a Stream.",
                Stream = stream
            };

            return output;
        }
    }
}
