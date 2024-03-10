namespace Outputer.Choicing
{
    public class Option : IComparable<Option>
    {
        public Option(string value, ChoiceFunction function, uint priority)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));

            Value = value;
            Function = function;
            Priority = priority;
        }
        
        public string Value { get; }
        public ChoiceFunction Function { get; }
        public uint Priority { get; }

        public override int GetHashCode() =>
            Value.GetHashCode();

        public int CompareTo(Option? other)
        {
            if (other is null) return -1;

            if(other.Priority == Priority) return 0;

            if(other.Priority > Priority) return 1;

            return -1;
        }
    }
}
