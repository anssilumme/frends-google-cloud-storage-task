using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FrendsGoogleCloudStorage.Definitions.Common;
using FrendsGoogleCloudStorage.Definitions.File;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

[assembly: InternalsVisibleTo("FrendsGoogleCloudStorageTest")]

namespace FrendsGoogleCloudStorage
{
    public class DownloadFileTaskTask
    {
        /// <summary>
        /// This Task fetches object from Google Cloud Storage.
        /// </summary>
        /// <param name="properties">Properties of the downloadable object.</param>
        /// <param name="destination">Details of the object's destination.</param>
        /// <param name="authentication">Authentication details.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>{string Message} </returns>
        public static Task<Google.Apis.Storage.v1.Data.Object> DownloadFile([PropertyTab] Definitions.File.CloudStorageProperties properties, [PropertyTab] Destination destination, [PropertyTab] Authentication authentication, CancellationToken cancellationToken)
        {
            var storageClient = StorageClient.Create(GoogleCredential.FromJson(authentication.ServiceAccount.ServiceAccountJson));
            return DownloadObject(storageClient, properties, destination, cancellationToken);
        }

        internal static async Task<Google.Apis.Storage.v1.Data.Object> DownloadObject(StorageClient storageClient, Definitions.File.CloudStorageProperties properties, Destination destination, CancellationToken cancellationToken)
        {
            try
            {
                if (!Directory.Exists(destination.Path))
                {
                    if (destination.CreateDirectoryIfNotExist)
                    {
                        DirectoryInfo directoryInfo = Directory.CreateDirectory(destination.Path);
                    }
                    else if (destination.ThrowExceptionIfDirectoryNotExistAndNotCreated)
                    {
                        throw new DirectoryNotFoundException($"Directory not found: {destination.Path}");
                    }
                    else
                    {
                        throw new DirectoryNotFoundException($"Directory does not exist.");
                    }
                }
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }

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
            return await storageClient.DownloadObjectAsync(properties.BucketName, properties.ObjectName, outputFile, null, cancellationToken);
        }
    }
}
