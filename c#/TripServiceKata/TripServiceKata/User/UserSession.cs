using TripServiceKata.Exception;

namespace TripServiceKata.User
{
    public interface IUserSession
    {
        bool IsUserLoggedIn(User user);
        User GetLoggedUser();
    }

    public class UserSession : IUserSession
    {
        private static readonly UserSession userSession = new UserSession();

        protected UserSession() { }

        public static UserSession GetInstance()
        {
            return userSession;
        }

        public bool IsUserLoggedIn(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.IsUserLoggedIn() should not be called in an unit test");
        }

        public virtual User GetLoggedUser()
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }

    public class UserSessionNull : IUserSession
    {
        public static UserSessionNull GetInstance()
        {
            return new UserSessionNull();
        }

        public bool IsUserLoggedIn(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetLoggedUser()
        {
            return null;
        }
    }

    public class UserSessionNotFriends : IUserSession
    {
        public static UserSessionNotFriends GetInstance()
        {
            return new UserSessionNotFriends();
        }

        public bool IsUserLoggedIn(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetLoggedUser()
        {
            return new User();
        }
    }

    public class UserSessionWithFriends : IUserSession
    {
        private User _user;

        public UserSessionWithFriends()
        {
            _user = new User();
        }

        public static UserSessionWithFriends GetInstance()
        {
            return new UserSessionWithFriends();
        }

        public bool IsUserLoggedIn(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetLoggedUser()
        {
            return _user;
        }
    }
}
