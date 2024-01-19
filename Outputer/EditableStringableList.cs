namespace Outputer
{
    public abstract class EditableStringableList<T> : StringableList<T>
        where T : class
    {
        public EditableStringableList(params T[] elems)
            : base()
        {
            foreach (var elem in elems)
            {
                Add(elem);
            }
        }

        public void Add(T element)
        {
            if (IsValidElement(element))
                elements.Add(element);
        }

        public void AddIf(Func<bool> condition, T element)
        {
            if (condition())
                Add(element);
        }

        protected void addAll(EditableStringableList<T> list)
        {
            foreach (var element in list.elements)
            {
                elements.Add(element);
            }
        }

        protected virtual bool IsValidElement(T element) => true;
    }
}
