namespace Day_6
{
	internal static class ElfMathCalculator
	{
		public static long CalculatePartOne()
		{
			long result = 0;

			var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			var lines = File.ReadLines(path).ToArray();


			var newLines = Enumerable.Range(0, lines.Length)
								.Select(x => lines[x].Split(' ', StringSplitOptions.RemoveEmptyEntries))
								.ToList();

			var columns = Enumerable.Range(0, newLines[0].Length)
					.Select(x => newLines.Select(row => row[x]).ToList());

			foreach (var column in columns)
			{

				var op = column.Last() == "*" ? Operator.Multiply : Operator.Plus;
				long subResult = op == Operator.Multiply ? 1 : 0;

				foreach (var row in column.Take(column.Count - 1))
				{
					if (op == Operator.Multiply)
					{
						subResult *= long.Parse(row);

					}
					else if (op == Operator.Plus)
					{
						subResult += long.Parse(row);
					}
				}

				result += subResult;
			}

			return result;
		}


		public static long CalculatePartTwo()
		{
			long result = 0;

			var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
			if (!File.Exists(path))
			{
				throw new FileNotFoundException($"File not found: {path}");
			}

			var lines = File.ReadLines(path).ToArray();
			var maxLineLength = lines.Max(x => x.Length);

			var lastOperator = Operator.None;
			long subresult = 0;
			for (int i = 0; i < maxLineLength; i++)
			{
				if (i < lines[lines.Length - 1].Length)
				{
					if (lines[lines.Length - 1][i] == '+')
					{
						lastOperator = Operator.Plus;
						result += subresult;
						subresult = 0;
					}
					else if (lines[lines.Length - 1][i] == '*')
					{
						lastOperator = Operator.Multiply;
						result += subresult;
						subresult = 1; // Multiplying with 0 is useless 
					}
				}
				var number = string.Empty;

				for (int j = 0; j < lines.Length - 1; j++)
				{
					if (char.IsNumber(lines[j][i]))
					{
						number += lines[j][i];
					}
				}

				if (!string.IsNullOrWhiteSpace(number))
				{
					if (lastOperator == Operator.Plus)
					{
						subresult += long.Parse(number);
					}
					else if (lastOperator == Operator.Multiply)
					{
						subresult *= long.Parse(number);
					}
				}
			}

			result += subresult;

			return result;
		}

		public enum Operator
		{
			Plus, Multiply, None
		}
	}
}
