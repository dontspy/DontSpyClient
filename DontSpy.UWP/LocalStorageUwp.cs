﻿using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using DontSpy.UWP;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;

[assembly: Xamarin.Forms.Dependency(typeof(LocalStorageUwp))]
namespace DontSpy.UWP
{
    public class LocalStorageUwp : Service.StorageService, Interfaces.IStorage
    {
        private SQLiteConnectionWithLock _conn;

        private static string GetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, Constants.LocalDatabaseName);
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), GetDatabasePath());
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => _conn ?? (_conn = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(),
                                                                                 new SQLiteConnectionString(GetDatabasePath(), true))));
            return new SQLiteAsyncConnection(connectionFactory);
        }

        public void DeleteDatabase()
        {
            var path = GetDatabasePath();

            try
            {
                _conn?.Close();
            }
            catch
            {
            }

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            _conn = null;
        }

        public void CloseConnection()
        {
            if (_conn == null) return;

            _conn.Close();
            _conn.Dispose();
            _conn = null;

            // Must be called as the disposal of the connection is not released until the GC runs.
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public async Task<string> SaveImage(string filename, byte[] stream)
        {
            var localSharedFolder = ApplicationData.Current.LocalCacheFolder;
            var file = await localSharedFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteBytesAsync(file, stream);
            return Path.Combine(localSharedFolder.Path, filename);
        }
    }
}
