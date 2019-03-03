using System;
using PacmanIEDigital;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PacmanIEDigital.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        Directions directionValue;
        Form1 form = new Form1();

        //Test for exception message if Pacman falls off the grid
        [TestMethod]
        public void CheckGrid_GridExceeded_DisplayErrorMessage()
        {
                   
            Assert.IsTrue(form.CheckGrid(5, 5));
        }     




    }
}
