namespace Outputer.Choicing
{
    public class Option
    {
        public Option(int index, string value, ChoiceFunction function)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));

            Index = index;
            Value = value;
            Function = function;
        }

        public int Index { get; }
        public string Value { get; }
        public ChoiceFunction Function { get; }

        public bool IsEmpty => Index < 0;

        public override string ToString() =>
            IsEmpty
                ? string.Empty
                : $"{Index} - {Value}";

        public static Option Empty => new Option(-1, "-", () =>
        {
            return string.Empty;
        });
    }
}
