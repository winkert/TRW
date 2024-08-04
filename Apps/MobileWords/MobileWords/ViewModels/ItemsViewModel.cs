using MobileWords.Models;
using MobileWords.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileWords.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private QueryResult _selectedItem;

        public ObservableCollection<QueryResult> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<QueryResult> ItemTapped { get; }
        public Command Search { get; }

        public delegate void ReportProgress(double progress);
        public event ReportProgress ReportProgressEvent;

        public ItemsViewModel()
        {
            Title = "Search";
            Items = new ObservableCollection<QueryResult>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<QueryResult>(OnItemSelected);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public QueryResult SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        async void OnItemSelected(QueryResult item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        public async Task SearchAsync(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
                return;

            ReportProgressEvent(0);

            try
            {
                // reset search results
                await DataStore.ClearItemsAsync();

                ReportProgressEvent(10);
                TRW.AppLibraries.GuiWords.GuiWordsQueryResult results = new TRW.AppLibraries.GuiWords.GuiWordsQueryResult();
                results.RunSearchLatin(App.Table, searchQuery);
                ReportProgressEvent(60);
                if (results.Success)
                {
                    double step = 40 / results.ResultRows.Count;
                    int resultId = 0;
                    foreach (TRW.AppLibraries.GuiWords.GuiWordsRowMatch result in results.ResultRows)
                    {
                        await DataStore.AddItemAsync(new QueryResult()
                        {
                            Id = resultId.ToString(),
                            DictionaryWord = result.DictionaryWord,
                            Definition = result.Meaning,
                            Parsing = GetParsing(result),
                            Form = result.Form,
                            DictionaryId = result.DictionaryId,
                            PartOfSpeech = result.PartOfSpeech
                        }) ;
                        resultId++;
                        ReportProgressEvent(60 + (step * resultId));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = true;
            }

            ReportProgressEvent(100);
        }

        private string GetParsing(TRW.AppLibraries.GuiWords.GuiWordsRowMatch result)
        {
            string mainParse = $"{result.PartOfSpeech}: ";
            string genderNumberCase = $"{result.Case}, {result.Number}, {result.Gender}";
            string personNumberTenseMood = GetVerbParsingString(result);
            string parsing = string.Empty;

            switch (result.PartOfSpeech)
            {
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Noun:
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Pronoun:
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Adjective:
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Number:
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Participle:
                    parsing = $"{mainParse} {genderNumberCase}";
                    break;
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Verb:
                    parsing = $"{mainParse} {personNumberTenseMood}";
                    break;
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Adverb:
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Conjunction:
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Preposition:
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.Interjection:
                case TRW.AppLibraries.GuiWords.PartsOfSpeech.PackOn:
                    parsing = mainParse;
                    break;
                default:
                    break;
            }

            return parsing;
        }

        private string GetVerbParsingString(TRW.AppLibraries.GuiWords.GuiWordsRowMatch result)
        {
            if (result.Person == TRW.AppLibraries.GuiWords.Persons.None
                && result.Number == TRW.AppLibraries.GuiWords.Numbers.None)
            {
                return $"{result.Tense}, {result.Mood}";
            }
            else
            {
                return $"{TRW.CommonLibraries.Core.EnumExtensions.GetDescription(result.Person)}, {result.Number}, {result.Tense}, {result.Mood}";
            }
        }
    }
}