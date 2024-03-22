using Outputer.Extensions;

namespace Outputer
{
    public class Output : EditableStringableList<IOutputable>
    {
        public bool IsEmpty => !Any;

        public Output(params IOutputable[] outputables)
            : base(outputables)
        {
        }

        public bool ExistsExclamation => Conversations.Any(c => c.HasExclamation);

        public bool ExistsQuestion => Conversations.Any(c => c.HasQuestion);

        public IEnumerable<string> SpeakersScript =>
            Conversations.Aggregate(new List<string>(), (list, conversation) =>
            {
                list.AddRange(conversation.SpeakersScript);
                return list;
            });

        public ISet<string> Speakers => SpeakersScript.ToHashSet();

        public string ProminentSpeaker => SpeakersScript.GetMoreFrequent();

        public IEnumerable<T> GetOutputablesOfType<T>()
            where T : IOutputable =>
            elements
                .OfType<T>()
                .ToList();

        public IEnumerable<Pharagraph> Pharagraphs => GetOutputablesOfType<Pharagraph>();

        public IEnumerable<Conversation> Conversations => GetOutputablesOfType<Conversation>();

        public void Add(Output output)
        {
            addAll(output);
        }

        public void AddIf(Func<bool> condition, Output output)
        {
            if (condition())
                Add(output);
        }

        public Output With(IOutputable outputable)
        {
            Add(outputable);
            return this;
        }

        public Output With(Output output)
        {
            Add(output);
            return this;
        }

        public Output WithIf(Func<bool> condition, IOutputable outputable)
        {
            AddIf(condition, outputable);
            return this;
        }

        public Output WithIf(Func<bool> condition, Output output)
        {
            AddIf(condition, output);
            return this;
        }

        public static Output FromTexts(params string[] texts)
        {
            var pharagraphs = texts
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => new Pharagraph(x))
                .ToArray();

            return new Output(pharagraphs);
        }

        public static Output FromSpeech(string speaker, string message)
        {
            if (string.IsNullOrWhiteSpace(speaker) || string.IsNullOrWhiteSpace(message))
                return Empty;

            return new Output(new Conversation().With(speaker, message));
        }

        public static Output Empty => new Output();
    }
}