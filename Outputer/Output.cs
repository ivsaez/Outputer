using Outputer.Extensions;

namespace Outputer
{
    public class Output : EditableStringableList<IOutputable>
    {
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
    }
}