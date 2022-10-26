using AirplaneSeating;

TestTrippleReservation(2, "1A 2F 1C");
TestTrippleReservation(3, "1A 2f 1c 3J");
TestTrippleReservation(4, "1A 2F 1C");
TestTrippleReservation(50, "1A 2F 1C");
TestTrippleReservation(50, "");
TestTrippleReservation(0, "");
TestTrippleReservation(5, "1A 3C 2B 4G 5A ");
TestTrippleReservation(6, "1A 3C 2B 4G 5A 2B 4G");
TestTrippleReservation(1, "1A 1F 1C");
TestTrippleReservation(1, "1A 1F 1C 1K");
TestTrippleReservation(2, "2A 2F 2C");
TestTrippleReservation(3, "2A 2F 2C 2K");
TestTrippleReservation(4, " 2F 2K");
TestTrippleReservation(5, " 2F 2K ");
TestTrippleReservation(50, " 1f 2K 50J 50f");
TestTrippleReservation(51, " 1f 2K 50J 50f 51a");

Console.ReadLine();

static void TestTrippleReservation(int rows, string reservedSeats)
{
    var trippleReservation = new TrippleReservation();
    var count = trippleReservation.GetTripleSeatsCount(rows, reservedSeats);

    Console.WriteLine($"Input: {rows} {reservedSeats}");
    Console.WriteLine($"The Number of Family-of-3 that can be seated: {count}");
}