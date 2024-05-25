using FilteredSearchPractice.Models;
using FilteredSearchPractice.RequestHandlers;
using Microsoft.AspNetCore.Components;

namespace FilteredSearchPractice.RequestHandlers
{
    public class BaseFilterHandler : IHandler
    {
        IHandler _nextHandler = null!;
        virtual public List<SearchQuerryObject> Handle(SearchQuerryObject searchQuerryObject)
        {
           return _nextHandler?.Handle(searchQuerryObject)!;
        }

        public IHandler SetNext(IHandler handler)
        {
            return _nextHandler = handler;
        }
    }
}
