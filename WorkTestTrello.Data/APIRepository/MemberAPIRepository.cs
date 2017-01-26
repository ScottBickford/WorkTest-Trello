using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WorkTestTrello.Data.APIModel;

namespace WorkTestTrello.Data.APIRepository {
  public class MemberAPIRepository : BaseAPIRepository, IMemberAPIRepository {
    public MemberItemAPIModel GetMember() {
      return Get<MemberItemAPIModel>(string.Format("1/members/me?fields=username,fullName,url&key={0}&token={1}", c_application_key, c_auth_token));
    }
  }
}
