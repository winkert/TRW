using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TRW.GameLibraries.GameCore;

namespace TRW.Apps.CardMaker
{
    public partial class DeckEditor : UserControl
    {
        public delegate void writeLog(string message);
        public event writeLog WriteLog;

        bool _inEditMode = false;
        string _currentFile = string.Empty;

        public DeckEditor()
        {
            InitializeComponent();
            InitToolStrip();

            Deck = new Deck<int>();

            SetEditMode(false);
        }


        public Deck<int> Deck { get; set; }

        public bool ChangesToSave { get; set; }

        public void NewDeck()
        {
            Deck = new Deck<int>();
            RefreshDeck();
            ResetDetails(true);
            SetEditMode(true);

            ChangesToSave = true;
            _currentFile = string.Empty;
        }

        public void SaveDeck(bool saveAs)
        {
            if (saveAs || string.IsNullOrEmpty(_currentFile))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = DeckBuilder.DeckFileFilter })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        _currentFile = sfd.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            try
            {
                TRW.CommonLibraries.Serialization.BinarySerializationRoutines.SerializeToFile(Deck, _currentFile);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unexpected error while saving Deck to {_currentFile}");
                WriteLog(e.Message);
                return;
            }

            ChangesToSave = false;
        }

        public void OpenFile(string file)
        {
            if (System.IO.File.Exists(file) && System.IO.Path.GetExtension(file).Equals(".deck"))
            {
                _currentFile = file;

                try
                {
                    Deck = TRW.CommonLibraries.Serialization.BinarySerializationRoutines.DeserializeFromFile<Deck<int>>(_currentFile);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unexpected error while loading Deck from {_currentFile}");
                    WriteLog(e.Message);
                    return;
                }
                finally
                {
                    SetEditMode(false);
                }

                ChangesToSave = false;
                RefreshDeck();
            }
            else
            {
                WriteLog($"Failed to open file {file}.");
            }
        }

        public void SetEditMode(bool edit)
        {
            CardTitleTextbox.Enabled = edit;
            CardValueTextbox.Enabled = edit;
            CardDescriptionTextbox.Enabled = edit;
            SelectImageButton.Enabled = edit;

            if (edit)
            {
                EditSaveButton.Enabled = true;
                EditSaveButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.SaveButtonImage;
                EditSaveButton.Text = "Save";

                NewCardButton.Enabled = false;
                CancelEditButton.Enabled = true;
                DeleteButton.Enabled = true;
                CopyButton.Enabled = false;

                DeckListViewer.Enabled = false;

                ChangesToSave = true;
            }
            else
            {
                EditSaveButton.Enabled = true;
                EditSaveButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.EditButtonImage;
                EditSaveButton.Text = "Edit";

                NewCardButton.Enabled = true;
                CancelEditButton.Enabled = false;
                DeleteButton.Enabled = true;
                CopyButton.Enabled = true;

                DeckListViewer.Enabled = true;
            }

            _inEditMode = edit;
        }

        public void RefreshDeck()
        {
            int selectedIndex = DeckListViewer.SelectedIndices.Count > 0 ? DeckListViewer.SelectedIndices[0] : -1;
            DeckListViewer.Items.Clear();
            Dictionary<Card<int>, int> cardsCount = new Dictionary<Card<int>, int>();
            foreach (Card<int> card in Deck)
            {
                if (!cardsCount.ContainsKey(card))
                {
                    cardsCount.Add(card, 0);
                }
                cardsCount[card]++;
            }

            foreach (KeyValuePair<Card<int>, int> cards in cardsCount)
            {
                Card<int> card = cards.Key;
                var item = DeckListViewer.Items.Add(card.Title);
                item.SubItems.Add(card.Value.ToString());
                item.SubItems.Add(cards.Value.ToString());
                item.Tag = card;
            }

            if (selectedIndex > -1 && selectedIndex <= DeckListViewer.Items.Count)
            {
                DeckListViewer.Items[selectedIndex].Selected = true;
            }
        }

        private void InitToolStrip()
        {
            NewCardButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.AddButtonImage;
            NewCardButton.Click += NewCardButton_Click;
            DeleteButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.DeleteButtonImage;
            DeleteButton.Click += DeleteCardButton_Click;

            EditSaveButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.EditButtonImage;
            EditSaveButton.Click += EditSaveButton_Click;

            CancelEditButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.CancelButtonImage;
            CancelEditButton.Click += CancelEditButton_Click;

            CopyButton.Image = TRW.Apps.TrwAppsBase.TrwFormBase.CopyButtonImage;
            CopyButton.Click += CopyButton_Click;
        }

        private void ResetDetails(bool newCard = false)
        {
            CardTitleTextbox.Clear();
            CardValueTextbox.Clear();
            CardDescriptionTextbox.Clear();
            ChosenImagePictureBox.Image = null;
            ChosenImagePictureBox.Invalidate();

            if (!newCard && DeckListViewer.SelectedItems.Count > 0)
            {
                var item = DeckListViewer.SelectedItems[0];
                Card<int> card = (Card<int>)item.Tag;
                SetDetailsFromCard(card);
            }
        }

        private void AddCardToDeckFromDetails()
        {
            if (int.TryParse(CardValueTextbox.Text, out int cardVal))
            {
                Card<int> newCard = new Card<int>(CardTitleTextbox.Text, CardDescriptionTextbox.Text, cardVal);
                if (ChosenImagePictureBox.Image != null)
                {
                    newCard.Image = new Bitmap(ChosenImagePictureBox.Image);
                }
                Deck.Add(newCard);
            }
        }

        private void SetDetailsFromCard(Card<int> card)
        {
            CardTitleTextbox.Text = card.Title;
            CardDescriptionTextbox.Text = card.Description;
            CardValueTextbox.Text = card.Value.ToString();
            ChosenImagePictureBox.Image = card.Image;
            ChosenImagePictureBox.Invalidate();
        }

        private bool ValidForSaveCard()
        {
            errorProvider1.SetError(CardValueTextbox, "");
            if (int.TryParse(CardValueTextbox.Text, out _))
            {
                return true;
            }
            else
            {
                errorProvider1.SetError(CardValueTextbox, "Value must be an integer");
                return false;
            }
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog()
            {
                Filter = "Images|*.bmp;*.png;*.jpeg;*.jpg;*.gif"
            };
            if (file.ShowDialog() == DialogResult.OK)
            {
                Image fileImage = Image.FromFile(file.FileName);
                Bitmap image = new Bitmap(fileImage, new Size(ChosenImagePictureBox.Width, ChosenImagePictureBox.Height));
                ChosenImagePictureBox.Image = image;
            }
        }

        #region Tool Bar
        private void DeleteCardButton_Click(object sender, EventArgs e)
        {
            if (DeckListViewer.SelectedItems.Count > 0)
            {
                var item = DeckListViewer.SelectedItems[0];
                Card<int> card = (Card<int>)item.Tag;
                Deck.Remove(card);
                ChangesToSave = true;
                RefreshDeck();
            }
        }

        private void NewCardButton_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
            ChangesToSave = true;
            ResetDetails(true);
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            SetEditMode(false);
            ResetDetails();
        }

        private void EditSaveButton_Click(object sender, EventArgs e)
        {
            if (_inEditMode)
            {
                // save
                if (ValidForSaveCard())
                {
                    AddCardToDeckFromDetails();
                    RefreshDeck();
                    ResetDetails();
                    SetEditMode(false);
                }
            }
            else if (DeckListViewer.SelectedItems.Count > 0)
            {
                SetEditMode(true);
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (DeckListViewer.SelectedItems.Count > 0)
            {
                var item = DeckListViewer.SelectedItems[0];
                Card<int> card = (Card<int>)item.Tag;
                Deck.Add(card);
                ChangesToSave = true;
                RefreshDeck();
            }
        }

        #endregion

        private void DeckListViewer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DeckListViewer.SelectedItems.Count > 0)
            {
                Card<int> card = (Card<int>)DeckListViewer.SelectedItems[0].Tag;
                SetDetailsFromCard(card);
            }
        }

        private void DeckListViewer_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (DeckListViewer.SelectedItems.Count > 0)
                {
                    Card<int> card = (Card<int>)DeckListViewer.SelectedItems[0].Tag;
                    Deck.RemoveAllByValue(card.Value);
                    RefreshDeck();
                }
            }
        }
    }
}
