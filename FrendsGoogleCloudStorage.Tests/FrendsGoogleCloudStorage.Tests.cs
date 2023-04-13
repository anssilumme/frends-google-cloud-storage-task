using NUnit.Framework;
using System;

namespace FrendsGoogleCloudStorage.Tests
{
    [TestFixture]
    class TestClass
    {
        /// <summary>
        /// You need to run FrendsGoogleCloudStorage.SetPaswordsEnv.ps1 before running unit test, or some other way set environment variables e.g. with GitHub Secrets.
        /// </summary>
        [Test]
        public void ThreeCloudStorageTasks()
        {
            var input = new Parameters
            {
                Message = Environment.GetEnvironmentVariable("EXAMPLE_ENVIROMENT_VARIABLE")
        };

            var options = new Options
            {
                Amount = 3,
                Delimiter = ", "
            };

            var ret = CloudStorageTask.CloudStorage(input, options, new System.Threading.CancellationToken());

            Assert.That(ret.Replication, Is.EqualTo("foobar, foobar, foobar"));
        }
    }
}
