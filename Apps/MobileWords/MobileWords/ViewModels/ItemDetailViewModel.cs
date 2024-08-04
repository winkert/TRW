using MobileWords.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileWords.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId = string.Empty;
        private string _word = string.Empty;
        private string _definition = string.Empty;
        private string _parsingInfo = string.Empty;
        private string _form = string.Empty;
        private string _allForms = string.Empty;

        public string Id { get; set; }

        public string DictionaryWord
        {
            get => _word;
            set => SetProperty(ref _word, value);
        }

        public string Definition
        {
            get => _definition;
            set => SetProperty(ref _definition, value);
        }

        public string ParsingInformation
        {
            get => _parsingInfo;
            set => SetProperty(ref _parsingInfo, value);
        }

        public string Form
        {
            get => _form;
            set => SetProperty(ref _form, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public string AllForms 
        {
            get => _allForms;
            set => SetProperty(ref _allForms, value);
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                QueryResult item = await DataStore.GetItemAsync(itemId);
                if (item == null)
                    return;

                Id = item.Id;
                DictionaryWord = item.DictionaryWord;
                Definition = item.Definition;
                ParsingInformation = item.FormParsing;
                Form = item.Form;
                AllForms = item.GetAllFormsString();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to Load Item [{itemId}]. Exception: [{e}]");
            }
        }
    }
}
