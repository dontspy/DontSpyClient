﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public string Title { get; set; } = "Inbox";
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Timestamp { get; set; }

        public ObservableCollection<Channel> Channel { get; set; }
        public ICommand NewChatCommand { protected set; get; }
        public ICommand NewGroupChatCommand { protected set; get; }
        public ICommand TabbedChannelCommand { protected set; get; }


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

            TabbedChannelCommand = new Command<object>(param =>
            {
                var channel = (Channel)param;
                _view.Navigation.PushAsync(channel.ChannelPage);
            });

            /* TODO Channel = new ObservableCollection<Channel>();
            var app = new App(true);
            foreach (var channel in app.AllChannels)
            {
                Channel.Add(channel);
            }*/
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

