using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPersonalityQuiz
{
	public class RadioButtonGroup : StackLayout
	{
		public RadioButton YesRadioButton { get; private set; }
		public RadioButton NoRadioButton { get; private set; }

		public event EventHandler<(bool YesSelected, bool NoSelected)> OnSelectionChanged;

		public RadioButtonGroup()
		{
			CreateRadioButtons();
		}

		private void CreateRadioButtons()
		{
			YesRadioButton = new RadioButton
			{
				Content = "Yes",
				GroupName = Guid.NewGuid().ToString() 
			};

			YesRadioButton.CheckedChanged += (s, e) => OnSelectionChanged?.Invoke(this, (YesRadioButton.IsChecked, NoRadioButton.IsChecked));
			Children.Add(YesRadioButton);

			NoRadioButton = new RadioButton
			{
				Content = "No",
				GroupName = YesRadioButton.GroupName
			};

			NoRadioButton.CheckedChanged += (s, e) => OnSelectionChanged?.Invoke(this, (YesRadioButton.IsChecked, NoRadioButton.IsChecked));
			Children.Add(NoRadioButton);
		}
	}



}
