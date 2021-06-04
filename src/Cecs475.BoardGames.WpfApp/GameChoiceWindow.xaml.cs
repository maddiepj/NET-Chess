using Cecs475.BoardGames.Model;
using Cecs475.BoardGames.WpfView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cecs475.BoardGames.WpfApp {
	/// <summary>
	/// Interaction logic for GameChoiceWindow.xaml
	/// </summary>
	public partial class GameChoiceWindow : Window {
		//Old constructor that uses assembly.loadfrom
		//public GameChoiceWindow()
		//{
		//	InitializeComponent();
		//	Type IGameType = typeof(IWpfGameFactory);
		//	string gamesPath = "../Debug/games";
		//	List<object> gamesList = new List<object>();
		//	foreach (string dllFile in Directory.GetFiles(gamesPath, "*.dll"))
		//	{
		//		try
		//		{
		//			Assembly loadedAssembly = Assembly.LoadFrom(dllFile);
		//		}
		//		catch (FileLoadException loadEx)
		//		{ } // The Assembly has already been loaded.
		//		catch (BadImageFormatException imgEx)
		//		{ } // If a BadImageFormatException exception is thrown, the file is not an assembly.
		//	}
		//	var games = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => IGameType.IsAssignableFrom(t) && t.IsClass);
		//	int i = 0;
		//	foreach(var game in games)
		//	{
		//		gamesList.Add(Activator.CreateInstance(game));

		//	}
		//	this.DataContext = this;
		//	this.Resources.Add("GameTypes", gamesList);

		//}

		public GameChoiceWindow()
		{
			InitializeComponent();
			Type IGameType = typeof(IWpfGameFactory);
			string gamesPath = "../Debug/games/";
			List<object> gamesList = new List<object>();
			foreach (string dllFile in Directory.GetFiles(gamesPath, "*.dll"))
			{
				try
				{
					//removes the .dll extension
					string cutdllFile = dllFile.Substring(0, dllFile.Length - 4);
					String[] cutName = cutdllFile.Split('/');
					cutdllFile = cutName[cutName.Length - 1];
					Console.WriteLine("Heres the file name: " + cutdllFile);

					Assembly loadedAssembly = Assembly.Load(cutdllFile +", Version=1.0.0.0, Culture=neutral, PublicKeyToken=68e71c13048d452a");
				}
				catch (FileLoadException loadEx)
				{ } // The Assembly has already been loaded.
				catch (BadImageFormatException imgEx)
				{ } // If a BadImageFormatException exception is thrown, the file is not an assembly.
			}
			var games = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => IGameType.IsAssignableFrom(t) && t.IsClass);
			int i = 0;
			foreach (var game in games)
			{
				gamesList.Add(Activator.CreateInstance(game));

			}
			this.DataContext = this;
			this.Resources.Add("GameTypes", gamesList);

		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			Button b = sender as Button;
			// Retrieve the game type bound to the button
			IWpfGameFactory gameType = b.DataContext as IWpfGameFactory;
			// Construct a GameWindow to play the game.
			var gameWindow = new GameWindow(gameType,
				mHumanBtn.IsChecked.Value ? NumberOfPlayers.Two : NumberOfPlayers.One) {
				Title = gameType.GameName
			};
			// When the GameWindow closes, we want to show this window again.
			gameWindow.Closed += GameWindow_Closed;

			// Show the GameWindow, hide the Choice window.
			gameWindow.Show();
			this.Hide();
		}

		private void GameWindow_Closed(object sender, EventArgs e) {
			this.Show();
		}
	}
}
