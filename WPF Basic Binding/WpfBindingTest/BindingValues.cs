using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace WpfBindingTest
{
	class BindingValues : INotifyPropertyChanged
	{
		private double dBoundValue = 42.0;
		
		/// <summary>
		/// Value used for binding
		/// </summary>
		public double MyBoundVal
		{
			get { return dBoundValue; }
			set { dBoundValue = value; OnPropertyChanged("MyBoundVal"); }
		}

		/// <summary>
		/// Tells the window that the value changed and should update.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}

	/// <summary>
	/// Converts a value to anything, in this case returns a color based on thresholds, implements IValueConverter
	/// </summary>
	class DoubleToColor : IValueConverter
	{
		// Color thresholds
		private int mnRedBoundary = 75; // Red if greater than
		private int mnOrangeBoundary = 50; // Orange if grear than but less than the red threshold

		public object Convert(object value, Type targetType,
			 object parameter, CultureInfo culture)
		{
			// Do the conversion from double to color
			double dMyVal = 0;
			try
			{
				dMyVal = (double)value;

				if (dMyVal > mnRedBoundary)
					return "Red";
				else if (dMyVal > mnOrangeBoundary)
					return "Orange";
				else
					return "Green";
			}
			catch
			{
				return "Black";
			}
		}

		public object ConvertBack(object value, Type targetType,
			 object parameter, CultureInfo culture)
		{
			// Not 
			throw new NotImplementedException();
		}
	}

	/// <summary>
	/// This one converts the value to a formatted string. 
	/// </summary>
	class DoubleToString : IValueConverter
	{
		public object Convert(object value, Type targetType,
			 object parameter, CultureInfo culture)
		{
			// Do the conversion from double to string
			double dMyVal = 0;
			try
			{
				dMyVal = (double)value;

				return dMyVal.ToString("F0");

			}
			catch (Exception ex)
			{
				//return "---";
				return ex.Message;
			}
		}

		public object ConvertBack(object value, Type targetType,
			 object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
