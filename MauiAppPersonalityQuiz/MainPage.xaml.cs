using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MauiAppPersonalityQuiz
{
	public partial class MainPage : ContentPage
	{
		public ObservableCollection<string> ImageSources { get; set; } = new ObservableCollection<string>();

		public MainPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		private void OnSubmitClicked(object sender, EventArgs e)
		{
			DisplayResultImage();
		}

		private void OnResetClicked(object sender, EventArgs e)
		{
			ResetForm();
		}

		private void DisplayResultImage()
		{
			ImageSources.Clear();

			AddImageToCollection("beach.jpg", question1.YesRadioButton.IsChecked);
			AddImageToCollection("couch.jpg", !question1.YesRadioButton.IsChecked);

			AddImageToCollection("hiking.jpg", question2.YesRadioButton.IsChecked);
			AddImageToCollection("gaming.jpg", !question2.YesRadioButton.IsChecked);

			AddImageToCollection("picnic.jpg", question3.YesRadioButton.IsChecked);
			AddImageToCollection("sleep.jpg", !question3.YesRadioButton.IsChecked);

			AddImageToCollection("patio.jpg", question4.YesRadioButton.IsChecked);
			AddImageToCollection("poker.jpg", !question4.YesRadioButton.IsChecked);

			Console.WriteLine($"ImageSources count: {ImageSources.Count}");
		}

		private void AddImageToCollection(string imageName, bool condition)
		{
			if (condition)
			{
				// Use relative path
				string imagePath = $"Resources/Images/{imageName}";
				ImageSources.Add(imagePath);
			}
		}





		private void ResetForm()
		{
			question1.YesRadioButton.IsChecked = false;
			question1.NoRadioButton.IsChecked = false;

			question2.YesRadioButton.IsChecked = false;
			question2.NoRadioButton.IsChecked = false;

			question3.YesRadioButton.IsChecked = false;
			question3.NoRadioButton.IsChecked = false;

			question4.YesRadioButton.IsChecked = false;
			question4.NoRadioButton.IsChecked = false;

			ImageSources.Clear();
		}

		

		//private string GetThumbnailPath(string originalPath)
		//{
			
		//	return originalPath.Replace(".jpg", "_thumbnail.jpg");
		//}

	}
}
