using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumEduProject
{
    class CAdminPage:ACPage
    {
        string m_sPrimeSectionsXPath = "//ul[@id='box-apps-menu']/li",
                m_sSecondarySectionsXPath = "//ul[@class='docs']/li";
        int m_iPrimeSections = 17;
        int[] m_aSecondSectionsCounts = {
            2,9,0,0,3,0,2,7,2,0,
            3,8,0,2,3,0,1
        };
        /*string[] m_aSectionXPath ={
            "//ul[@id='box-apps-menu']/li[1]/a",
            "//ul[@id='box-apps-menu']/li[2]/a",
            "//ul[@id='box-apps-menu']/li[3]/a",
            "//ul[@id='box-apps-menu']/li[4]/a",
            "//ul[@id='box-apps-menu']/li[5]/a",
            "//ul[@id='box-apps-menu']/li[6]/a",
            "//ul[@id='box-apps-menu']/li[7]/a",
            "//ul[@id='box-apps-menu']/li[8]/a",
            "//ul[@id='box-apps-menu']/li[9]/a",
            "//ul[@id='box-apps-menu']/li[10]/a",
            "//ul[@id='box-apps-menu']/li[11]/a",
            "//ul[@id='box-apps-menu']/li[12]/a",
            "//ul[@id='box-apps-menu']/li[13]/a",
            "//ul[@id='box-apps-menu']/li[14]/a",
            "//ul[@id='box-apps-menu']/li[15]/a",
            "//ul[@id='box-apps-menu']/li[16]/a",
            "//ul[@id='box-apps-menu']/li[17]/a"};*/

        public CAdminPage(IWebDriver driver) : base(driver) {
            m_sUrl = "http://localhost/litecart/admin/";            
        }
        
        public void CheckAllSections() {
            int nSections = m_pDriver.FindElements(By.XPath(m_sPrimeSectionsXPath)).Count;
            Assert.IsTrue(nSections == m_iPrimeSections);

            for (int i = 0; i < m_iPrimeSections; i++)
            {
                int index = i + 1;
                string xpath = m_sPrimeSectionsXPath + "[" + index.ToString() + "]";
                m_pDriver.FindElement(By.XPath(xpath)).Click();

                m_pDriver.FindElement(By.XPath("//h1"));

                xpath = xpath + m_sSecondarySectionsXPath;
                int nSubSections = m_pDriver.FindElements(By.XPath(xpath)).Count;
                Assert.IsTrue(nSubSections == m_aSecondSectionsCounts[i],
                    nSubSections.ToString() + " must be equal " + m_aSecondSectionsCounts[i].ToString());
            }
            
        }
        /*
        public void GoAppearence() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[0])).Click();
        }
        public void GoCatalog() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[1])).Click();
        }
        public void GoCountries() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[2])).Click();
        }
        public void GoCurrencies() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[3])).Click();
        }
        public void GoCustomers() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[4])).Click();
        }
        public void GoGeoZones() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[5])).Click();
        }
        public void GoLanguages() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[6])).Click();
        }
        public void GoModules() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[7])).Click();
        }
        public void GoOrders () {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[8])).Click();
        }
        public void GoPages () {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[9])).Click();
        }
        public void GoReports () {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[10])).Click();
        }
        public void GoSettings () {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[11])).Click();
        }
        public void GoSlides() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[12])).Click();
        }
        public void GoTax() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[13])).Click();
        }
        public void GoTranslation() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[14])).Click();
        }        
        public void GoUsers() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[15])).Click();
        }
        public void GoVQModes() {
            m_pDriver.FindElement(By.XPath(m_aSectionXPath[16])).Click();
        }
        */
    }
}
