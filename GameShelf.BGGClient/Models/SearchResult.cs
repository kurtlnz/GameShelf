using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GameShelf.BGGClient.Models
{
    public class SearchResult
    {
        public IEnumerable<SearchItem> Items { get; set; }
        public int TotalItems => Items.Count();
    }

    public class SearchItem
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string YearPublished { get; set; }
    }
}