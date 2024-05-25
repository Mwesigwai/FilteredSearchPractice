
using FilteredSearchPractice.Models;

namespace FilteredSearchPractice.RequestHandlers
{
    public class AllHandler:BaseFilterHandler
    {
        public override List<SearchQuerryObject> Handle(SearchQuerryObject searchQuerryObject)
        {
            if(canHandle(searchQuerryObject))
            {
                return new List<SearchQuerryObject> {
                    new SearchQuerryObject
                    {
                        Category = Category.Meetings,
                        Entry = Entry.paid,
                        Name = "All handler handled this"
                    }, new SearchQuerryObject
                    {
                        Category = Category.Meetings,
                        Entry = Entry.paid,
                        Name = "event4"
                    }, new SearchQuerryObject
                    {
                        Category = Category.Meetings,
                        Entry = Entry.paid,
                        Name = "event3"
                    }, new SearchQuerryObject
                    {
                        Category = Category.Meetings,
                        Entry = Entry.paid,
                        Name = "Event2"
                    }, new SearchQuerryObject
                    {
                        Category = Category.Meetings,
                        Entry = Entry.paid,
                        Name = "Event2"
                    },
                };
            }
            return base.Handle(searchQuerryObject);
        }
        bool canHandle(SearchQuerryObject searchQuerryObject)
        {
            var nonnullCount = 0;
            var properties = searchQuerryObject.GetType().GetProperties();
            foreach (var item in properties)    
            {
                if (item.GetValue(searchQuerryObject) is not null)
                    nonnullCount += 1;
            }
            return nonnullCount == properties.Count();
        }
    }
}
