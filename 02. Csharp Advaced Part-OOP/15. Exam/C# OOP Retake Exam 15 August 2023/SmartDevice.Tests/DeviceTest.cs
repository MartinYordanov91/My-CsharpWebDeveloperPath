namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShoudWorckCorrectly()
        {
            int expectedMemory = 20;
            int expectedPotos = 0;
            int expectedListCount = 0;
            Device device = new Device(expectedMemory);

            Assert.AreEqual(expectedMemory, device.MemoryCapacity);
            Assert.AreEqual(expectedMemory, device.AvailableMemory);
            Assert.AreEqual(expectedPotos, device.Photos);
            Assert.AreEqual(expectedListCount, device.Applications.Count);
        }

        [Test]
        public void MethodTakePhotoShoudWorkCorrectlyTrue()
        {
            int PhotoSize = 10;
            int memory = 20;
            int expectedPotos = 1;
            int expectedAvailbal = 10;
            Device device = new Device(memory);

            Assert.IsTrue(device.TakePhoto(PhotoSize));
            Assert.AreEqual(expectedPotos, device.Photos);
            Assert.AreEqual(expectedAvailbal, device.AvailableMemory);

        }

        [Test]
        public void MethodTakePhotoShoudWorkCorrectlyFalse()
        {
            int PhotoSize = 20;
            int memory = 10;

            Device device = new Device(memory);

            Assert.IsFalse(device.TakePhoto(PhotoSize));
        }

        [Test]
        public void MethodInstallAppShoudWorkCorrectly()
        {
            int appSize = 10;
            int memory = 20;
            int expectedListCount = 1;
            int expectedAvailbal = 10;
            string appName = "stepUp";

            Device device = new Device(memory);
            string result = device.InstallApp(appName, appSize);

            Assert.AreEqual("stepUp is installed successfully. Run application?", result);
            Assert.AreEqual(expectedListCount, device.Applications.Count);
            Assert.AreEqual(expectedAvailbal, device.AvailableMemory);
        }

        [Test]
        public void MethodInstallAppShoudThrowException()
        {
            int appSize = 20;
            int memory = 10;
            string appName = "stepUp";

            Device device = new Device(memory);
            
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => device.InstallApp(appName, appSize));
            Assert.AreEqual("Not enough available memory to install the app.", ex.Message);
            
        }

        [Test]
        public void MethodFormatDeviceShoudWorkCorrectly()
        {
            int size = 10;
            int memory = 30;
            int expectedListCount = 0;
            int expectedPhoto = 0;
            int expectedAvailbal = 30;
            string appName = "stepUp";

            Device device = new Device(memory);
            device.InstallApp(appName, size);
            device.TakePhoto(size);
            device.FormatDevice();

            
            Assert.AreEqual(expectedListCount, device.Applications.Count);
            Assert.AreEqual(expectedPhoto, device.Photos);
            Assert.AreEqual(expectedAvailbal, device.AvailableMemory);
        }

        [Test]
        public void MethodGetDeviceStatusShoudWorkCorrectly()
        {
            int size = 10;
            int memory = 30;
            int expectedListCount = 1;
            int expectedPhoto = 1;
            int expectedAvailbal = 10;
            string appName = "stepUp";


            Device device = new Device(memory);
            device.InstallApp(appName, size);
            device.TakePhoto(size);

            string expectResult = $"Memory Capacity: {memory} MB, Available Memory: {expectedAvailbal} MB{Environment.NewLine}Photos Count: {expectedPhoto}{Environment.NewLine}Applications Installed: {string.Join(", ", device.Applications)}";

            string result = device.GetDeviceStatus();


            Assert.AreEqual(expectResult, result);
        }
    }
}