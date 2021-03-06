﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DontSpy.Model;
using DontSpy.Presentation.View;
using DontSpy.Translations;
using Xamarin.Forms;

namespace DontSpy.Presentation.ViewModel
{
    public class ChannelsPageViewModel : INotifyPropertyChanged
    {
        private ChannelsPage _view;
        private string _title = AppResources.ChannelsHeading;
        private Dictionary<int, int> KeyTable {set; get; }
        public ObservableCollection<Channel> Channels { get; } = new ObservableCollection<Channel>();
        public ICommand NewSingleChannelCommand { protected set; get; }
        public ICommand NewGroupChannelCommand { protected set; get; }
        public ICommand TabbedChannelCommand { protected set; get; }

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public ChannelsPageViewModel()
        {
            // Load all channels from local database
            foreach (var channel in DependencyManager.ChannelService.LoadChannels()) Channels.Add(channel);

            NewSingleChannelCommand = new Command<object>(param =>
            {
                // Hack, because layout do not update by changing visibility status
                var anchorPageContactsChild = DependencyManager.AnchorPage.Children[1];
                DependencyManager.AnchorPage.Children[1].Navigation.PopToRootAsync(false);
                DependencyManager.AnchorPage.Children.RemoveAt(1);
                DependencyManager.ContactsPage.ViewModel.DeactivateMultipleSelectionSupport();
                DependencyManager.AnchorPage.Children.Add(anchorPageContactsChild);
                DependencyManager.AnchorPage.CurrentPage = DependencyManager.AnchorPage.Children[1]; // Switch tab
            });

            NewGroupChannelCommand = new Command<object>(param =>
            {
                // Hack, because layout do not update by changing visibility status
                var anchorPageContactsChild = DependencyManager.AnchorPage.Children[1];
                DependencyManager.AnchorPage.Children[1].Navigation.PopToRootAsync(false);
                DependencyManager.AnchorPage.Children.RemoveAt(1);
                DependencyManager.ContactsPage.ViewModel.ActivateMultipleSelectionSupport();
                DependencyManager.AnchorPage.Children.Add(anchorPageContactsChild);
                DependencyManager.AnchorPage.CurrentPage = DependencyManager.AnchorPage.Children[1]; // Switch tab
            });

            TabbedChannelCommand = new Command<object>(param =>
            {
                DependencyManager.AnchorPage.Children[0].Navigation.PopToRootAsync(false);
                DependencyManager.AnchorPage.Children[1].Navigation.PopToRootAsync(false);
                _view.Navigation.PushAsync(((Channel)param).View);
            });
        }

        public void SetView(ChannelsPage view)
        {
            _view = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
