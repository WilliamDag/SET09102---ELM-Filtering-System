using ELM_Filtering_Service.Commands;
using ELM_Filtering_Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ELM_Filtering_Service.ViewModels
{
    class AddMessageViewModel : DefaultViewModel
    {
        //Text Bindings
        public string TextTitle { get; set; }
        public string TextSender { get; set; }
        public string TextSubject { get; set; }
        public string TextBody { get; set; }
        //TextBox Bindings
        public string TextBoxSubject { get; set; }
        public string TextBoxSender { get; set; }
        public string TextBoxBody { get; set; }
        public int MessageMax { get; set; }
        public bool EnableSubject { get; set; }
        public bool EnableBody { get; set; }
        public bool EnableSender { get; set; }
        //Button Bindings
        public ICommand SenderButtonCommand { get; set; }
        public ICommand ClearButtonCommand { get; set; }
        public ICommand ProcessButtonCommand { get; set; }
        public ICommand ImportButtonCommand { get; set; }
        public string SenderButtonText { get; set; }
        public string ClearButtonText { get; set; }
        public string ProcessButtonText { get; set; }
        public string ImportButtonText { get; set; }
        //Message Variables
        public string messageID { get; set; }
        bool isSMS = false;
        bool isTweet = false;
        bool isEmail = false;

        Message message = new Message();
        Dictionary<String, String> abbreviationList = new Dictionary<String, String>();
        Random random = new Random();

        public AddMessageViewModel()
        {
            EnableSubject = false;
            EnableBody = false;
            EnableSender = true;

            string binPath = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            StreamReader sr = new StreamReader(Path.Combine(binPath, @"textwords.csv"));

            string line = string.Empty;
            string key = string.Empty;
            string value = string.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                line = line.Replace("\"", "");
                string[] stringsArr = line.Split(',');
                key = stringsArr[0];
                value = stringsArr[1];

                abbreviationList.Add(key, value);
            }
            sr.Close();

            SenderButtonText = "Start Message";
            ClearButtonText = "Clear";
            ProcessButtonText = "Process Message";
            ImportButtonText = "Import Message";

            SenderButtonCommand = new RelayCommand(SenderButtonClick);
            ClearButtonCommand = new RelayCommand(ClearButtonClick);
            ProcessButtonCommand = new RelayCommand(ProcessButtonClick);
            ImportButtonCommand = new RelayCommand(ImportButtonClick);

            TextTitle = "Add New Message";
            TextSubject = "Subject (Email Only)";
            TextSender = "Sender";
            TextBody = "Body";

            //The textbox values have all been created and set to an initial value of empty string.
            //These are going to be Binding to the TextBoxes on the XAML file.

            TextBoxSubject = string.Empty;
            TextBoxSender = string.Empty;
            TextBoxBody = string.Empty;
        }

        //Calling theOnChanged method, which I created in the DefaultViewModel
        //class and letting it know that there has been a change in a property.
        private void UpdateBindings()
        {
            onChanged(nameof(TextBoxBody));
            onChanged(nameof(TextBoxSubject));
            onChanged(nameof(TextBoxSender));
            onChanged(nameof(isEmail));
            onChanged(nameof(isSMS));
            onChanged(nameof(isTweet));
            onChanged(nameof(MessageMax));
            onChanged(nameof(EnableSender));
            onChanged(nameof(EnableBody));
            onChanged(nameof(EnableSubject));
            onChanged(nameof(messageID));
        }

        private void SenderButtonClick()
        {
            int idNumber = random.Next(000000000, 999999999);

            if (string.IsNullOrWhiteSpace(TextBoxSender))
            {
                MessageBox.Show("Please fill out the Sender\n(E.g @JohnSmith / John@Smith.co.uk / 07123456789)", "Missing Details");
                return;
            }
            else
            {
                //Check for phone number
                Regex phoneNumberRegex = new Regex(@"\+\d{1,15}");
                if (phoneNumberRegex.IsMatch(TextBoxSender) && TextBoxSender.Length >= 12 && TextBoxSender.Length <=16)
                {
                    MessageMax = 140;
                    EnableSubject = false;
                    EnableBody = true;
                    EnableSender = false;
                    messageID = "S" + idNumber;
                    isSMS = true;
                }
                //Check for Tweet
                if (TextBoxSender[0] == '@')
                {
                    if (TextBoxSender.Length < 15 && TextBoxSender.Length > 1)
                    {
                        string ID = TextBoxSender.Substring(1, TextBoxSender.Length - 1);
                        if (ID.All(c => Char.IsLetterOrDigit(c) || c.Equals('_')))
                        {
                            MessageMax = 140;
                            EnableSubject = false;
                            EnableBody = true;
                            EnableSender = false;
                            messageID = "T" + idNumber;
                            isTweet = true;
                        }
                    }
                }
                //Check for Email
                bool emailCheck(string emailAddress)
                {
                    try
                    {
                        MailAddress m = new MailAddress(emailAddress);
                        return true;
                    }
                    catch (FormatException)
                    {
                        return false;
                    }
                }
                if (emailCheck(TextBoxSender))
                {
                    MessageMax = 1028;
                    EnableSubject = true;
                    EnableBody = true;
                    EnableSender = false;
                    messageID = "E" + idNumber;
                    isEmail = true;
                }
            }
            if (!isEmail && !isSMS && !isTweet)
            {
                MessageBox.Show("Invalid Sender Format");
            }
            message.MessageID = messageID;
            message.MessageSender = TextBoxSender;
            UpdateBindings();
        }

        //Import a txt file contents into the message textbox
        private void ImportButtonClick()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var MessageImport = File.ReadAllText(openFileDialog.FileName);
                TextBoxBody = MessageImport.Substring(0, MessageImport.Length > MessageMax ? MessageMax : MessageImport.Length);
                onChanged(nameof(TextBoxBody));
            }
        }

        //Process the message, completing necessary tasks for each message type
        private void ProcessButtonClick()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString("dd_MM_yy");
            string binPath = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            string TwitterOutput = Path.Combine(binPath, @"Figures\" + "TwitterFigs_" + date + @".txt");
            string QuarantineOutput = Path.Combine(binPath, @"Figures\" + "Quarantines_" + date + @".txt");

            if (String.IsNullOrWhiteSpace(TextBoxBody))
            {
                MessageBox.Show("Please type a message!");
                return;
            }
            else
            {
                //If the message is an email
                if (isEmail)
                {
                    string sirDateRegex = @"SIR \d{2}[/]\d{2}[/]\d{2}";
                    string sccRegex = @"\b\d{2}[-]\d{3}[-]\d{2}";
                    if (Regex.IsMatch(TextBoxSubject, sirDateRegex))
                    {
                        string SIRday = TextBoxSubject.Substring(4, 2);
                        string SIRmonth = TextBoxSubject.Substring(7, 2);
                        string SIRyear = TextBoxSubject.Substring(10, 2);
                        string SIROutput = Path.Combine(binPath, @"Figures\" + "SIR_" + SIRday + "_" + SIRmonth + "_" + SIRyear + @".txt");
                        string[] checkSIR = TextBoxBody.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
                        if(checkSIR.Length >= 2)
                        {
                            if (Regex.IsMatch(checkSIR[0], sccRegex) && new[]{"Theft of Properties","Staff Attack","Device Damage","Raid"
                        ,"Customer Attack","Staff Abuse","Bomb Threat","Terrorism","Suspicious Incident", "Sport Injury","Personal Info Leak"}.Contains(checkSIR[1]))
                            {
                                TextWriter SIR = File.AppendText(SIROutput);
                                SIR.WriteLine(checkSIR[0] + " --- " + checkSIR[1]);
                                SIR.Close();
                            }
                            else
                            {
                                MessageBox.Show("You are tring to log an SIR.\nPlease make sure the first two lines contain SCC and Nature of Incident.");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You are tring to log an SIR.\nPlease make sure the first two lines contain SCC and Nature of Incident.");
                            return;
                        }
                    }
                    //Find URLs in Email Body
                    string[] checkURL = TextBoxBody.Split(new string[] { " ", "\r\n" }, StringSplitOptions.None);
                    string findURL = @"(((http|ftp|https):\/\/)?[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:\/~\+#]*[\w\-\@?^=%&amp;\/~\+#])?)";
                    foreach (string url in checkURL)
                    {
                        if(Regex.IsMatch(url, findURL))
                        {
                            TextWriter Quarantine = File.AppendText(QuarantineOutput);
                            Quarantine.WriteLine(url);
                            TextBoxBody = TextBoxBody.Replace(url, "<URL QUARANTINED>");
                            Quarantine.Close();
                        }
                        onChanged(nameof(TextBoxBody));
                        message.MessageBody = "SUBJECT: " + TextBoxSubject + "\r\n" + TextBoxBody;
                    }
                }
                //Do textspeak for SMS and Tweet
                if (isSMS || isTweet)
                {
                    //Check dictionary for each item in the textboxBody
                    foreach (KeyValuePair<string, string> KV in abbreviationList)
                    {
                        string checkAbbrv = (@"(^|\s)" + KV.Key + @"(\s|$)");
                        if (Regex.IsMatch(TextBoxBody, checkAbbrv))
                        {
                            //Insert <Translation> after Abbreviation
                            int index = TextBoxBody.IndexOf(KV.Key) + KV.Key.Length;
                            TextBoxBody = TextBoxBody.Insert(index, " <" + KV.Value.ToString() + ">");
                        }
                        onChanged(nameof(TextBoxBody));
                        message.MessageBody = TextBoxBody;
                    }
                    if (isTweet)
                    {
                        string[] checkHashAndTags = TextBoxBody.Split(new string[] { " ", "\r\n" }, StringSplitOptions.None);
                        foreach (string word in checkHashAndTags)
                        {
                            try
                            {
                                if (word[0] == '#' || word[0] == '@')
                                {
                                    TextWriter Figures = File.AppendText(TwitterOutput);
                                    Figures.WriteLine(word);
                                    Figures.Close();
                                }
                            }
                            catch(IndexOutOfRangeException)
                            {
                                
                            }
                        }
                    }
                }
                //Setup path and filename for JSON file
                string fileName = messageID + ".json";
                string jsonOutputs = Path.Combine(binPath, @"JsonOutputs\", fileName);

                //Serialize message object to JSON file
                using (StreamWriter file = File.CreateText(jsonOutputs))
                {
                    JsonSerializer ser = new JsonSerializer();
                    ser.Formatting = Formatting.Indented;
                    ser.Serialize(file, message);
                    MessageBox.Show("Message Successfully Processed!\nMessage ID: " + messageID, "Success");
                    ClearButtonClick();
                }
            }
        }
        
        //Clear all UI components
        private void ClearButtonClick()
        {
            TextBoxSender = string.Empty;
            TextBoxSubject = string.Empty;
            TextBoxBody = string.Empty;
            EnableSubject = false;
            EnableBody = false;
            EnableSender = true;

            UpdateBindings();
        }
    }
}