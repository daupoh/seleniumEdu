using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumEduProject
{
    abstract class ACPage : IPage
    {
        protected IWebDriver m_pDriver;
        protected string m_sUrl;

        public ACPage(IWebDriver driver) {
            m_pDriver = driver;
        }

        public void Go() {
            m_pDriver.Url = m_sUrl;
        }
        public void OnIt() {
            Assert.IsTrue(m_pDriver.Url == m_sUrl);
        }
        
    }
}
