using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Net;
using TestAutothon.Library.Models;
using TestAutothon.Library.Models.Enums;

namespace TestAutothon.Library
{
    public class TestAutomationHelper
    {
        public void Run(IWebDriver driver, WebAutomationStep automationStep)
        {
            if (driver != null && automationStep != null)
            {
                if (automationStep.Steps != null && automationStep.Steps.Any())
                {

                }
                else
                {
                    switch (automationStep.StepType)
                    {
                        case AutomationStepType.ClickElement:
                            ClickElement(driver, automationStep); break;
                        case AutomationStepType.DragElement:
                            DragDrop(driver, automationStep); break;
                        case AutomationStepType.ExecuteCustomFunction: break;
                        case AutomationStepType.InputText:
                            InputText(driver, automationStep); break;
                        case AutomationStepType.NavigateToUrl:
                            NavigateToUrl(driver, automationStep); break;
                        case AutomationStepType.RightClick: break;
                        case AutomationStepType.SearchElement: break;
                        case AutomationStepType.SelectDropdownItem:
                            SelectDropdownItem(driver, automationStep); break;
                        case AutomationStepType.DeselectDropDownItem:
                            DeselectDropdownItem(driver, automationStep); break;
                        case AutomationStepType.DownloadImage:
                            DownloadImage(driver, automationStep); break;
                        case AutomationStepType.GetValue:
                            GetValue(driver, automationStep); break;
                        default: break;
                    }
                }
            }
        }

        private IWebElement FindElement(IWebDriver driver, AutomationFindElementBy by, string value)
        {
            IWebElement element = null;
            switch (by)
            {
                case AutomationFindElementBy.ByClassName: element = driver.FindElement(By.ClassName(value)); break;
                case AutomationFindElementBy.ByCssSelector: element = driver.FindElement(By.CssSelector(value)); break;
                case AutomationFindElementBy.ById: element = driver.FindElement(By.Id(value)); break;
                case AutomationFindElementBy.ByLinkText: element = driver.FindElement(By.LinkText(value)); break;
                case AutomationFindElementBy.ByName: element = driver.FindElement(By.Name(value)); break;
                case AutomationFindElementBy.ByPartialLinkText: element = driver.FindElement(By.PartialLinkText(value)); break;
                case AutomationFindElementBy.ByTagName: element = driver.FindElement(By.TagName(value)); break;
                case AutomationFindElementBy.ByXPath: element = driver.FindElement(By.XPath(value)); break;
                default: break;
            };

            return element;
        }

        private void NavigateToUrl(IWebDriver driver, WebAutomationStep automationStep)
        {
            if (!string.IsNullOrEmpty(automationStep.InputValue))
            {
                driver.Navigate().GoToUrl(automationStep.InputValue);
            }
        }

        private void ClickElement(IWebDriver driver, WebAutomationStep automationStep)
        {
            if (!string.IsNullOrEmpty(automationStep.FindByValue))
            {
                var element = FindElement(driver, automationStep.FindElementBy, automationStep.FindByValue);
                if (element != null)
                {
                    element.Click();
                }
            }
        }

        private void InputText(IWebDriver driver, WebAutomationStep automationStep)
        {
            if (!string.IsNullOrEmpty(automationStep.FindByValue))
            {
                var element = FindElement(driver, automationStep.FindElementBy, automationStep.FindByValue);
                if (element != null)
                {
                    element.SendKeys(automationStep.InputValue);
                }
            }
        }

        private void DragDrop(IWebDriver driver, WebAutomationStep automationStep)
        {
            if (!string.IsNullOrEmpty(automationStep.FindByValue) && !string.IsNullOrEmpty(automationStep.FindTargetByValue))
            {
                var source = FindElement(driver, automationStep.FindElementBy, automationStep.FindByValue);
                var target = FindElement(driver, automationStep.FindTargetElementBy, automationStep.FindTargetByValue);

                if (source != null && target != null)
                {
                    var builder = new Actions(driver);
                    var action = builder.DragAndDrop(source, target);
                    action.Perform();
                }
            }
        }

        private void SelectDropdownItem(IWebDriver driver, WebAutomationStep automationStep)
        {
            if (!string.IsNullOrEmpty(automationStep.FindByValue))
            {
                var element = FindElement(driver, automationStep.FindElementBy, automationStep.FindByValue);
                if (element != null)
                {
                    var select = new SelectElement(element);
                    if (!string.IsNullOrEmpty(automationStep.InputValue))
                    {
                        if (automationStep.HasMultipleValue)
                        {
                            var array = automationStep.InputValue.Split(automationStep.InputValueSeperator);
                            if (array.Length > 0)
                            {
                                foreach (var item in array)
                                    select.SelectByText(item.Trim(), false);
                            }
                        }
                        else
                        {
                            select.SelectByText(automationStep.InputValue, false);
                        }
                    }
                }
            }
        }

        private void DeselectDropdownItem(IWebDriver driver, WebAutomationStep automationStep)
        {
            if (!string.IsNullOrEmpty(automationStep.FindByValue))
            {
                var element = FindElement(driver, automationStep.FindElementBy, automationStep.FindByValue);
                if (element != null)
                {
                    var select = new SelectElement(element);
                    if (!string.IsNullOrEmpty(automationStep.InputValue))
                    {
                        if (automationStep.HasMultipleValue)
                        {
                            var array = automationStep.InputValue.Split(automationStep.InputValueSeperator);
                            if (array.Length > 0)
                            {
                                foreach (var item in array)
                                    select.DeselectByText(item.Trim());
                            }
                        }
                        else
                        {
                            select.DeselectByText(automationStep.InputValue);
                        }
                    }
                }
            }
        }

        private void DownloadImage(IWebDriver driver, WebAutomationStep automationStep)
        {
            if (!string.IsNullOrEmpty(automationStep.FindByValue))
            {
                var element = FindElement(driver, automationStep.FindElementBy, automationStep.FindByValue);
                if (element != null)
                {
                    string imageSrc = element.GetAttribute("src");

                    WebClient client = new WebClient();
                    client.DownloadFile(imageSrc, automationStep.StepNo + ".jpeg");
                }
            }
        }

        private void GetValue(IWebDriver driver, WebAutomationStep automationStep)
        {
            if (!string.IsNullOrEmpty(automationStep.FindByValue))
            {
                var element = FindElement(driver, automationStep.FindElementBy, automationStep.FindByValue);
                if (element != null)
                {
                    automationStep.OutputValue = element.Text;
                }
            }
        }

    }
}
