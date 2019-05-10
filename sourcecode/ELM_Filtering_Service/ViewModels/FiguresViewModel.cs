using ELM_Filtering_Service.Commands;
using ELM_Filtering_Service.Models;
using ELM_Filtering_Service.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ELM_Filtering_Service.ViewModels
{
    class FiguresViewModel : DefaultViewModel
    {
        //Button Bindings
        public ICommand LoadFileButtonCommand { get; set; }
        public ICommand AddButtonCommand { get; set; }
        public ICommand AddAllButtonCommand { get; set; }
        public ICommand ClearButtonCommand { get; set; }
        public string LoadFileButtonText { get; set; }
        public string AddButtonText { get; set; }
        public string AddAllButtonText { get; set; }
        public string ClearButtonText { get; set; }
        //Text Binding
        public string TextTitle { get; set; }
        //Data Structures
        public string[] ListFiles { get; set; }
        public string[] ListItems { get; set; }
        public List<string> targetItems = new List<string>();
        public List<Figures> FiguresList { get; set; }
        //List Choices
        public string TrendString { get; set; }
        public string SelectedFile { get; set; }
        public string SelectedFigure { get; set; }

        string filePath = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), @"Figures\");

        public FiguresViewModel()
        {
            ListFiles = Directory.GetFiles(filePath, "*.txt").Select(file => Path.GetFileName(file)).ToArray();
            //Read lines in txt file
            LoadFileButtonCommand = new RelayCommand(LoadFileButtonClick);
            AddButtonCommand = new RelayCommand(AddButtonClick);
            AddAllButtonCommand = new RelayCommand(AddAllButtonClick);
            ClearButtonCommand = new RelayCommand(ClearButtonClick);
            TextTitle = "Review Figures";
            LoadFileButtonText = "Load File";
            AddButtonText = "Add Item";
            AddAllButtonText = "Add All";
            ClearButtonText = "Clear";
        }

        //Load the selected file in the dropdown list
        private void LoadFileButtonClick()
        {
            if (SelectedFile != null)
            {
                string[] lines = File.ReadAllLines(Path.Combine(filePath, SelectedFile)).Distinct().ToArray();
                //Add each distint line to a list
                ListItems = lines;
                onChanged(nameof(ListItems));
            }
            else
            {
                MessageBox.Show("Please select a File.");
            }
        }

        //Add selected figure to display area
        private void AddButtonClick()
        {
            if (SelectedFigure != null)
            {
                List<Figures> loadFigures = new List<Figures>();
                TrendString = SelectedFigure;
                targetItems.Add(TrendString);
                //For each line, count the  number of times that string is in the txt file
                //output the count
                foreach (string trendstring in targetItems)
                {
                    int countOfFigure = File.ReadLines(Path.Combine(filePath, SelectedFile)).Select(line => Regex.Matches(line, @"(?<=^|\s)" + trendstring + @"(?=\s|$)").Count).Sum();
                    loadFigures.Add(new Figures() { Figure = trendstring + ": " + countOfFigure.ToString(), Count = countOfFigure });
                }
                FiguresList = loadFigures;
                onChanged(nameof(FiguresList));
            }
            else
            {
                MessageBox.Show("Please select something to Add.");
            }
        }

        //Add all figures to display area
        private void AddAllButtonClick()
        {
            if (SelectedFile != null)
            {
                List<Figures> loadFigures = new List<Figures>();
                targetItems = ListItems.ToList();
                //For each line, count the  number of times that string is in the txt file
                //output the count
                foreach (string trendstring in targetItems)
                {
                    int countOfFigure = File.ReadLines(Path.Combine(filePath, SelectedFile)).Select(line => Regex.Matches(line, @"(?<=^|\s)" + trendstring + @"(?=\s|$)").Count).Sum();
                    loadFigures.Add(new Figures() { Figure = trendstring + ": " + countOfFigure.ToString(), Count = countOfFigure });
                }
                FiguresList = loadFigures;
                onChanged(nameof(FiguresList));
            }
        }

        //Clear all figures from display area
        private void ClearButtonClick()
        {
            if (targetItems != null)
            {
                targetItems.Clear();
                FiguresList = null;
                onChanged(nameof(FiguresList));
            }
        }
    }
}