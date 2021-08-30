using NewPmAutoNotify.PageObjects;
using NSelene;
using NSelene.Conditions;
using OpenQA.Selenium;
using static NSelene.Selene;
namespace NewPmAutoNotify.StepObjects
{
    class NewPmSteps : NewPm
    {
        private NewPmSteps() { }

        public static NewPmSteps Open(string username, string password)
        {
            var url = $"https://{username}:{password}@{_baseUrl}";
            Selene.Open(url);
            return new NewPmSteps();
        }

        public NewPmSteps ClickTemporarelyOccupied()
        {
            TemporarelyOccupiedCheckBox.Click();
            return this;
        }

        public NewPmSteps SetHours(string hours = "8")
        {
            DurationTextBox.Clear().SendKeys(hours);
            return this;
        }

        public NewPmSteps SelectProject(string project)
        {
            var optionsCollection = SelectProjectDropDown.FindAll(By.TagName("option"));
            SeleneElement projectOptionElement = null;
            foreach(var element in optionsCollection)
            {
                if (element.Text == project)
                    projectOptionElement = element;
            }
            if (projectOptionElement == null)
                throw new NotFoundException($"{project} is not found");
            //SelectProjectDropDown.Click();
            projectOptionElement.Click();
            return this;
        }

        public NewPmSteps ClickSend()
        {
            SendButton.Click();
            return this;
        }
        public NewPmSteps AssertActionWasSuccessful()
        {
            TableElement.Should(new Visible());
            return this;
        }
    }
}
