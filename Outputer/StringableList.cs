using System.Text;

namespace Outputer
{
    public abstract class StringableList<T>
        where T : class
    {
        protected readonly List<T> elements;

        public bool Any => elements.Any();

        public StringableList()
        {
            elements = new List<T>();
        }

        public override string ToString()
        {
            if(!Any)
                return string.Empty;

            var builder = new StringBuilder();
            foreach (var element in elements)
            {
                AddToBuilder(builder, element.ToString()!);
            }

            return builder.ToString();
        }

        protected virtual StringBuilder AddToBuilder(StringBuilder builder, string element) => builder.AppendLine(element);
    }
}
