using FilteredSearchPractice.Models;

namespace FilteredSearchPractice.RequestHandlers
{
    public interface IHandler
    {
        List<SearchQuerryObject> Handle(SearchQuerryObject searchQuerryObject);
        IHandler SetNext(IHandler handler);
    }
}