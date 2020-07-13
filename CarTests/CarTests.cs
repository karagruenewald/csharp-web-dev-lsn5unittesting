using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarNS;
using System;

namespace CarTests
{
    [TestClass]
    public class CarTests
    {
        //TODO: add emptyTest so we can configure our runtime environment (remove this test before pushing to your personal GitHub account)
        [TestMethod]
        public void EmptyTest()
        {
            Assert.AreEqual(10, 10, .001);
        }


        Car test_car;
        int testGasTankSize;

        [TestInitialize]
        public void CreateCarObject()
        {
            testGasTankSize = 10; //Initial Gas Tank size
            test_car = new Car("Toyota", "Prius", testGasTankSize, 50);
        }



        //TODO: constructor sets gasTankLevel properly
        [TestMethod]
        public void TestInitialGasTank()
        {

            double actualOutput = test_car.GasTankLevel;
            double expectedOutput = testGasTankSize;

            Assert.AreEqual(expectedOutput, actualOutput, .001);
            Assert.IsFalse(actualOutput == 0);
            Assert.IsTrue(actualOutput == expectedOutput);

        }

        //TODO: gasTankLevel is accurate after driving within tank range

        [TestMethod]
        public void TestGasTankAfterDriving()
        {
            test_car.Drive(50);
            double actualOutput = test_car.GasTankLevel;
            Assert.AreEqual(9, actualOutput, .001);
            //Drive 50 miles
            //Verify gasTankLevel is set to the correct value after calling Drive(50)
        }



        //TODO: gasTankLevel is accurate after attempting to drive past tank range
        [TestMethod]
        public void TestGasTankAfterExceedingTankRange()
        {
            test_car.Drive(600);
            double actualOutput = test_car.GasTankLevel;
            Assert.AreEqual(0, actualOutput, .001);

            //tests that Odometer is at max
            double actualOdometer = test_car.Odometer;
            Assert.AreEqual(500, actualOdometer, .001);

        }

        //TODO: can't have more gas than tank size, expect an exception

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGasOverfillException()
        {
            test_car.AddGas(5);
            Assert.Fail("Shouldn't get here, car cannot have more gas in tank than the size of the tank");
        }

    }
}
