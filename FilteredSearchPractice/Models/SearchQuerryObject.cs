namespace FilteredSearchPractice.Models
{
    public enum Category
    {
        Music,
        Shows,
        Meetings
    }
    public enum Entry
    {
        free,
        paid
    }
    public class SearchQuerryObject
    {
        public string? Name { get; set; }
        public Category? Category { get; set; }
        public Entry? Entry { get; set; }
    }   
}
