using ELM_Filtering_Service.Commands;
using ELM_Filtering_Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace ELM_Filtering_Service.ViewModels
{
    class ReviewMessageViewModel : DefaultViewModel
    {
        //Button Bindings
        public ICommand LoadFileButtonCommand { get; set; }
        public ICommand PreviousFileButtonCommand { get; set; }
        public ICommand NextFileButtonCommand { get; set; }
        public string LoadFileButtonText { get; set; }
        //Text Binding
        public string TextTitle { get; set; }
        //List Bindings
        public string[] ListFiles { get; set; }
        public string SelectedFile { get; set; }
        public string ReadID { get; set; }
        public string ReadSender { get; set; }
        public string ReadBody { get; set; }

        string filePath = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), @"JsonOutputs\");
        public int counter = 0;
        public int NumberOfFiles { get; set; }

        public ReviewMessageViewModel()
        {
            ListFiles = Directory.GetFiles(filePath, "*.json").Select(file => Path.GetFileName(file)).ToArray();
            NumberOfFiles = ListFiles.Length;
            TextTitle = "Review Messages";
            LoadFileButtonText = "Load File";
            LoadFileButtonCommand = new RelayCommand(LoadFileButtonClick);
            PreviousFileButtonCommand = new RelayCommand(PreviousButtonClick);
            NextFileButtonCommand = new RelayCommand(NextButtonClick);
        }

        private void UpdateBindings()
        {
            onChanged(nameof(ReadID));
            onChanged(nameof(ReadSender));
            onChanged(nameof(ReadBody));
        }

        //Loads selected file from dropdown list
        private void LoadFileButtonClick()
        {
            Message message = new Message();
            if(SelectedFile != null)
            {
                string fileName = Path.Combine(filePath, SelectedFile);
                message = JsonConvert.DeserializeObject<Message>(File.ReadAllText(fileName));
                List<string> DeserializedList = new List<string>();
                DeserializedList.Add(message.MessageID);
                DeserializedList.Add(message.MessageSender);
                DeserializedList.Add(message.MessageBody);
                ReadID = "MESSAGE ID:\t" + DeserializedList[0];
                ReadSender = "SENDER:\t\t" + DeserializedList[1];
                ReadBody = "MESSAGE:\n" + DeserializedList[2];
                UpdateBindings();
            }
        }

        //Loads the previous file from the directory, aslong as it isnt the first in the list
        private void PreviousButtonClick()
        {
            if (counter > 0)
            {
                Message message = new Message();
                string fileName = Directory.EnumerateFiles(filePath).Skip(counter - 1).First();
                counter--;
                message = JsonConvert.DeserializeObject<Message>(File.ReadAllText(fileName));
                List<string> DeserializedList = new List<string>();
                DeserializedList.Add(message.MessageID);
                DeserializedList.Add(message.MessageSender);
                DeserializedList.Add(message.MessageBody);
                ReadID = "MESSAGE ID:\t" + DeserializedList[0];
                ReadSender = "SENDER:\t\t" + DeserializedList[1];
                ReadBody = "MESSAGE:\n" + DeserializedList[2];
                UpdateBindings();
            }
        }
        
        //Loads the next file from the directory, aslong as it isnt the last in the list
        private void NextButtonClick()
        {
            if(counter < NumberOfFiles)
            {
                Message message = new Message();
                string fileName = Directory.EnumerateFiles(filePath).Skip(counter).First();
                counter++;
                message = JsonConvert.DeserializeObject<Message>(File.ReadAllText(fileName));
                List<string> DeserializedList = new List<string>();
                DeserializedList.Add(message.MessageID);
                DeserializedList.Add(message.MessageSender);
                DeserializedList.Add(message.MessageBody);
                ReadID = "MESSAGE ID:\t" + DeserializedList[0];
                ReadSender = "SENDER:\t\t" + DeserializedList[1];
                ReadBody = "MESSAGE:\n" + DeserializedList[2];
                UpdateBindings();
            }
        }
    }
}
