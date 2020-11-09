using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripDAO
    {
        public static List<Trip> FindTripsByUser(IUser user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }

        public virtual List<Trip> FindTripsByUserFake(IUser user)
        {
            return new List<Trip>();
        }
    }

    public class TripDaoFake : TripDAO
    {
        public override List<Trip> FindTripsByUserFake(IUser user)
        {
            return new List<Trip>{new Trip()};
        }
    }

}
