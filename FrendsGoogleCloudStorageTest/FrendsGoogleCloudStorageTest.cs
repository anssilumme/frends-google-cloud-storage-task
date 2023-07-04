using FrendsGoogleCloudStorage.Definitions.Common;
using FrendsGoogleCloudStorage.Definitions.File;

namespace FrendsGoogleCloudStorageTest
{
    public class FrendsGoogleCloudStorageTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly StorageClient _mockStorageClient;
        private readonly FrendsGoogleCloudStorage.Definitions.File.CloudStorageProperties _properties;
        private Destination _destination;
        private readonly CancellationToken _cancellationToken;

        public FrendsGoogleCloudStorageTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _mockStorageClient = Substitute.ForPartsOf<StorageClient>();
            _properties = new FrendsGoogleCloudStorage.Definitions.File.CloudStorageProperties
            {
                BucketName = "TestBucketName",
                ObjectName = "TestObjectName"
            };
            _destination = new Destination
            {
                Path = Path.Join(Environment.CurrentDirectory, "TestDirectory", "CreatedDirectory"),
                CreateDirectoryIfNotExist = true,
                Name = "TempName.txt"
            };
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public void DownloadObject_WithCreateNewObjectIfNotExistTrue_FileCreated()
        {
            _destination.Name = "DownloadObject_WithCreateNewObjectIfNotExistTrue_FileCreated.txt";

            _mockStorageClient.When(x => x.DownloadObjectAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<FileStream>(), null, Arg.Any<CancellationToken>())).Do(callInfo =>
            {
                _outputHelper.WriteLine("Substituting object download.");
                WriteTestContent(callInfo.Arg<FileStream>(), "Test content from DownloadObject_WithCreateNewObjectIfNotExistTrue_FileCreated.");
            });
            DownloadFileTaskTask.DownloadObject(_mockStorageClient, _properties, _destination, _cancellationToken);

            _outputHelper.WriteLine($"Output path: {_destination.Path}.");
            _outputHelper.WriteLine($"Output filename: {_destination.Name}.");
            Assert.True(Directory.Exists(_destination.Path));
            Assert.True(File.Exists(Path.Combine(_destination.Path, _destination.Name)));
        }

        [Fact]
        public void DownloadObject_WithCreateNewObjectIfNotExistFalse_FileNotCreated()
        {
            _destination.Name = "DownloadObject_WithCreateNewObjectIfNotExistFalse_FileNotCreated.txt";
            _destination.Path = Path.Combine(_destination.Path, "DownloadObject_WithCreateNewObjectIfNotExistFalse_FileNotCreated");
            _destination.CreateDirectoryIfNotExist = false;

            _mockStorageClient.When(x => x.DownloadObjectAsync(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<FileStream>(), null, Arg.Any<CancellationToken>())).Do(callInfo =>
            {
                _outputHelper.WriteLine("Substituting object download.");
                WriteTestContent(callInfo.Arg<FileStream>(), "Test content from DownloadObject_WithCreateNewObjectIfNotExistFalse_FileNotCreated. This content should not exist.");
            });        
            var result = DownloadFileTaskTask.DownloadObject(_mockStorageClient, _properties, _destination, _cancellationToken);

            _outputHelper.WriteLine($"Output path: {_destination.Path}.");
            _outputHelper.WriteLine($"Output filename: {_destination.Name}.");
            Assert.False(Directory.Exists(_destination.Path));
            Assert.False(File.Exists(Path.Combine(_destination.Path, _destination.Name)));
        }

        internal void WriteTestContent(FileStream fileStream, string content)
        {
            byte[] contentBytes = new UTF8Encoding(true).GetBytes(content);
            fileStream.Write(contentBytes, 0, contentBytes.Length);
            fileStream.Close();
            _outputHelper.WriteLine("File write complete.");
        }
    }
}