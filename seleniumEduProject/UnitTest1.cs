using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace seleniumEduProject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver m_pDriver;
        WebDriverWait m_pWait;

        [SetUp]
        public void initTests() {
            m_pDriver = new ChromeDriver();
            m_pWait = new WebDriverWait(m_pDriver,TimeSpan.FromSeconds(10));
            
        }
        [Test]
        public void OpenAndSearchInGoogle()
        {
            string sSearchFieldXPath = "xpath=//div[@id='fakebox']//input",
                sSearched = "google",
                sDefaultTitle=" - Поиск в Google";

            m_pDriver.Url = "https://www.google.ru";  
            
            m_pDriver.FindElement(By.Name("q")).SendKeys(sSearched);
            m_pDriver.FindElement(By.Name("q")).Submit();
            m_pWait.Until(ExpectedConditions.TitleIs(sSearched + sDefaultTitle));
        }

        [TearDown]
        public void clearTests() {
            m_pDriver.Quit();
            m_pDriver = null;
        }
    }
}
