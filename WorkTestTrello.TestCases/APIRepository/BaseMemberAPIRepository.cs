using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;
using WorkTestTrello.Data.APIRepository;

namespace WorkTestTrello.TestCases.APIRepository {
  public abstract class BaseMemberAPIRepository : IMemberAPIRepository {
    public string Token { get; set; }

    public virtual MemberItemAPIModel GetMember() {
      throw new NotImplementedException();
    }
  }
}
