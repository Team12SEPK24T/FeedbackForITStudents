using System;
using System.Linq;
using FeedbackForITStudents.Models;
using FeedbackForITStudents.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace FeedbackForITStudents.Test.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        SEP24Team12Entities db = new SEP24Team12Entities();
        AccountController controller = new AccountController();

        [TestMethod]
        public void IndexTest()
        {
            //Arrange

            //Action
            ViewResult result = controller.Index() as ViewResult;
            var model = result.Model as List<TAIKHOAN>;
            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(expected: db.TAIKHOANs.Count(), actual: model.Count);
        }
    }
}
