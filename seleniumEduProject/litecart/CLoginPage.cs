using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumEduProject
{
    class CLoginPage : ACPage
    {
        string m_sLoginFieldXPath = "//input[@name='username']",
                m_sPasswordFieldXpath = "//input[@name='password']",
                m_sSubmitButtonXPath = "//button[@type='submit']";
      
        public CLoginPage(IWebDriver driver) : base(driver) {
            m_sUrl = "http://localhost/litecart/admin/login.php";
            
        }

        public void Login(string login, string pass) {
            m_pDriver.FindElement(By.XPath(m_sLoginFieldXPath)).SendKeys(login);
            m_pDriver.FindElement(By.XPath(m_sPasswordFieldXpath)).SendKeys(pass);
            m_pDriver.FindElement(By.XPath(m_sSubmitButtonXPath)).Click();
        }

    }
}
