using System;
using System.Configuration;
using Es.CodeKatas.StringCalculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Es.CodeKatas.StringCalculatorsTests
{
    [TestClass]
    public class StringCalculatorParosSrlTests
    {
        private const string DataSourceSettingName = "StringCalculator";
        private const string DataSourceSettingNameException = "StringCalculatorException";

        private StringCalculatorParosSrl _stringCalculatorParosSrl;


        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void TestInitialize()
        {
            _stringCalculatorParosSrl = new StringCalculatorParosSrl();
        }

        [TestMethod]
        [DataSource(DataSourceSettingName)]
        public void AddTest()
        {
            Assert.AreEqual(
                Convert.ToInt32(
                    TestContext.DataRow[ConfigurationManager.AppSettings[Enumerators.AppSettingsKeys.Return.ToString()]]),
                _stringCalculatorParosSrl.Add(
                    Convert.ToString(
                        TestContext.DataRow[
                            ConfigurationManager.AppSettings[Enumerators.AppSettingsKeys.Numbers.ToString()]])));
        }

        [TestMethod]
        [DataSource(DataSourceSettingNameException)]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExceptionTest()
        {
            Assert.AreEqual(
                Convert.ToInt32(
                    TestContext.DataRow[ConfigurationManager.AppSettings[Enumerators.AppSettingsKeys.Return.ToString()]]),
                _stringCalculatorParosSrl.Add(
                    Convert.ToString(
                        TestContext.DataRow[
                            ConfigurationManager.AppSettings[Enumerators.AppSettingsKeys.Numbers.ToString()]])));
        }
    }
}
