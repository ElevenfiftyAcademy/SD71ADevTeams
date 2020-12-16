using System;
using System.Collections.Generic;
using DevTeamsProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevTeamsRepoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestForAddingPocoToList() //Our Poco is our Developer, The List is the _developerDirectory from our DeveloperRepo object.
        {
            // Arrange - Set up the data or controlled environment for the test to run
            DeveloperRepo devRepo = new DeveloperRepo();
            Developer devToAdd = new Developer("TestDev", true);

            //Act - we can now call the Method that we are testing
            devRepo.AddDeveloperToDirectory(devToAdd);

            //Assert - We've ran the method, and we write few lines of code to confirm that our method behaved the way that we intended it to behave

            List<Developer> devDirectory = devRepo.GetAllDevelopers();

            bool IdIsEqual = false; //We assume it is false until proved true
            foreach(Developer dev in devDirectory)
            {
                if (dev.DeveloperID == devToAdd.DeveloperID)
                {
                    IdIsEqual = true;
                    break;
                }             
            }

            //Assert
            Assert.IsTrue(IdIsEqual);
        }
        [TestMethod]
        public void TestForAddingPOCOToListTwo()
        {
            //Arrange - Setting up the controlled environment for our test
            DeveloperRepo devRepo = new DeveloperRepo();
            Developer devToAdd = new Developer("TestDev", true);

            //Act - Calling the code that we are testing
            devRepo.AddDeveloperToDirectory(devToAdd);

            //Assert - Utilizing the Assert class to confirm the validity of our tests

            Developer copyOfDevFromList = new Developer();
            List<Developer> devDirectory = devRepo.GetAllDevelopers();
            
            foreach (Developer dev in devDirectory)
            {
                if (dev.DeveloperID == devToAdd.DeveloperID)
                {
                    copyOfDevFromList = dev;
                    break;
                }
            }

            Assert.AreEqual(devToAdd.Name, copyOfDevFromList.Name);
        }

        [TestMethod]
        public void TestForGetDeveloperDirectoryIsNotNull()
        {
            //Arrange
            DeveloperRepo devRepo = new DeveloperRepo();

            //Act
            List<Developer> listFromRepo = devRepo.GetAllDevelopers();

            //Assert
            Assert.IsNotNull(listFromRepo);
        }

        [TestMethod]
        public void TestForGetDevByID()
        {
            //Arange
            DeveloperRepo devRepo = new DeveloperRepo();
            Developer devToAdd = new Developer("TestDev", true);
            devRepo.AddDeveloperToDirectory(devToAdd);

            //Act
            Developer devByID = devRepo.GetDeveloperById(devToAdd.DeveloperID);

            //Assert
            Assert.AreEqual(devToAdd, devByID);
        }
    }
}
