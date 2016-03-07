using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonSearch.ViewModel;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        MainWindowViewModel mainWinVM;

        public UnitTest1()
        {
            mainWinVM = new MainWindowViewModel();
        }

        /// <summary>
        /// Test cases executed to test Search and Add functionality
        /// Please read README file for detailed description of TestCases
        /// </summary>
        [TestMethod]
        public void TestAddSearchPerson()
        {
            // Searches a record that is not present in the database
            mainWinVM.SrchName = "ABCUNIQUEXYZ123";
            mainWinVM.FetchPersonDetails();
            Assert.AreNotEqual(mainWinVM.FetchMessage, "", "Please delete ABCUNIQUEXYZ123 from the database for unit testing!");

            // Adds a record in the database
            mainWinVM.FName = "ABCUNIQUEXYZ123";
            mainWinVM.LName = "SHOULDBEUNIQUE";
            mainWinVM.PAddress = "Visual Studio";
            mainWinVM.PAge = "10";
            mainWinVM.PInterests = "Demo";
            mainWinVM.PathName = Directory.GetCurrentDirectory() + "\\Images\\Demo.jpg";
            mainWinVM.AddPerson();
            Assert.AreEqual(mainWinVM.AddStatus, "Person Added successfully!! Please click Add Person menu button to add another person", "Add Test Failed");

            // Searches the record added in the above case. The record should be present
            mainWinVM.SrchName = "ABCUNIQUEXYZ123";
            mainWinVM.FetchPersonDetails();
            Assert.AreEqual(mainWinVM.FetchMessage, "", "Search Test Failed");
        }
    }
}
