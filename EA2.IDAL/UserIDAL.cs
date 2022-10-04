using EA2.Model;
using System;
using System.Collections.Generic;

namespace EA2.IDAL  //interface
{
    public interface UserIDAL
    {
        List<User> GetUserList();

        User GetUser(int userNo);

        bool SaveUser(User user);
    }
}
