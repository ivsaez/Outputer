using System.Text;

namespace Outputer.Choicing
{
    public sealed class Choices
    {
        private readonly Dictionary<int, string> options;
        private readonly Dictionary<string, ChoiceFunction> actions;

        public IEnumerable<Option> Options =>
            options
                .Keys
                .Select(key => new Option(key, options[key], actions[options[key]]));

        public Choices()
        {
            options = new Dictionary<int, string>();
            actions = new Dictionary<string, ChoiceFunction>();
        }

        public (int Min, int Max) Range => (1, options.Count);

        public bool IsEmpty => !options.Any();

        public void Add(string option, ChoiceFunction function)
        {
            if (actions.ContainsKey(option))
                throw new ArgumentException($"Option '{option}' already added.");

            if (!string.IsNullOrWhiteSpace(option))
            {
                int index = options.Count + 1;
                options.Add(index, option);
                actions.Add(option, function);
            }
        }

        public Choices With(string option, ChoiceFunction function)
        {
            Add(option, function);
            return this;
        }

        public Option Select(Input input)
        {
            if (!options.ContainsKey(input.ChoiceIndex))
                return Option.Empty;

            return new Option(input.ChoiceIndex, options[input.ChoiceIndex], actions[options[input.ChoiceIndex]]);
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
