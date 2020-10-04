using System.Collections.Generic;
using System.ComponentModel;

namespace GameShelf.BGGClient.Models
{
    public class SearchResult
    {
        public ICollection<SearchItem> Items { get; set; }
        public int TotalItems => Items.Count;
    }

    public class SearchItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string YearPublished { get; set; }
    }
}