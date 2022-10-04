using EA2.IDAL;
using EA2.Model;
using System;
using System.Collections.Generic;

namespace EA2.BLL
{
    public class UserBLL 
    {
        private readonly UserIDAL _userDal;     //Interface DAL로 설정하는거 매우 중요!!

        public UserBLL(UserIDAL _userDal)
        {
            this._userDal = _userDal;
        }

        public User GetUser(int userNo)
        {
            if(userNo <= 0)
            {
                throw new ArgumentException("userNo 오류");       //BLL에서는 validation 체크를 수행한다. 또한, throw된 값도 PL로 넘어간다
            }
            return _userDal.GetUser(userNo);        //리턴값은 PL로 넘겨준다.
        }

        public List<User> GetUserList()
        {
            return _userDal.GetUserList();
        }

        public bool SaveUser(User user)
        {
            if (user == null) throw new ArgumentNullException("유저 정보가 비어있습니다");
            return _userDal.SaveUser(user);
        }
    }
}
