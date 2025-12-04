namespace Day_2
{
	internal static class IdValidator
	{
		public static long ValidateRanges(IEnumerable<string> ranges)
		{
			long total = 0;
			foreach (var range in ranges)
			{
				var splittedRange = range.Split('-');
				var min = long.Parse(splittedRange[0]);
				var max = long.Parse(splittedRange[1]);

				var counter = min;

				while (counter <= max)
				{
					var counterStr = counter.ToString();
					if (counterStr.Length % 2 != 0)
					{
						counter++;
						continue;
					}

					var counterStrLeft = counterStr.Substring(0, counterStr.Length / 2);
					var counterStrRight = counterStr.Substring((counterStr.Length / 2));

					if (counterStrLeft == counterStrRight)
					{
						total += counter;
					}

					counter++;
				}
			}

			return total;
		}
	}
}
