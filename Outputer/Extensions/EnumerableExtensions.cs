namespace Outputer.Extensions
{
    internal static class EnumerableExtensions
    {
        internal static string GetMoreFrequent(this IEnumerable<string> elements)
        {
            var frequencies = new Dictionary<string, int>();
            foreach (var element in elements)
            {
                if (!frequencies.ContainsKey(element))
                    frequencies.Add(element, 0);

                frequencies[element]++;
            }

            string selected = string.Empty;
            int maxFrequency = int.MinValue;
            foreach (var (element, frequency) in frequencies)
            {
                if (frequency > maxFrequency)
                {
                    maxFrequency = frequency;
                    selected = element;
                }
            }

            return selected;
        }
    }
}
