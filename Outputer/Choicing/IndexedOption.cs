namespace Outputer.Choicing
{
    public sealed class IndexedOption : Option
    {
        public IndexedOption(int index, string value, ChoiceFunction function, uint priority)
            : base (value, function, priority)
        {
            Index = index;
        }

        public bool IsEmpty => Index < 0;

        public int Index { get; }

        public override string ToString() =>
            IsEmpty
                ? string.Empty
                : $"{Index} - {Value}";

        public static IndexedOption Empty => new IndexedOption(-1, "-", () =>
        {
            return string.Empty;
        }, 0);

        public static IndexedOption FromOption(int index, Option option) =>
            new IndexedOption(index, option.Value, option.Function, option.Priority);
    }
}
