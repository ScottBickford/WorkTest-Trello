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
  public class BoardControllerTest {
    [TestMethod]
    public void Controller_Board_Index() {
      // Arrange
      BoardController controller = new BoardController();
      Functions.SetAuthentication();

      // Act
      ViewResult result = controller.Index() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Controller_Board_BoardItem() {
      // Arrange
      BoardController controller = new BoardController();
      Functions.SetAuthentication();

      // Act
      ViewResult result = controller.BoardItem(new Engine.Models.BoardItemSubmitModel {ID = "eG1bb737" }) as ViewResult;  // Enter a valid board item for testing

      // Assert
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void Controller_Board_BoardItem_NotFound() {
      // Arrange
      BoardController controller = new BoardController();
      Functions.SetAuthentication();

      // Act
      Exception exception = null;
      try {
        ViewResult result = controller.BoardItem(new Engine.Models.BoardItemSubmitModel { ID = "2222" }) as ViewResult;  // Enter a valid board item for testing
      } catch (Exception ex) {
        exception = ex;
      }

      // Assert
      Assert.AreEqual("The remote server returned an error: (400) Bad Request.".ToUpper(), exception.Message.ToUpper());
    }
  }
}
