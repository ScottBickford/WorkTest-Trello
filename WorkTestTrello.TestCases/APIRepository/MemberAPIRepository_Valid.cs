using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;
using WorkTestTrello.Data.APIRepository;

namespace WorkTestTrello.TestCases.APIRepository {
  /// <summary>
  /// Test Case: Return valid credentials
  /// </summary>
  public class MemberAPIRepository_Valid : BaseMemberAPIRepository {
    public override MemberItemAPIModel GetMember() {
      return new MemberItemAPIModel {
        id = "1",
        name = "testcase",
        fullName = "Test Case",
        url = "url1",
        username = "testcase"
      };
    }
  }
}
