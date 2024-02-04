namespace Outputer.Choicing
{
    public sealed class Input
    {
        public int ChoiceIndex { get; }

        public bool IsVoid => ChoiceIndex < 0;

        public Input(int choiceIndex)
        {
            ChoiceIndex = choiceIndex;
        }

        public Input(int choiceIndex, (int Min, int Max) range)
            : this(choiceIndex)
        {
            if (choiceIndex < range.Min || choiceIndex > range.Max)
                throw new ArgumentException(nameof(choiceIndex));
        }

        public static Input Void =>
            new Input(-1);
    }
}
