using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace seleniumEduProject
{
    [TestClass]
    public class testAppLogin
    {
        IWebDriver m_pDriver;
        WebDriverWait m_pWait;
        string baseUrl = "http://localhost/litecart/admin/",
            xpathLoginField= "//input[@name='username']",
            xpathPassField= "//input[@name='password']",
            xpathLoginButton = "//button[@type='submit']";
        

        [SetUp]
        public void initTests() {
            m_pDriver = getDriver('f');
            m_pWait = new WebDriverWait(m_pDriver,TimeSpan.FromSeconds(10));
            
        }
        IWebDriver getDriver(char b) {
            IWebDriver result = null;
            switch (b) {
                case 'c': result = new ChromeDriver(); break;
                case 'f': result = new FirefoxDriver(); break;
                case 'e': result = new InternetExplorerDriver(); break;
                default: break;
            }
            return result;
        }
        [TestCaseSource("GetLoginPassPairs")]
        public void Login(string login, string password)
        {
          
            m_pDriver.Url = baseUrl;  
            
            m_pDriver.FindElement(By.XPath(xpathLoginField)).SendKeys(login);
            m_pDriver.FindElement(By.XPath(xpathPassField)).SendKeys(password);
            m_pDriver.FindElement(By.XPath(xpathLoginButton)).Click();
        }

        [TearDown]
        public void clearTests() {
            m_pDriver.Quit();
            m_pDriver = null;
        }
        public static IEnumerable<TestCaseData> GetLoginPassPairs () {
            yield return new TestCaseData("admin", "admin");
        }
    }
}
