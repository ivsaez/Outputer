using System.Text;

namespace Outputer.Choicing
{
    public sealed class Choices
    {
        private readonly List<Option> options;
        private readonly ISet<int> addedOptions;

        public IEnumerable<IndexedOption> Options => 
            options.Select((option, index) => IndexedOption.FromOption(index + 1, option));

        public Choices()
        {
            options = new List<Option>();
            addedOptions = new HashSet<int>();
        }

        public (int Min, int Max) Range => (1, options.Count);

        public bool IsEmpty => !options.Any();

        public void Add(string option, ChoiceFunction function, uint priority = 0)
        {
            if(string.IsNullOrWhiteSpace(option))
                throw new ArgumentNullException(nameof(option));

            var optionItem = new Option(option, function, priority);

            if(addedOptions.Contains(optionItem.GetHashCode()))
                throw new ArgumentException($"Option '{option}' already added.");

            options.Add(optionItem);

            options.Sort();
        }

        public Choices With(string option, ChoiceFunction function, uint priority = 0)
        {
            Add(option, function, priority);
            return this;
        }

        public IndexedOption Select(Input input)
        {
            if (input.ChoiceIndex < Range.Min || input.ChoiceIndex > Range.Max)
                return IndexedOption.Empty;

            var option = options[input.ChoiceIndex - 1];

            return IndexedOption.FromOption(input.ChoiceIndex, option);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var option in Options)
            {
                builder.AppendLine(option.ToString());
            }

            return builder.ToString();
        }
    }
}
