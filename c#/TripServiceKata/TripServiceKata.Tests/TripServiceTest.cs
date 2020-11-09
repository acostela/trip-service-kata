using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;

namespace TripServiceKata.Tests
{
    public class TripServiceTest
    {
        [Test]
        public void GetTripsByUser_WhenUserIsNotLoggedItMustThrownAnException()
        {
            var user = new User.User();
            var tripService = new TripService();
            var userSessionMock = new Mock<IUserSession>();

            userSessionMock.Setup(x => x.GetLoggedUser()).Returns(() => null);

            Assert.Throws<UserNotLoggedInException>(() => tripService.GetTripsByUser(user, userSessionMock.Object));
        }

        [Test]
        public void GetTripsByUser_WhenUserIsLogged_EmptyListOfFriends()
        {
            var user = new User.User();
            var tripService = new TripService();
            var userSessionMock = new Mock<IUserSession>();

            userSessionMock.Setup(x => x.GetLoggedUser()).Returns(new User.User());

            var tripList = tripService.GetTripsByUser(user, userSessionMock.Object);

            Assert.AreEqual(0, tripList.Count);
        }

        [Test]
        public void GetTripsByUser_WhenUserIsLogged_NotEmptyListOfFriends()
        {
            var user = new User.User();

            user.AddFriend(new User.User());

            var userMock = new Mock<IUser>();
            userMock.Setup(x => x.GetFriends()).Returns(new List<User.User>{user});
            var userSessionMock = new Mock<IUserSession>();
            userSessionMock.Setup(x => x.GetLoggedUser()).Returns(user);

            var tripService = new TripService();

            var tripList = tripService.GetTripsByUser(userMock.Object, userSessionMock.Object, new TripDaoFake());

            Assert.AreEqual(1, tripList.Count);
        }

    }
}
