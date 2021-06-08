using System;
using System.Linq;
using FeedbackForITStudents.Models;
using FeedbackForITStudents.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.Mvc;

namespace FeedbackForITStudents.Test.Controllers
{
    [TestClass]
    public class AuthControllerTest
    {
        FBFORITSTUDENTSEntities db = new FBFORITSTUDENTSEntities();
        AuthController controller = new AuthController();
        AdminHomeController adminhome = new AdminHomeController();

        [TestMethod]
        public void LoginSucessfully()
        {
            //Arrange
            string email = "phuongng@vlu.edu.vn";
            String password = "123456";
            //Action
            ViewResult result = adminhome.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
