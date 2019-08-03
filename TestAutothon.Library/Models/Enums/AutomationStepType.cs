using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutothon.Library.Models.Enums
{
    public enum AutomationStepType
    {
        NavigateToUrl = 0,
        InputText = 2,
        ClickElement = 3,
        SelectDropdownItem = 4,
        RightClick = 5,
        DragElement = 6,
        ExecuteCustomFunction = 7,
        SearchElement = 8,
        DeselectDropDownItem = 9,
        DownloadImage = 10,
        GetValue = 11
    }

    public enum AutomationFindElementBy
    {
        ByClassName = 0,
        ByCssSelector = 2,
        ById = 3,
        ByLinkText = 4,
        ByName = 5,
        ByPartialLinkText = 6,
        ByTagName = 7,
        ByXPath = 8
    }
}
