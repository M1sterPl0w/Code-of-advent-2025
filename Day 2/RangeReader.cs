namespace Day_2
{
	internal static class RangeReader
	{
		public static IEnumerable<string> ReadRanges(string fileName = "ranges.txt")
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);


			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			var ranges = File.ReadAllText(path);

			return ranges.Split(',');
		}
	}
}
