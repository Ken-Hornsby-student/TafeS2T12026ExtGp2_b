using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// 
	/// ///	Student:	Ken Hornsby
	///	Collage:	TAFE SA
	///	Year:		2026
	/// 
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Currency : Page
	{
		public Currency()
		{
			this.InitializeComponent();
		}


		// Global definitions for Summation Methods
		public double exchangeValue = 0;
		public string currencyFrom = "currencyFrom";
		public string exchangeRatePartA = "fromExchange";
		public string currencyTo = "toCurrency";
		public string exchangeRatePartB = "exchangeTo";
		public string exchangeRateBearing = "A + B";
		//public int exchangeRateCalled = 1;
		public float requiredExchangeRate = 1;
		public double calculatedExchangeAmount = 1;
		public double theFlipExchangeRate = 1;


		// Four fixed exchange currencies
		// 1) Exchange Rates from US Dollor
		public const float usDollarToEuro = 0.85189982F;
		public const float usDollarToPound = 0.72872436F;
		public const float usDollarToRupee = 74.257327F;

		// 2) Exchange Rates from European Euro
		public const float euroToUSDollar = 1.1739732F;
		public const float euroToPound = 0.8556672F;
		public const float euroToRupee = 87.00755F;

		// 3) Exchange Rates from British Pound
		public const float poundToUSDollar = 1.371907F;
		public const float poundToEuro = 1.1686692F;
		public const float poundToRupee = 101.68635F;

		// 4) Exchange Rates from Indian Rupee
		public const float rupeeToUSDollar = 0.011492628F;
		public const float rupeeToEuro = 0.013492774F;
		public const float rupeeToPound = 0.0098339397F;


		// Psydocode

		//Amount to be exchanged

		//public string currencyFromWhere(string currencyFrom)

		//public string currencyToWhere(string currencyTo)

		//public calculateFromAndTo(double initialPresentedAmount, string currencyFromWhere, string currencyToWhere)

		//public fill FourTextBoxes(string firstResultStatement, string flipedStatementResult)


		private async void currencyCalcButtonClick(object sender, RoutedEventArgs e)
		{

			//      Input amount to be exchanged
			// Try/Catch and Validation processs
			try
			{
				exchangeValue = double.Parse(exchangeAmountTextBox.Text);
			}
			catch (Exception theAmountException)
			{
				var priceExeptionMessage = new MessageDialog("Exchange amount needs correction. " + theAmountException.Message);
				await priceExeptionMessage.ShowAsync();
				exchangeAmountTextBox.Focus(FocusState.Programmatic);
				exchangeAmountTextBox.Text = "0";
				exchangeAmountTextBox.SelectAll();

				// return to GUI
				return;
			}


			//   More try catch exceptions to fill in.                      <---------- NEXT!


			//      Workout from and to.
			//		Also, Fill the 4 side Text Boxes.
			//		Combine bearings and call exchange rate.

			//	From currency. Place selected from currency into text box.

			currencyFrom = (currencyFromComboBox.Text);

			//fromAmountAndCurrency.Text = "British Pound";

			if (currencyFrom == "US Dollar")
			{
				fromAmountAndCurrencyTextBlock.Text = currencyFrom;
				exchangeRatePartA = "usDollar";
			}

			else if (currencyFrom == "European Euro")
			{
				fromAmountAndCurrencyTextBlock.Text = currencyFrom;
				exchangeRatePartA = "euro";
			}

			else if (currencyFrom == "British Pound")
			{
				fromAmountAndCurrencyTextBlock.Text = currencyFrom;
				exchangeRatePartA = "pound";
			}

			else if (currencyFrom == "Idian Rupee")
			{
				fromAmountAndCurrencyTextBlock.Text = currencyFrom;
				exchangeRatePartA = "rupee";
			}


			//	To currency. Place selected to currency into text box.

			currencyTo = (currencyToComboBox.Text);
			//toAmountAndCurrency.Text = "to British Pound";


			if (currencyTo == "to US Dollar")
			{
				toAmountAndCurrencyTextBlock.Text = currencyTo;
				exchangeRatePartB = "ToUSDollar";
			}

			else if (currencyTo == "to European Euro")
			{
				toAmountAndCurrencyTextBlock.Text = currencyTo;
				exchangeRatePartB = "ToEuro";
			}

			else if (currencyTo == "to British Pound")
			{
				toAmountAndCurrencyTextBlock.Text = currencyTo;
				exchangeRatePartB = "ToPound";
			}

			else if (currencyTo == "to Idian Rupee")
			{
				toAmountAndCurrencyTextBlock.Text = currencyTo;
				exchangeRatePartB = "ToRupee";
			}


			//	Combine bearings "exchangeRatePartA + exchangeRatePartB".
			//	Also, call the required exchange rate.

			exchangeRateBearing = (exchangeRatePartA + exchangeRatePartB);
			//exchangeReateCalled = (int(exchangeRateBearing)());

			// US Dollar to other currencies.
			if (exchangeRateBearing == "usDollarToEuro")
			{
				requiredExchangeRate = usDollarToEuro;
			}

			else if (exchangeRateBearing == "usDollarToPound")
			{
				requiredExchangeRate = usDollarToPound;
			}

			else if (exchangeRateBearing == "usDollarToRupee")
			{
				requiredExchangeRate = usDollarToRupee;
			}

			// European Euro to other currencies.
			if (exchangeRateBearing == "euroToUSDollar")
			{
				requiredExchangeRate = euroToUSDollar;
			}

			else if (exchangeRateBearing == "euroToPound")
			{
				requiredExchangeRate = euroToPound;
			}

			else if (exchangeRateBearing == "euroToRupee")
			{
				requiredExchangeRate = euroToRupee;
			}

			// British Pound to other currencies.
			else if (exchangeRateBearing == "poundToUSDollar")
			{
				requiredExchangeRate = poundToUSDollar;
			}

			else if (exchangeRateBearing == "poundToEuro")
			{
				requiredExchangeRate = poundToEuro;
			}

			else if (exchangeRateBearing == "poundToRupee")
			{
				requiredExchangeRate = poundToRupee;
			}

			// Indian Rupee to other currencies.
			else if (exchangeRateBearing == "rupeeToUSDollar")
			{
				requiredExchangeRate = rupeeToUSDollar;
			}

			else if (exchangeRateBearing == "rupeToEuro")
			{
				requiredExchangeRate = rupeeToEuro;
			}

			else if (exchangeRateBearing == "rupeeToPound")
			{
				requiredExchangeRate = rupeeToPound;
			}

			//	Calculate the exchange amount.
			//	Text Block presentation.
			//theFlipExchangeRate =     <-------- ?? Auto fill fields and run through a second time.
			//                                       Need Classes, Attributes and Methods set up.
			exchangeValue = double.Parse(exchangeAmountTextBox.Text);
			currencyFrom = (currencyFromComboBox.Text);
			calculatedExchangeAmount = (exchangeValue * requiredExchangeRate);

			//	Write text in side panel Text Blocks.        <---------- ?? Values are not coming through? 
			//fromAmountAndCurrencyTextBlock.Text = (exchangeValue + " " + currencyFrom + exchangeRatePartA);
			//toAmountAndCurrencyTextBlock.Text = (calculatedExchangeAmount + " " + currencyTo + exchangeRatePartB);
			fromAmountAndCurrencyTextBlock.Text = (exchangeValue + " " + currencyFrom);
			toAmountAndCurrencyTextBlock.Text = (calculatedExchangeAmount + " " + currencyTo);
			exchangeRateTextBlock.Text = (" 1 " + exchangeRatePartA + " " + requiredExchangeRate);
			flipExchangeRateTextBlock.Text = (" 1 " + exchangeRatePartB + " " + theFlipExchangeRate + " ?Flip? ");


		}

		private void exitButtonClick(object sender, RoutedEventArgs e)
		{

		}
	}
}
