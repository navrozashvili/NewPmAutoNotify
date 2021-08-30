using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSelene;
using OpenQA.Selenium;
using static NSelene.Selene;

namespace NewPmAutoNotify.PageObjects
{
    class NewPm
    {
        protected static string _baseUrl = "newpm.dataart.com/Idle";
        protected SeleneElement DurationTextBox = S("#idle_duration"),
                                TemporarelyOccupiedCheckBox = S("#tempOccupied"),
                                SelectProjectDropDown = S("#selectProject"),
                                SendButton = S("#SendButton"),
                                TableElement = S("#FunctionalPart");
    }
}
