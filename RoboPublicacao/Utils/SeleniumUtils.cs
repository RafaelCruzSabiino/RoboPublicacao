using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoboPublicacao.Utils
{
    public class SeleniumUtils
    {
        private ChromeDriver  _chromeDriver;
        private ChromeOptions _chromeOptions;

        public SeleniumUtils() 
        {
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AcceptInsecureCertificates = true;
            _chromeOptions.AddArgument("--start-maximized");
            _chromeOptions.AddArgument("--ignore-certificate-errors");

            _chromeDriver = new ChromeDriver(@"C:\Driver\", _chromeOptions);
        }

        public void AcessarPlataforma(string url) 
        {
            _chromeDriver.Navigate().GoToUrl(url);
            Thread.Sleep(10000);
        }

        public void EnviarDado(string key, string prop, string value) 
        {
            switch (prop) 
            {
                case "ID":
                    _chromeDriver.FindElement(By.Id(key)).SendKeys(value); 
                    break;
                case "NAME":
                    _chromeDriver.FindElement(By.Name(key)).SendKeys(value);
                    break;
                case "XPATH":
                    _chromeDriver.FindElement(By.XPath(key)).SendKeys(value);
                    break;
                case "CSSSELECTOR":
                    _chromeDriver.FindElement(By.CssSelector(key)).SendKeys(value);
                    break;
            }

            Thread.Sleep(500);
        }

        public void Clicar(string key, string prop) 
        {
            switch (prop)
            {
                case "ID":
                    _chromeDriver.FindElement(By.Id(key)).Click();
                    break;
                case "NAME":
                    _chromeDriver.FindElement(By.Name(key)).Click();
                    break;
                case "XPATH":
                    _chromeDriver.FindElement(By.XPath(key)).Click();
                    break;
                case "CSSSELECTOR":
                    _chromeDriver.FindElement(By.CssSelector(key)).Click();
                    break;
            }

            Thread.Sleep(500);
        }

        public void FinalizarConexao() 
        {
            if(_chromeDriver != null) 
            {
                _chromeDriver.Quit();
                _chromeDriver.Close();
                _chromeDriver = null;
            }
        }
    }
}
