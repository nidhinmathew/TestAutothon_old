using System;
using System.Collections.Generic;
using System.Text;
using TestAutothon.Library.Models.Enums;

namespace TestAutothon.Library.Models
{
    public class WebAutomationStep
    {
        public int StepNo { get; set; }

        public AutomationStepType StepType { get; set; }

        public AutomationFindElementBy FindElementBy { get; set; }

        public string FindByValue { get; set; }

        public AutomationFindElementBy FindTargetElementBy { get; set; }

        public string FindTargetByValue { get; set; }

        public string InputValue { get; set; }

        public string OutputValue { get; set; }

        public char InputValueSeperator { get; set; }

        public bool HasMultipleValue { get; set; }

        public List<WebAutomationStep> Steps { get; set; }

        public bool AllowParallelThreads { get; set; }

        public int ParallelThreadLimit { get; set; }
    }
}

