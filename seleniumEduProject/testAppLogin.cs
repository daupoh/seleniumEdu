using System;
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
    [TestFixture]
    public class testAppLogin
    {
        IWebDriver m_pDriver;
        CLoginPage m_pLoginPage;
        CAdminPage m_pAdminPage;
        WebDriverWait m_pWait;
               

        [SetUp]
        public void initTests() {
            m_pDriver = getDriver('c');           
            m_pWait = new WebDriverWait(m_pDriver,TimeSpan.FromSeconds(10));
            m_pLoginPage = new CLoginPage(m_pDriver);
            m_pAdminPage = new CAdminPage(m_pDriver);

        }
       
        [TestCaseSource("GetLoginPassPairs")]
        public void CheckAdminsSections(string login, string password)
        {
            m_pLoginPage.Go();
            m_pLoginPage.Login(login, password);
            m_pAdminPage.OnIt();
            m_pAdminPage.CheckAllSections();
        }
        
        [TearDown]
        public void clearTests() {
            m_pDriver.Quit();
            m_pDriver = null;
        }
        public static IEnumerable<TestCaseData> GetLoginPassPairs () {
            yield return new TestCaseData("admin", "admin");
        }
        IWebDriver getDriver(char b)
        {
            IWebDriver result = null;
            switch (b)
            {
                case 'c': result = new ChromeDriver(); break;
                case 'f': result = new FirefoxDriver(); break;
                case 'e': result = new InternetExplorerDriver(); break;
                default: break;
            }
            return result;
        }
    }
}
