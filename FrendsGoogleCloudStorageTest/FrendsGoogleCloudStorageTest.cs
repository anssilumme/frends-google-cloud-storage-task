namespace FrendsGoogleCloudStorageTest
{
    public class FrendsGoogleCloudStorageTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly StorageClient _mockStorageClient;
        private readonly ObjectDetails _objectDetails;
        private Destination _destination;
        private readonly CancellationToken _cancellationToken;

        public FrendsGoogleCloudStorageTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _mockStorageClient = Substitute.ForPartsOf<StorageClient>();
            _objectDetails = new ObjectDetails
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
        public async void DownloadObject_WithCreateNewObjectIfNotExistTrue_FileCreated()
        {
            _mockStorageClient.When(x => x.DownloadObjectAsync(default, default, default, null, default)).Do(callInfo =>
            {
                WriteTestContent(callInfo.Arg<FileStream>(), "Test content from DownloadObject_WithCreateNewObjectIfNotExistTrue_FileCreated.");
            });
            _destination.Name = "DownloadObject_WithCreateNewObjectIfNotExistTrue_FileCreated.txt";
            await CloudStorageTask.DownloadObject(_mockStorageClient, _objectDetails, _destination, _cancellationToken);

            _outputHelper.WriteLine($"Output path: {_destination.Path}.");
            _outputHelper.WriteLine($"Output filename: {_destination.Name}.");
            Assert.True(Directory.Exists(_destination.Path));
            Assert.True(File.Exists(Path.Combine(_destination.Path, _destination.Name)));
        }

        internal static void WriteTestContent(FileStream fileStream, string content)
        {
            byte[] contentBytes = new UTF8Encoding(true).GetBytes(content);
            fileStream.Write(contentBytes, 0, contentBytes.Length);
        }
    }
}