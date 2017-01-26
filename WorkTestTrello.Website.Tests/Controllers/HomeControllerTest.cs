using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkTestTrello.Website;
using WorkTestTrello.Website.Controllers;

namespace WorkTestTrello.Website.Tests.Controllers {
  [TestClass]
  public class HomeControllerTest {
    [TestMethod]
    public void Controller_Home_Index() {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      ViewResult result = controller.Index() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Controller_Home_Authorise() {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      ViewResult result = controller.Authorise(new Engine.Models.AuthoriseSubmitModel { Token = Constants.Token }) as ViewResult;

      // Assert
      Assert.IsNotNull(result == null);
    }

    [TestMethod]
    public void Controller_Home_Authorise_Invalid() {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      Exception exception = null;
      try {
        ViewResult result = controller.Authorise(new Engine.Models.AuthoriseSubmitModel { Token = "2222" }) as ViewResult;
      } catch (Exception ex) {
        exception = ex;
      }

      // Assert
      Assert.AreEqual("The remote server returned an error: (401) Unauthorized.".ToUpper(), exception.Message.ToUpper());
    }


    [TestMethod]
    public void Controller_Home_Error() {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      ViewResult result = controller.Error(new Engine.Models.ErrorViewModel { ReferenceNum = 2 }) as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }
  }
}
