// See https://aka.ms/new-console-template for more information


using Day_2;

var ranges = RangeReader.ReadRanges();

var result = IdValidator.ValidateRanges(ranges);

Console.WriteLine($"Result is: {result}");

Console.ReadKey();
