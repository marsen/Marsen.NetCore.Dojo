﻿using System.Collections.Generic;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Exception;
using Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Users;

namespace Marsen.NetCore.Dojo.Books.Working_Effectively_with_Legacy_Code.Practice01.Trip;

public static class TripDao
{
    public static List<Trip> FindTripsByUser(User user)
    {
        throw new DependentClassCallDuringUnitTestException(
            "TripDAO should not be invoked on an unit test.");
    }
}