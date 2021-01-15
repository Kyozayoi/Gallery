using System.Windows;
using Microsoft.Win32;
using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace AutoChessItemTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fileName;
        Excel.Application currApp;
        Excel.Workbook currWorkBook;
        Excel.Worksheet currWorkSheet;
        int[] roundNums = new int[12] { 1, 2, 3, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_LoadFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileFinder = new OpenFileDialog();
            fileFinder.InitialDirectory = "C:\\";
            fileFinder.Filter = "Excel |*.xlsx";
            if (fileFinder.ShowDialog() == true)
            {
                fileName = fileFinder.FileName;
            }
            currApp = new Excel.Application();
            currApp.Visible = true;
            currWorkBook = currApp.Workbooks.Open(fileName);
            currWorkSheet = (Excel.Worksheet)currApp.Worksheets[1];
        }

        private void Click_NewGame(object sender, RoutedEventArgs e)
        {
            NoItem_Round1.IsChecked = false;
            NoItem_Round2.IsChecked = false;
            NoItem_Round3.IsChecked = false;
            NoItem_Round10.IsChecked = false;
            NoItem_Round15.IsChecked = false;
            NoItem_Round20.IsChecked = false;
            NoItem_Round25.IsChecked = false;
            NoItem_Round30.IsChecked = false;
            NoItem_Round35.IsChecked = false;
            NoItem_Round40.IsChecked = false;
            NoItem_Round45.IsChecked = false;
            NoItem_Round50.IsChecked = false;
            Slider_Round1.Value = 0;
            Slider_Round2.Value = 0;
            Slider_Round3.Value = 0;
            Slider_Round10.Value = 0;
            Slider_Round15.Value = 0;
            Slider_Round20.Value = 0;
            Slider_Round25.Value = 0;
            Slider_Round30.Value = 0;
            Slider_Round35.Value = 0;
            Slider_Round40.Value = 0;
            Slider_Round45.Value = 0;
            Slider_Round50.Value = 0;
        }

        private void Click_SaveStats(object sender, RoutedEventArgs e)
        {
            Excel.Range searchRadius = currWorkSheet.Range["A2", "B28"];
            int toExcel;
            for(int i = 1; i < 36; i++)
            {
                string boxName = "Creep" + i;
                var foundBox = (TextBox)this.FindName(boxName);
                string itemName = "";
                if (!String.IsNullOrEmpty(foundBox.Text))
                {
                    itemName = foundBox.Text;
                    
                    if (itemName.Equals("None"))
                    {
                        toExcel = Convert.ToInt32(currWorkSheet.Cells[28, "B"].Value) + 1;
                        currWorkSheet.Cells[28, "B"].Value = toExcel;
                    }
                    else
                    {
                        Excel.Range foundCell = searchRadius.Find(itemName);
                        int toRow = foundCell.Row;
                        toExcel = Convert.ToInt32(currWorkSheet.Cells[toRow, "B"].Value) + 1;
                        currWorkSheet.Cells[toRow, "B"] = toExcel;
                    }
                }
            }
            
            for(int j = 0; j < 12; j++)
            {
                string sliderName = "Slider_Round" + roundNums[j];
                var foundSlider = (Slider)this.FindName(sliderName);
                int currValue = (int)foundSlider.Value;
                toExcel = Convert.ToInt32(currWorkSheet.Cells[31, "B"].Value) + currValue;
                currWorkSheet.Cells[31, "B"].Value = toExcel;
            }

        }

        private void Click_ShutDown(object sender, RoutedEventArgs e)
        {
            currWorkBook.Save();
            currWorkBook.Close();
            currApp.Quit();
            System.Windows.Application.Current.Shutdown();
        }

        private void Click_NextTab(object sender, RoutedEventArgs e)
        {
            int nextIndex = Supervisor.SelectedIndex + 1;
            if (nextIndex >= Supervisor.Items.Count)
                nextIndex = 0;
            Supervisor.SelectedIndex = nextIndex;
        }

        private void Creep_NoItem(object sender, RoutedEventArgs e)
        {
            CheckBox currentBox = (sender as CheckBox);
            string currBox = currentBox.Name;
            int thisNum = Int32.Parse(Regex.Match(currBox, @"\d+$").Value);
            string fullName = "Creep" + thisNum;
            var toTextBox = (TextBox)this.FindName(fullName);
            toTextBox.Text = "None";
        }
        private void Creep_HasItem(object sender, RoutedEventArgs e)
        {
            CheckBox currentBox = (sender as CheckBox);
            string currBox = currentBox.Name;
            int thisNum = Int32.Parse(Regex.Match(currBox, @"\d+$").Value);
            string fullName = "Creep" + thisNum;
            var toTextBox = (TextBox)this.FindName(fullName);
            toTextBox.Text = "";
        }

        private void Round_NoItems(object sender, RoutedEventArgs e)
        {
            CheckBox currentBox = (sender as CheckBox);
            string currBox = currentBox.Name;
            int thisNum = Int32.Parse(Regex.Match(currBox, @"\d+$").Value);
            switch (thisNum)
            {
                case 1:
                    NoItem_Creep1.IsChecked = true;
                    NoItem_Creep2.IsChecked = true;
                    break;
                case 2:
                    NoItem_Creep3.IsChecked = true;
                    NoItem_Creep4.IsChecked = true;
                    NoItem_Creep5.IsChecked = true;
                    break;
                case 3:
                    NoItem_Creep6.IsChecked = true;
                    NoItem_Creep7.IsChecked = true;
                    NoItem_Creep8.IsChecked = true;
                    NoItem_Creep9.IsChecked = true;
                    NoItem_Creep10.IsChecked = true;
                    NoItem_Creep11.IsChecked = true;
                    break;
                case 10:
                    NoItem_Creep12.IsChecked = true;
                    NoItem_Creep13.IsChecked = true;
                    NoItem_Creep14.IsChecked = true;
                    break;
                case 15:
                    NoItem_Creep15.IsChecked = true;
                    NoItem_Creep16.IsChecked = true;
                    NoItem_Creep17.IsChecked = true;
                    NoItem_Creep18.IsChecked = true;
                    NoItem_Creep19.IsChecked = true;
                    break;
                case 20:
                    NoItem_Creep20.IsChecked = true;
                    NoItem_Creep21.IsChecked = true;
                    break;
                case 25:
                    NoItem_Creep22.IsChecked = true;
                    NoItem_Creep23.IsChecked = true;
                    break;
                case 30:
                    NoItem_Creep24.IsChecked = true;
                    NoItem_Creep25.IsChecked = true;
                    NoItem_Creep26.IsChecked = true;
                    break;
                case 35:
                    NoItem_Creep27.IsChecked = true;
                    break;
                case 40:
                    NoItem_Creep28.IsChecked = true;
                    NoItem_Creep29.IsChecked = true;
                    NoItem_Creep30.IsChecked = true;
                    NoItem_Creep31.IsChecked = true;
                    NoItem_Creep32.IsChecked = true;
                    NoItem_Creep33.IsChecked = true;
                    break;
                case 45:
                    NoItem_Creep34.IsChecked = true;
                    break;
                case 50:
                    NoItem_Creep35.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        private void Round_HasItems(object sender, RoutedEventArgs e)
        {
            CheckBox currentBox = (sender as CheckBox);
            string currBox = currentBox.Name;
            int thisNum = Int32.Parse(Regex.Match(currBox, @"\d+$").Value);
            switch (thisNum)
            {
                case 1:
                    NoItem_Creep1.IsChecked = false;
                    NoItem_Creep2.IsChecked = false;
                    break;
                case 2:
                    NoItem_Creep3.IsChecked = false;
                    NoItem_Creep4.IsChecked = false;
                    NoItem_Creep5.IsChecked = false;
                    break;
                case 3:
                    NoItem_Creep6.IsChecked = false;
                    NoItem_Creep7.IsChecked = false;
                    NoItem_Creep8.IsChecked = false;
                    NoItem_Creep9.IsChecked = false;
                    NoItem_Creep10.IsChecked = false;
                    NoItem_Creep11.IsChecked = false;
                    break;
                case 10:
                    NoItem_Creep12.IsChecked = false;
                    NoItem_Creep13.IsChecked = false;
                    NoItem_Creep14.IsChecked = false;
                    break;
                case 15:
                    NoItem_Creep15.IsChecked = false;
                    NoItem_Creep16.IsChecked = false;
                    NoItem_Creep17.IsChecked = false;
                    NoItem_Creep18.IsChecked = false;
                    NoItem_Creep19.IsChecked = false;
                    break;
                case 20:
                    NoItem_Creep20.IsChecked = false;
                    NoItem_Creep21.IsChecked = false;
                    break;
                case 25:
                    NoItem_Creep22.IsChecked = false;
                    NoItem_Creep23.IsChecked = false;
                    break;
                case 30:
                    NoItem_Creep24.IsChecked = false;
                    NoItem_Creep25.IsChecked = false;
                    NoItem_Creep26.IsChecked = false;
                    break;
                case 35:
                    NoItem_Creep27.IsChecked = false;
                    break;
                case 40:
                    NoItem_Creep28.IsChecked = false;
                    NoItem_Creep29.IsChecked = false;
                    NoItem_Creep30.IsChecked = false;
                    NoItem_Creep31.IsChecked = false;
                    NoItem_Creep32.IsChecked = false;
                    NoItem_Creep33.IsChecked = false;
                    break;
                case 45:
                    NoItem_Creep34.IsChecked = false;
                    break;
                case 50:
                    NoItem_Creep35.IsChecked = false;
                    break;
                default:
                    break;
            }
        }


    }
}
