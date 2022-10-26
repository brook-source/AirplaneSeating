namespace AirplaneSeating
{
    internal class Data
    {
        internal enum Column
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            J,
            K,
        }

        internal enum Group
        {
            G1,
            G2,
            G3,
        }

        internal struct SeatInfo
        {
            internal int Row;
            internal Group Group;
        }
    }
}
