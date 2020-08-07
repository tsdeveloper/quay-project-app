namespace Core.Entities
{
    public class BaseSpecParams : BaseEntity
    {
        private string _search;

        public string Sort { get; set; }
        public string Search { get => _search; set => _search = value.ToLower(); }
    }
}