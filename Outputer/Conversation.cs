using Outputer.Extensions;

namespace Outputer
{
    public class Conversation : StringableList<ConversationLine>, IOutputable
    {
        public Conversation()
            : base()
        {
        }

        public bool HasExclamation => elements.Any(e => e.IsExcalamation);

        public bool HasQuestion => elements.Any(e => e.IsQuestion);

        public IEnumerable<string> SpeakersScript => elements.Select(element => element.Speaker).ToList();

        public ISet<string> Speakers => SpeakersScript.ToHashSet();

        public string ProminentSpeaker => SpeakersScript.GetMoreFrequent();

        public void Add(string speaker, string message)
        {
            elements.Add(new ConversationLine(speaker, message));
        }

        public void AddIf(Func<bool> condition, string speaker, string message)
        {
            if(condition())
                Add(speaker, message);
        }

        public void Add(Conversation conversation)
        {
            foreach (var item in conversation.elements)
            {
                elements.Add(item);
            }
        }

        public void AddIf(Func<bool> condition, Conversation conversation)
        {
            if(condition())
                Add(conversation);
        }

        public Conversation With(string speaker, string message)
        {
            Add(speaker, message);
            return this;
        }

        public Conversation WithIf(Func<bool> condition, string speaker, string message)
        {
            AddIf(condition, speaker, message);
            return this;
        }

        public Conversation With(Conversation conversation)
        {
            Add(conversation);
            return this;
        }

        public Conversation WithIf(Func<bool> condition, Conversation conversation)
        {
            AddIf(condition, conversation);
            return this;
        }
    }

    public class ConversationLine
    {
        public ConversationLine(string speaker, string message)
        {
            if (string.IsNullOrWhiteSpace(speaker))
                throw new ArgumentNullException(nameof(speaker));

            if (!string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(speaker));

            Speaker = speaker;
            Message = message;
        }

        public string Speaker { get; }
        public string Message { get; }

        public bool IsExcalamation => Message.Contains("¡") || Message.Contains("!");

        public bool IsQuestion => Message.Contains("¿") || Message.Contains("?");

        public override string ToString() =>
            $"{Speaker}: - {Message}";
    }
}
