using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestAutothon.Library;
using TestAutothon.Library.Models;

namespace TestAutothon
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("F:\\Softwares\\chromedriver_win32");

            WebAutomationStep step1 = new WebAutomationStep()
            {
                AllowParallelThreads = false,
                StepNo = 1,
                StepType = Library.Models.Enums.AutomationStepType.NavigateToUrl,
                InputValue = "http://www.google.com"
            };


            var helper = new TestAutomationHelper();
            helper.Run(driver, step1);

            WebAutomationStep step2 = new WebAutomationStep()
            {
                AllowParallelThreads = false,
                StepNo = 2,
                StepType = Library.Models.Enums.AutomationStepType.InputText,
                InputValue = "game of thrones",
                FindElementBy = Library.Models.Enums.AutomationFindElementBy.ByXPath,
                FindByValue = ".//*[@name='q']"
            };
            helper.Run(driver, step2);

            WebAutomationStep step3 = new WebAutomationStep()
            {
                AllowParallelThreads = false,
                StepNo = 2,
                StepType = Library.Models.Enums.AutomationStepType.ClickElement,
                FindElementBy = Library.Models.Enums.AutomationFindElementBy.ByXPath,
                FindByValue = ".//*[@aria-label='Google Search']"
            };
            helper.Run(driver, step3);

        }
    }
}
