using System.Diagnostics;
using System.Drawing.Printing;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.VisualBasic.CompilerServices;


namespace CalculatorQuest;

public partial class MainWindow : Window
{
    int count = 0;
    int nbrpoint = 0;
    int nbrsign = 0;

    public MainWindow()
    {
        this.Width = 300;
        this.Height = 500;
        InitializeComponent();
    }


    private void WhenButtonPressed(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Button button = (Button)sender;
        string input = button.Content.ToString();

        if (Calc.VerifNumber(input[0]) && Calc.VerifSign(input[0]) == false)
        {
            Result.Content += input;
            count++;
        }

        if (input == "C")
        {
            Result.Content = "";
            Operation.Content = "";
            count = 0;
            nbrpoint = 0;
            nbrsign = 0;
        }
        
        if (input == "CE")
        {
            Result.Content = "";
            count = 0;
            nbrpoint = 0;
        }

        if (input == "\u2190" && count > 0)
        {
            Result.Content = Calc.Del(Result.Content.ToString());
        }
        
        if (input == "." && count > 0  && nbrpoint == 0)
        {
            Result.Content += input;
            nbrpoint++;
        }

        if (Calc.VerifSign(input[0]) && nbrsign == 0 && count > 0)
        {
            Operation.Content = Result.Content + input;
            nbrpoint = 0;
            count = 0;
            nbrsign++;
            Result.Content = "";
        }
        
        if (Calc.VerifSign(input[0]) && count == 0 && Result.Content != "")
        {
            Operation.Content = Result.Content + input;
            nbrpoint = 0;
            count = 0;
            nbrsign++;
            Result.Content = "";
        }

        if (input == "=")
        {
            Result.Content = Calc.Operator(Operation.Content.ToString() + Result.Content.ToString());
            Operation.Content = "";
            count = 0;
            nbrpoint = 0;
        }

    }
}
        // if (input == "C")
        // {
        //     Result.Content = string.Empty;
        //     Operation.Content = string.Empty;
        //     count = 0;
        //     nbrpoint = 0;
        //     return;
        // }
        //
        // if (input == "=")
        // {
        //     string ope = Operation.Content.ToString() + Result.Content.ToString();
        //     Result.Content = Calc.Operator(ope);
        // }
        //
        // if (count == 0 && Calc.VerifNumber(input[0]))
        // {
        //     Result.Content = button.Content.ToString();
        //     count++;
        // }
        // else if (Calc.VerifSign(input[0]))
        // {
        //     Operation.Content = Result.Content.ToString() + button.Content.ToString();
        //     Result.Content = string.Empty;
        //
        // }else if (count > 0 )
        // {
        //     
        //     if (input != ".")
        //     {
        //         Result.Content += button.Content.ToString();
        //     }
        //     else if(nbrpoint == 0)
        //     {
        //         Result.Content += button.Content.ToString();
        //         nbrpoint++;
        //     }
        // }
