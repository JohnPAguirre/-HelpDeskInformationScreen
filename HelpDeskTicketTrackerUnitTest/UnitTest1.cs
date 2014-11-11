using System;
using HelpDeskTicketTracker.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace HelpDeskTicketTrackerUnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void MainWindowViewModel()
        {
            var vm = new MainWindowViewModel();

            bool IncidentSet = false;
            bool RequestSet = false;
            bool LastUpdatedSet = false;
            bool URLSet = false;

            vm.PropertyChanged += ((object a, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == "Incident")
                    IncidentSet = true;
                if (e.PropertyName == "Request")
                    RequestSet = true;
                if (e.PropertyName == "LastUpdated")
                    LastUpdatedSet = true;
                if (e.PropertyName == "URL")
                    URLSet = true;
            });

            int IncidentValue = 110;
            int RequestValue = 170;
            DateTime LastUpdatedValue = DateTime.Now.ToUniversalTime();
            string URLValue = @"URL is blahblahlbah";

            vm.Incident = IncidentValue;
            vm.Request = RequestValue;
            vm.LastUpdated = LastUpdatedValue.ToString();
            vm.URL = URLValue;

            Assert.IsTrue(IncidentSet);
            Assert.IsTrue(RequestSet);
            Assert.IsTrue(LastUpdatedSet);
            Assert.IsTrue(URLSet);

            Assert.AreEqual(vm.Incident, IncidentValue);
            Assert.AreEqual(vm.Request, RequestValue);
            string localtime = LastUpdatedValue.ToLocalTime().ToString("R");
            Assert.IsTrue(vm.LastUpdated.Contains(localtime));
            Assert.IsTrue(vm.URL.Contains(URLValue));

        }
    }
}
