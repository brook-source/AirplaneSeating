using static AirplaneSeating.Data;

namespace AirplaneSeating
{
    internal class TrippleReservation
    {
        private const int MAX_ROWS = 50;

        private static Dictionary<Column, Group> ColumnToGroupMap = new()
        {
            {Column.A, Group.G1 },
            {Column.B, Group.G1 },
            {Column.C, Group.G1 },
            {Column.D, Group.G2 },
            {Column.E, Group.G2 },
            {Column.F, Group.G2 },
            {Column.G, Group.G2 },
            {Column.H, Group.G3 },
            {Column.J, Group.G3 },
            {Column.K, Group.G3 },
        };

        private static Dictionary<Column, int> ColumnToWeightMap = new()
        {
            {Column.A, 2 },
            {Column.B, 2 },
            {Column.C, 2 },
            {Column.D, 1 }, // Quadruple aisle seat
            {Column.E, 2 },
            {Column.F, 2 },
            {Column.G, 1 }, // Quadruple aisle seat
            {Column.H, 2 },
            {Column.J, 2 },
            {Column.K, 2 },
        };

        public int GetTripleSeatsCount(int rows, string reservedSeats)
        {
            var invalidRows = GetInvalidRowsForTrippleSeatting(reservedSeats);
            rows = Math.Min(rows, MAX_ROWS);

            return (rows * 3) - invalidRows;
        }

        private int GetInvalidRowsForTrippleSeatting(string reservedInput)
        {
            Dictionary<SeatInfo, int> groupKeyToTotalWeightMap = new();
            var reservedSeats = reservedInput.Trim()
                                             .ToUpper()
                                             .Split(" ")
                                             .Distinct();
            foreach (var seat in reservedSeats)
            {
                if (TryParseSeatInfo(seat, out var seatInfo, out var column))
                {
                    if (seatInfo.Row > MAX_ROWS)
                    {
                        continue;
                    }

                    groupKeyToTotalWeightMap.TryGetValue(seatInfo, out var totalWeight);
                    totalWeight += ColumnToWeightMap[column];
                    groupKeyToTotalWeightMap[seatInfo] = totalWeight;
                }
            }
            return groupKeyToTotalWeightMap.Where(x => x.Value >= 2)
                                           .Count();
        }

        private static bool TryParseSeatInfo(string seat, out SeatInfo seatInfo, out Column column)
        {
            try
            {
                string columnChar = seat[^1..];
                string rowChar = seat.Replace(columnChar, string.Empty);

                bool rowParsed = int.TryParse(rowChar, out var row);
                bool columnParsed = Enum.TryParse(columnChar, out column);

                seatInfo = new()
                {
                    Row = row,
                    Group = ColumnToGroupMap[column]
                };

                return rowParsed && columnParsed;
            }
            catch (Exception)
            {
                seatInfo = default;
                column = default;
                return false;
            }
        }
    }
}
