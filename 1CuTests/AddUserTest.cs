using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _1cuTests
{
    [TestClass]
    public class AddUserTest
    {
        [TestMethod]
        public void EmptyFields()
        {
            var name = "";
            var password = "";
            var rights = "0";

            var result = _1C.U.AddUserForm.GetNewUserInfo(name, password, rights);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void EmptyFieldName()
        {
            var name = "";
            var password = "34";
            var rights = "0";

            var result = _1C.U.AddUserForm.GetNewUserInfo(name, password, rights);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void OrdinaryRequest()
        {
            var name = "Admin";
            var password = "34Ar";
            var rights = "1";

            var result = _1C.U.AddUserForm.GetNewUserInfo(name, password, rights);

            Assert.AreEqual("'Admin', '34Ar', 1", result);
        }

        [TestMethod]
        public void VeryLongName()
        {
            var name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var password = "";
            var rights = "0";

            var result = _1C.U.AddUserForm.GetNewUserInfo(name, password, rights);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void VeryLongPassword()
        {
            var name = "admin";
            var password = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            var rights = "0";

            var result = _1C.U.AddUserForm.GetNewUserInfo(name, password, rights);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void AdminWithoutPassword()
        {
            var name = "admin";
            var password = "";
            var rights = "1";

            var result = _1C.U.AddUserForm.GetNewUserInfo(name, password, rights);

            Assert.AreEqual(null, result);
        }
    }
}
