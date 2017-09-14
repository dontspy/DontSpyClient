﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    internal class ChatOverviewPageViewModel : INotifyPropertyChanged
    {
        private ChatOverviewPage _view;

        public string Title { get; set; } = "Chatübersicht";
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Timestamp { get; set; }

        public ObservableCollection<Message> Messages { get; }
        public ICommand NewChatCommand { protected set; get; }
        public ICommand NewGroupChatCommand { protected set; get; }

        public ChatOverviewPageViewModel()
        {
            NewChatCommand = new Command<object>(param =>
            {
                _view.Navigation.PushAsync(new ContactPage());
            });

            NewGroupChatCommand = new Command<object>(param =>
            {
                _view.Navigation.PushAsync(new ContactPage());
            });

            Messages = new ObservableCollection<Message>();

            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
        }

        public void SetView(ChatOverviewPage view)
        {
            _view = view;
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
