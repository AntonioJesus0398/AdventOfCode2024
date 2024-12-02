namespace AdventOfCode._1
{
    /// <summary>
    /// Puzzle description: https://adventofcode.com/2024/day/1
    /// </summary>
    public static class Problem1
    {
        private static (List<int>, List<int>) ReadInput() 
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "1\\input.txt"); ;
            var left = new List<int>();
            var right = new List<int>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    break;

                var parts = line.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var (first, second) = (int.Parse(parts.First()), int.Parse(parts.Last()));
                left.Add(first);
                right.Add(second);
            }

            return (left, right);
        }

        public static int SolveFirst()
        {
            var (left, right) = ReadInput();

            left.Sort();
            right.Sort();

            return left
                .Zip(right, (first, second) => Math.Abs(first - second))
                .Sum();
        }

        public static int SolveSecond()
        {
            var (left, right) = ReadInput();

            var quantities = right
                .GroupBy(x => x)
                .Select(x => new { Value = x.Key, Count = x.Count() });

            return left
                .Join(
                    quantities,
                    x => x,
                    y => y.Value,
                    (x, y) => y)
                .Select(z => z.Value * z.Count)
                .Sum();
        }
    }
}
