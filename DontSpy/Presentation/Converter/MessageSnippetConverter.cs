﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace DontSpy.Presentation.Converter
{
    internal class MessageSnippetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {/*
            var messages = (List<Message>)value;
            if (messages.Count < 1) return ""; // If no messages, do not show a snippet
            var keyTable = (Dictionary<int, int>)parameter;
            IDecrypt decryption = new DecryptionLogic(messages.Last(), keyTable);
            var messageToBeSnip = decryption.Decrypt().Text;
            if (messageToBeSnip.Length > 10) return messages.Last().Text.Substring(0, 10) + AppResources.MessageSnippetMoreSign;
            return messageToBeSnip;*/
            return "";//TODO tut nur wenn man den channel selber angelegt hat muss man wieder einfügen
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
