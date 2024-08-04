using MobileWords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileWords.Services
{
    public class WordsDataStore : IDataStore<QueryResult>
    {
        private readonly List<QueryResult> items;

        public WordsDataStore()
        {
            items = new List<QueryResult>();

        }

        public async Task<bool> AddItemAsync(QueryResult item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(QueryResult item)
        {
            var oldItem = items.Where((QueryResult arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((QueryResult arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<QueryResult> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<QueryResult>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> ClearItemsAsync()
        {
            items.Clear();
            return await Task.FromResult(true);
        }
    }
}