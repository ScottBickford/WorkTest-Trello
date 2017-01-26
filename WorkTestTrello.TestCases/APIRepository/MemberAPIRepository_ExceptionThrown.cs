using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;
using WorkTestTrello.Data.APIRepository;

namespace WorkTestTrello.TestCases.APIRepository {
  /// <summary>
  /// Test Case: Exception Thrown
  /// </summary>
  public class MemberAPIRepository_ExceptionThrown : BaseMemberAPIRepository {
    public override MemberItemAPIModel GetMember() {
      throw new Exception("Generated Exception for Testing");
    }
  }
}
