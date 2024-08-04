using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRW.GameLibraries.GameCore;

namespace TRW.Games.Pong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tick = new GameTicker(500);
            uxMainMenu.MainWindow = this;
            MenuState = MenuStates.MainMenu;
            SetMenuVisible(true);
            SetMenuItems();
        }

        private List<IGameObject> GameObjects { get; } = new List<IGameObject>();
        private GameTicker Tick { get; }
        private MenuStates MenuState { get; set; }
        private bool MenuVisible => MenuState == MenuStates.PauseMenu || MenuState == MenuStates.SettingsMenu || MenuState == MenuStates.MainMenu;

        #region Main Menu
        internal void CreateNewGame()
        {
            // reset board
            Tick.GameObjects.Clear();
            uxGameBoard.Children.Clear();

            // clear menu and start playing
            Tick.GamePlaying = true;
            SetMenuVisible(false);
            SetMenuItems();

            // add ball to board
            GameObjects.Ball ball = new GameObjects.Ball(10, uxGameBoard.Width, uxGameBoard.Height) { ObjectImage = Statics.BallImage };
            int objectIndx = uxGameBoard.Children.Add(ball.WpfImage);
            ball.ObjectId = objectIndx;
            Tick.GameObjects.Add(ball);
            Canvas.SetLeft(uxGameBoard.Children[objectIndx], uxGameBoard.Width/ 2);
            Canvas.SetTop(uxGameBoard.Children[objectIndx], uxGameBoard.Height / 2);
        }

        internal void ResumeGame()
        {
            SetMenuVisible(false);
            SetMenuItems();
        }

        internal void OpenSettings()
        {
            MenuState = MenuStates.SettingsMenu;
            SetMenuItems();
        }

        internal void ApplySettings()
        {
            if(Tick.GamePlaying)
            {
                MenuState = MenuStates.PauseMenu;
            }
            else
            {
                MenuState = MenuStates.MainMenu;
            }
            SetMenuItems();
        }

        internal void ExitGame()
        {
            Close();
        }

        private void SetMenuVisible(bool visible)
        {
            uxMainMenu.IsEnabled = visible;
            if (visible)
            {
                uxMainMenu.Visibility = Visibility.Visible;
            }
            else
            {
                uxMainMenu.Visibility = Visibility.Hidden;
                MenuState = MenuStates.Hidden;
            }

            Tick.GamePaused = visible;
        }

        private void SetMenuItems()
        {
            uxMainMenu.Buttons.Clear();
            switch (MenuState)
            {
                case MenuStates.MainMenu:
                    uxMainMenu.Buttons.Add(MainMenu.NewGameMenuItem);
                    uxMainMenu.Buttons.Add(MainMenu.SettingsMenuItem);
                    uxMainMenu.Buttons.Add(MainMenu.ExitGameMenuItem);
                    break;
                case MenuStates.SettingsMenu:
                    uxMainMenu.Buttons.Add(MainMenu.ApplySettingsMenuItem);
                    break;
                case MenuStates.PauseMenu:
                    uxMainMenu.Buttons.Add(MainMenu.ResumeGameMenuItem);
                    uxMainMenu.Buttons.Add(MainMenu.NewGameMenuItem);
                    uxMainMenu.Buttons.Add(MainMenu.SettingsMenuItem);
                    uxMainMenu.Buttons.Add(MainMenu.ExitGameMenuItem);
                    break;
            }


        }

        private void HandleMenuKey()
        {
            switch (MenuState)
            {
                case MenuStates.MainMenu:
                    break;
                case MenuStates.PauseMenu:
                    SetMenuVisible(false);
                    SetMenuItems();
                    break;
                case MenuStates.SettingsMenu:
                case MenuStates.Hidden:
                    if (Tick.GamePlaying)
                    {
                        MenuState = MenuStates.PauseMenu;
                    }
                    else
                    {
                        MenuState = MenuStates.MainMenu;
                    }
                    SetMenuVisible(true);
                    SetMenuItems();
                    break;
            }
        }
        #endregion

        private void MainWindow1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    HandleMenuKey();
                    break;
            }

            e.Handled = true;
        }

        private void uxGameBoard_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    HandleMenuKey();
                    break;
            }

            e.Handled = true;
        }

        private void uxMainMenu_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    HandleMenuKey();
                    break;
            }

            e.Handled = true;
        }
    }

    internal enum MenuStates
    {
        Hidden,
        MainMenu,
        SettingsMenu,
        PauseMenu
    }
}
