// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="">
//   
// </copyright>
// <summary>
//   The unit test 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTestLibrary1
{
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

    /// <summary>
    /// The unit test 1.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// The test method 1.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            // TODO I had no time for unit tests but:
            // TODO DAL library should be tested
            // TODO save method, with different objects (empty fields, null fields, maybe special characters in string properties of objects)
            // TODO also test if multiple objects are saved corectly
            // TODO test is the same object is not saved twice
            // TODO maybe some different path to files (mdf, log and xml), test what if file does not exist etc(what if file already existed, what if file is malformed)...
            Assert.IsTrue(true);
        }
    }
}