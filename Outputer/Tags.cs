namespace Outputer
{
    public class Tags
    {
        private readonly ISet<string> tags;

        public Tags(params string[] tags)
        {
            this.tags = new HashSet<string>();
            
            foreach (var tag in tags)
                Add(tag);
        }

        public void Add(string tag)
        {
            if(!string.IsNullOrWhiteSpace(tag)) 
                tags.Add(tag);
        }

        public bool Has(string tag) => tags.Contains(tag);
    }
}
