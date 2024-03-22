using System.Text;

namespace Outputer
{
    public class Pharagraph : EditableStringableList<string>, IOutputable
    {
        public bool IsEmpty => !Any;

        public Pharagraph(params string[] texts)
            : base(texts)
        {
        }

        public void Add(Pharagraph pharagraph)
        {
            if(pharagraph.Any)
                addAll(pharagraph);
        }

        public void AddIf(Func<bool> condition, Pharagraph pharagraph)
        {
            if (condition())
                Add(pharagraph);
        }

        public Pharagraph With(string text)
        {
            Add(text);
            return this;
        }

        public Pharagraph With(Pharagraph pharagraph)
        {
            Add(pharagraph);
            return this;
        }

        public Pharagraph WithIf(Func<bool> condition, string text)
        {
            AddIf(condition, text);
            return this;
        }

        public Pharagraph WithIf(Func<bool> condition, Pharagraph pharagraph)
        {
            AddIf(condition, pharagraph);
            return this;
        }

        protected override bool IsValidElement(string element) => !string.IsNullOrEmpty(element);

        protected override StringBuilder AddToBuilder(StringBuilder builder, string element) =>
            builder.Append(element);
    }
}
