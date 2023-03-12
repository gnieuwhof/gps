namespace GPS
{
    public static class Converter
    {
        // The city "Amsterfoort" is used as reference "WGS84" coordinate.
        public const double REFERENCE_WGS_84_LAT = 52.15517440;
        public const double REFERENCE_WGS_84_LONG = 5.38720621;

        // The city "Amsterfoort" is used as reference "Rijksdriehoek" coordinate.
        public const int REFERENCE_RD_X = 155000;
        public const int REFERENCE_RD_Y = 463000;


        public static Tuple<double, double> Wsg84ToRD(double lat, double lon)
        {
            // https://forum.geocaching.nl/topic/7886-co%C3%B6rdinaat-transformaties-rd-wgs/page/3/#comment-118486

            double df = 0.36 * (lat - REFERENCE_WGS_84_LAT);
            double dl = 0.36 * (lon - REFERENCE_WGS_84_LONG);

            double sumX =
                (190094.945 * dl) +
                (-11832.228 * df * dl) +
                (-144.221 * Math.Pow(dl, 2) * dl) +
                (-32.391 * Math.Pow(dl, 3)) +
                (-0.705 * df) +
                (-2.34 * Math.Pow(dl, 3) * dl) +
                (-0.608 * df * Math.Pow(dl, 3)) +
                (-0.008 * Math.Pow(dl, 2)) +
                (0.148 * Math.Pow(dl, 2) * Math.Pow(dl, 3));

            double sumY =
                (309056.544 * df) +
                (3638.893 * Math.Pow(dl, 2)) +
                (73.077 * Math.Pow(dl, 2)) +
                (-157.984 * df * Math.Pow(dl, 2)) +
                (59.788 * Math.Pow(dl, 3)) +
                (0.433 * dl) +
                (-6.439 * Math.Pow(dl, 2) * Math.Pow(dl, 2)) +
                (-0.032 * df * dl) +
                (0.092 * Math.Pow(dl, 4)) +
                (-0.054 * df * Math.Pow(dl, 4));

            double rdX = 155000 + sumX;
            double rdY = 463000 + sumY;

            var result = Tuple.Create(rdX, rdY);

            return result;
        }


        public static Tuple<double, double> RDToWsg84(double rdx, double rdy)
        {
            // https://forum.geocaching.nl/topic/7886-co%C3%B6rdinaat-transformaties-rd-wgs/page/3/#comment-118486
            // https://github.com/djvanderlaan/rijksdriehoek/blob/master/Python/rijksdriehoek.py

            double dX = (rdx - REFERENCE_RD_X) * Math.Pow(10, -5);
            double dY = (rdy - REFERENCE_RD_Y) * Math.Pow(10, -5);

            double sumN =
                (3235.65389 * dY) +
                (-32.58297 * Math.Pow(dX, 2)) +
                (-0.2475 * Math.Pow(dY, 2)) +
                (-0.84978 * Math.Pow(dX, 2) * dY) +
                (-0.0655 * Math.Pow(dY, 3)) +
                (-0.01709 * Math.Pow(dX, 2) * Math.Pow(dY, 2)) +
                (-0.00738 * dX) +
                (0.0053 * Math.Pow(dX, 4)) +
                (-0.00039 * Math.Pow(dX, 2) * Math.Pow(dY, 3)) +
                (0.00033 * Math.Pow(dX, 4) * dY) +
                (-0.00012 * dX * dY);

            double sumE =
                (5260.52916 * dX) +
                (105.94684 * dX * dY) +
                (2.45656 * dX * Math.Pow(dY, 2)) +
                (-0.81885 * Math.Pow(dX, 3)) +
                (0.05594 * dX * Math.Pow(dY, 3)) +
                (-0.05607 * Math.Pow(dX, 3) * dY) +
                (0.01199 * dY) +
                (-0.00256 * Math.Pow(dX, 3) * Math.Pow(dY, 2)) +
                (0.00128 * dX * Math.Pow(dY, 4)) +
                (0.00022 * Math.Pow(dY, 2)) +
                (-0.00022 * Math.Pow(dX, 2)) +
                (0.00026 * Math.Pow(dX, 5));

            double lat = REFERENCE_WGS_84_LAT + (sumN / 3600);
            double lon = REFERENCE_WGS_84_LONG + (sumE / 3600);

            var result = Tuple.Create(lat, lon);

            return result;
        }
    }
}
