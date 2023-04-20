using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

#pragma warning disable 1591

namespace FrendsGoogleCloudStorage
{
    public static class CloudStorageTask
    {
        /// <summary>
        /// This Task fetches object from Google Cloud Storage.
        /// </summary>
        /// <param name="objectDetails">Details of the downloadable object.</param>
        /// <param name="destination">Details of the object's destination.</param>
        /// <param name="authentication">Authentication details.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>{string Message} </returns>
        public static Result GetObject([PropertyTab] ObjectDetails objectDetails, [PropertyTab] DestinationDetails destination, [PropertyTab] Authentication authentication, CancellationToken cancellationToken)
        {

            
            var storageClient = StorageClient.Create(GoogleCredential.FromJson(authentication.ServiceAccount.ServiceAccountJson));

            var stringBuilder = new StringBuilder(destination.Path);

            if (destination.Path.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                stringBuilder.Append(destination.Name);
            }
            else
            {
                stringBuilder.Append(Path.DirectorySeparatorChar).Append(destination.Name);
            }

            var destinationPath = stringBuilder.ToString();
            
            using var outputFile = File.OpenWrite(destinationPath);

            storageClient.DownloadObject(objectDetails.BucketName, objectDetails.ObjectName, outputFile);

            var output = new Result
            {
                Message = $"Downloaded {objectDetails.ObjectName} to {destinationPath}."
            };

            return output;
        }
    }
}
