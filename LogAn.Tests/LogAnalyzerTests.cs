using System;
using Castle.Components.DictionaryAdapter.Xml;
using Moq;
using NUnit.Framework;

namespace LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {

        private LogAnalyzer _logAnalyzer = null;

        [SetUp]
        public void SetUp()
        {
            this._logAnalyzer = new LogAnalyzer();
        }

        [TearDown]
        public void TearDown()
        {
            this._logAnalyzer = null;
        }

        #region IsValidLogFileName

        /// <summary>
        /// 文件名以.slf结尾
        /// </summary>
        [Test]
        public void IsValidLogFileName_ValidFile_ReturnsTrue()
        {
            var result = this._logAnalyzer.IsValidLogFileName("file.SLF");

            Assert.IsTrue(result, "检查文件后缀");
        }

        /// <summary>
        /// 根据属性判断测试是否成功
        /// </summary>
        [Test]
        public void IsValidLogFileName_ValidFile_RemembersTrue()
        {
            _logAnalyzer.IsValidLogFileName("test.slf");
            Assert.IsTrue(_logAnalyzer.WasLastFileNameValid);
        }

        /// <summary>
        /// 使用桩对象
        /// </summary>
        [Test]
        public void IsValidLogFileName_UseStub_ReturnsFalse()
        {
            StubExtensionManager manager = new StubExtensionManager
            {
                ShouldExtensionBeValid = true
            };
            LogAnalyzer logAnalyzer = new LogAnalyzer(manager);
            bool result = logAnalyzer.IsValidLogFileName("test.slf");
            Assert.IsTrue(result);
        }

        /// <summary>
        /// 使用moq
        /// </summary>
        [Test]
        public void IsValidLogFileName_UseMoq_ReturnsFalse()
        {
            var mock = new Mock<IExtensionManager>();
            mock.Setup(e => e.IsValid("test.slf")).Returns(true);

            LogAnalyzer logAnalyzer = new LogAnalyzer(mock.Object);
            var result = logAnalyzer.IsValidLogFileName("test.slf");
            Assert.IsTrue(result);
        }

        /// <summary>
        /// 空文件名抛出异常
        /// </summary>
        [Test]
        public void IsValidLogFileName_EmptyFileName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this._logAnalyzer.IsValidLogFileName(string.Empty);
            }, "空文件名应该抛出错误");
        }

        #endregion

    }
}