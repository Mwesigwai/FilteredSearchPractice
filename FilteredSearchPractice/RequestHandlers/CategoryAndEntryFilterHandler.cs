using FilteredSearchPractice.Models;
using FilteredSearchPractice.RequestHandlers;
using Microsoft.AspNetCore.HttpLogging;
using System.Linq;
using System.Reflection;

namespace FilteredSearchPractice.RequestHandlers
{
    public class CategoryAndEntryFilterHandler:BaseFilterHandler
    {
        public override List<SearchQuerryObject> Handle(SearchQuerryObject searchQuerryObject)
        {
            if (canHandle(searchQuerryObject))
            {
                return new List<SearchQuerryObject> 
                { 
                    new SearchQuerryObject
                    {
                        Category = Category.Meetings,
                        Entry = Entry.paid,
                        Name = "Event2"
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
        private bool canHandle(SearchQuerryObject obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            var foundCategories = false;
            var founEntry = false;
            int nonNullsCount = 0;

            foreach (var item in properties)    
            {
                if(item.GetValue(obj) is not null)
                {
                    nonNullsCount += 1;
                    if (item.Name is nameof(Category))
                        foundCategories = true;
                    if (item.Name is nameof(Entry))
                        founEntry = true;
                    if (nonNullsCount > 2)
                        return false;

                }
            }
            return nonNullsCount == 2 && foundCategories && founEntry;

        }
    }
}
