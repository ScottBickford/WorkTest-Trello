using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WorkTestTrello.Data.APIRepository;
using WorkTestTrello.Data.APIModel;

namespace WorkTestTrello.Website.Tests.Repositories {
  [TestClass]
  public class MemberRepository {
    [TestMethod]
    public void APIRepository_Member_Index() {
      // Arrange
      MemberAPIRepository repository = new MemberAPIRepository();
      repository.Token = Constants.Token;

      // Act
      var result = repository.GetMember();

      // Assert
      Assert.IsNotNull(result);
    }
  }
}
