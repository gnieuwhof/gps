// See https://aka.ms/new-console-template for more information

using GPS;

// Coordinates are random!!
var rd = Converter.Wsg84ToRD(52.3, 5.9);

Console.WriteLine("Coordinates are in CM (distance to 'de Onze Lieve Vrouwetoren')");

double rdX = Math.Round(rd.Item1, 1);
double rdY = Math.Round(rd.Item2, 1);

Console.WriteLine($"RDX: {rdX * 10}, RDY: {rdY * 10}");

Console.WriteLine();

var gps = Converter.RDToWsg84(rdX, rdY);

Console.WriteLine("GPS Coordinates");
Console.WriteLine($"lat: {gps.Item1}, Long: {gps.Item2}");

Console.ReadKey();
