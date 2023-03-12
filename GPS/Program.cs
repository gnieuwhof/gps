// See https://aka.ms/new-console-template for more information

using GPS;

double exampleLat = 52.3;
double exampleLong = 5.9;


Console.WriteLine("Example GPS Coordinates");
Console.WriteLine($"lat: {exampleLat}, long: {exampleLong}");

var rd = Converter.Wsg84ToRD(exampleLat, exampleLong);

double rdx = rd.Item1;
double rdy = rd.Item2;

Console.WriteLine();
Console.WriteLine("Converting GPS to Rijksdriehoekscoördinaten (Amersfoortcoördinaten)");
Console.WriteLine($"x: {rdx}, y: {rdy}");

var gps = Converter.RDToWsg84(rdx, rdy);

double lat = gps.Item1;
double lon = gps.Item2;

Console.WriteLine();
Console.WriteLine("Converting Rijksdriehoekscoördinaten tot GPS (WGS84)");
Console.WriteLine($"lat: {lat}, long: {lon}");

Console.ReadKey();
