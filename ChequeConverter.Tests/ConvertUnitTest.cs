using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChequeConverter.Tests
{
    [TestClass]
    public class ConvertUnitTest
    {
        ChequeConverter converter;

        [TestInitialize] 
        public void Init()
        {
            converter = new ChequeConverter();
        }

        #region "Test hundreds first"

        [TestMethod]
        public void shouldReturnNothing()
        {
            string ret = converter.HundredsToWords(0);
            Assert.AreEqual("", ret);
        }

        [TestMethod]
        public void shouldReturnWholeHundred()
        {
            string ret = converter.HundredsToWords(200);
            Assert.AreEqual("Two Hundred", ret);
        }

        [TestMethod]
        public void shouldReturnHundredAndTens()
        {
            string ret = converter.HundredsToWords(530);
            Assert.AreEqual("Five Hundred And Thirty", ret);
        }

        [TestMethod]
        public void shouldReturnHundredAndTensAndNumber()
        {
            string ret = converter.HundredsToWords(467);
            Assert.AreEqual("Four Hundred And Sixty-Seven", ret);
        }

        [TestMethod]
        public void shouldReturnTensAndNumberOnly()
        {
            string ret = converter.HundredsToWords(89);
            Assert.AreEqual("Eighty-Nine", ret);
        }

        [TestMethod]
        public void shouldReturnNumberOnly()
        {
            string ret = converter.HundredsToWords(5);
            Assert.AreEqual("Five", ret);
        }

        [TestMethod]
        public void shouldReturnHundredAndNumberOnly()
        {
            string ret = converter.HundredsToWords(105);
            Assert.AreEqual("One Hundred And Five", ret);
        }
        #endregion

        #region Test Decimal 

        [TestMethod]
        public void shouldReturnNoCents()
        {
            string ret = converter.DecimalToWords((decimal)5.00);
            Assert.AreEqual("", ret);
        }
        [TestMethod]
        public void shouldReturnNoCents2()
        {
            string ret = converter.DecimalToWords((decimal)5);
            Assert.AreEqual("", ret);
        }
        [TestMethod]
        public void shouldReturn50Cents()
        {
            string ret = converter.DecimalToWords((decimal)2.50);
            Assert.AreEqual("Fifty Cents", ret);
        }
        [TestMethod]
        public void shouldReturn35Cents()
        {
            string ret = converter.DecimalToWords((decimal)2.35);
            Assert.AreEqual("Thirty-Five Cents", ret);
        }
        [TestMethod]
        public void shouldReturn11Cents()
        {
            string ret = converter.DecimalToWords((decimal)2.11);
            Assert.AreEqual("Eleven Cents", ret);
        }

        #endregion

        #region Test cheque numbers
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"")]
        public void shouldExpectArgumentException()
        {
            string ret = converter.NumberToWords((decimal)9999999999999.99);
            Assert.AreEqual("Thirteen Million And Four Hundred And Fifty-Six Thousand And Seven Hundred And Eighty Nine And Five Cents", ret);
        }

        [TestMethod]
        public void shouldReturnWith13Million()
        {
            string ret = converter.NumberToWords((decimal)13456789.05);
            Assert.AreEqual("Thirteen Million And Four Hundred And Fifty-Six Thousand And Seven Hundred And Eighty-Nine Dollar And Five Cents", ret);
        }

        [TestMethod]
        public void shouldReturnWith3Thousand()
        {
            string ret = converter.NumberToWords((decimal)3716.40);
            Assert.AreEqual("Three Thousand And Seven Hundred And Sixteen Dollar And Fourty Cents", ret);
        }
        #endregion
    }
}
