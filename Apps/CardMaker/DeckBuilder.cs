using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using TRW.Apps.TrwAppsBase;
using TRW.GameLibraries.GameCore;
using System.Drawing;

namespace TRW.Apps.CardMaker
{
    public partial class DeckBuilder : TrwFormBase
    {
        internal const string DeckFileFilter = "Deck|*.deck";

        private int _tabCounter = 0;

        private ContextMenuStrip _tabControlContextMenu;
        private int _contextMenuOverIndex = -1;

        public DeckBuilder()
        {
            InitializeComponent();
            InitMainMenu();
            InitContextMenu();
        }

        public DeckBuilder(string file, bool openViewer)
        : this()
        {
            OpenFile(file);
            if (openViewer)
            {
                ViewDeck();
            }
        }

        bool ChangesToSave
        {
            get
            {
                if (CurrentDeckEditor != null)
                    return CurrentDeckEditor.ChangesToSave;

                return false;
            }
        }

        List<DeckEditor> DeckEditors
        {
            get
            {
                if (DeckBuilderTabControl.TabPages.Count > 0)
                {
                    List<DeckEditor> decks = new List<DeckEditor>();
                    foreach (TabPage page in DeckBuilderTabControl.TabPages)
                    {
                        var deckEditor = page.Controls.OfType<DeckEditor>().FirstOrDefault();
                        if (deckEditor != null)
                            decks.Add(deckEditor);
                    }
                }
                return new List<DeckEditor>();
            }
        }

        DeckEditor CurrentDeckEditor
        {
            get
            {
                if (DeckBuilderTabControl.SelectedTab != null)
                {
                    return GetDeckEditor(DeckBuilderTabControl.SelectedTab);
                }
                return null;
            }
        }

        private void InitMainMenu()
        {
            newToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;

            viewDeckToolStripMenuItem.Click += ViewDeckToolStripMenuItem_Click;
            optionsToolStripMenuItem.Click += OptionsToolStripMenuItem_Click;
        }

        private void InitContextMenu()
        {
            _tabControlContextMenu = new ContextMenuStrip();
            _tabControlContextMenu.Opening += DeckBuilderTabControlContextMenu_Opening;
            DeckBuilderTabControl.ContextMenuStrip = _tabControlContextMenu;

            var newMenu = _tabControlContextMenu.Items.Add("New");
            newMenu.Click += NewMenu_Click;
            var saveMenu = _tabControlContextMenu.Items.Add("Save");
            saveMenu.Click += SaveMenu_Click;
            var closeMenu = _tabControlContextMenu.Items.Add("Close");
            closeMenu.Click += CloseMenu_Click;
        }

        private void SetCurrentEditorToNewTab()
        {
            string newTabName = $"Tab{_tabCounter++}";
            SetCurrentEditorToNewTab(newTabName);
        }

        private void SetCurrentEditorToNewTab(string newTabName)
        {
            DeckBuilderTabControl.TabPages.Add(newTabName, newTabName);
            var tabPage = DeckBuilderTabControl.TabPages[newTabName];
            DeckEditor editor = new DeckEditor();
            editor.Name = $"{newTabName}DeckEditor";
            editor.Dock = DockStyle.Fill;
            tabPage.Controls.Add(editor);
            DeckBuilderTabControl.SelectTab(tabPage);
        }

        private void NewDeck()
        {
            SetCurrentEditorToNewTab();
            CurrentDeckEditor.NewDeck();
            CurrentDeckEditor.SetEditMode(false);
        }

        private void SaveChanges(bool saveAs)
        {
            SaveChanges(saveAs, CurrentDeckEditor);
        }

        private void SaveChanges(bool saveAs, DeckEditor deckEditor)
        {
            deckEditor.SaveDeck(saveAs);
        }

        private void OpenFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = DeckFileFilter, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    OpenFile(ofd.FileName);
                }
                else
                {
                    return;
                }
            }

        }

        private void OpenFile(string file)
        {
            SetCurrentEditorToNewTab(System.IO.Path.GetFileNameWithoutExtension(file));
            CurrentDeckEditor.OpenFile(file);
            CurrentDeckEditor.SetEditMode(false);
        }

        private void CloseFile()
        {
            CloseFile(DeckBuilderTabControl.SelectedTab, DeckBuilderTabControl.SelectedIndex);
        }

        private void CloseFile(TabPage selected, int index)
        {
            DeckEditor editor = GetDeckEditor(selected);
            if(editor.ChangesToSave)
            {
                var result = GetConfirmationDialog("Confirm Close");
                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        SaveChanges(false, editor);
                        break;
                    case DialogResult.No:
                        break;
                }
            }

            if (index > 0)
                DeckBuilderTabControl.SelectTab(--index);

            DeckBuilderTabControl.TabPages.Remove(selected);
        }

        private void ViewDeck()
        {
            if (CurrentDeckEditor != null && CurrentDeckEditor.Deck != null)
            {
                DeckViewer<int> deckViewer = new DeckViewer<int>(CurrentDeckEditor.Deck);
                deckViewer.Show();
            }
        }

        private DeckEditor GetDeckEditor(int index)
        {
            return GetDeckEditor(DeckBuilderTabControl.TabPages[index]);
        }

        private DeckEditor GetDeckEditor(TabPage tab)
        {
            return (DeckEditor)tab.Controls[$"{tab.Name}DeckEditor"];
        }

        #region Events

        #region Main Menu
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDeck();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChanges(false);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChanges(true);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentDeckEditor != null)
            {
                CloseFile();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var localDeckEditors = DeckEditors;
            if (localDeckEditors.Any(d => d.ChangesToSave))
            {
                var result = GetConfirmationDialog("Confirm Exit");
                switch (result)
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        localDeckEditors.ForEach(d => d.SaveDeck(false));
                        this.Close();
                        break;
                    case DialogResult.No:
                        this.Close();
                        break;
                }
            }
            else
            {
                this.Close();
            }
        }

        private DialogResult GetConfirmationDialog(string caption)
        {
            return MessageBox.Show("There may be unsaved changes. Would you like to save changes?", caption, MessageBoxButtons.YesNoCancel);
        }

        private void ViewDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDeck();
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Context Menu
        private void DeckBuilderTabControlContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Point p = this.DeckBuilderTabControl.PointToClient(Cursor.Position);
            for (int i = 0; i < this.DeckBuilderTabControl.TabCount; i++)
            {
                Rectangle r = this.DeckBuilderTabControl.GetTabRect(i);
                if (r.Contains(p))
                {
                    _contextMenuOverIndex = i; // i is the index of tab under cursor
                    return;
                }
            }
            e.Cancel = true;
        }

        private void CloseMenu_Click(object sender, EventArgs e)
        {
            if(_contextMenuOverIndex > -1)
                CloseFile(DeckBuilderTabControl.TabPages[_contextMenuOverIndex], _contextMenuOverIndex);
        }

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            if (_contextMenuOverIndex > -1)
                SaveChanges(false, GetDeckEditor(_contextMenuOverIndex));
        }

        private void NewMenu_Click(object sender, EventArgs e)
        {
            NewDeck();
        }
        #endregion

        #endregion

    }
}
