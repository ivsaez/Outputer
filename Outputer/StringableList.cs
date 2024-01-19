using System.Text;

namespace Outputer
{
    public abstract class StringableList<T>
        where T : class
    {
        protected readonly List<T> elements;

        public StringableList()
        {
            elements = new List<T>();
        }

        public override string ToString()
        {
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
