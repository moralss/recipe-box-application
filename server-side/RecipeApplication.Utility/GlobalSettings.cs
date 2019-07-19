using System;
using System.Threading;
using RecipeApplication.Utility.Settings.Data;


namespace RecipeApplication.Utility
{
    public sealed class GlobalSettings : IDisposable
    {
        #region private members...

        private static volatile Settings.Artefacts.Settings _instance;
        private static object _syncRoot = new object();

        #endregion private members...

        public static bool Refresh()
        {
            if (_instance == null)
                return false;

            var isRefreshed = false;

            // Wait until the lock is available and lock the queue.
            try
            {
                if (Monitor.TryEnter(_instance, 1000)) //wait for thead until ready with specified timeout...
                {
                    Dispose();
                    isRefreshed = true;
                }
            }
            finally
            {
                try
                {
                    Monitor.Exit(_instance);
                }
                catch (ArgumentNullException)
                {
                    //when the instance is null it will be refreshed when read.
                    isRefreshed = true;
                }
            }

            return isRefreshed;
        }

        public static Settings.Artefacts.Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = SettingDBAsync.Search(isActive: true);
                        }
                    }
                }

                return _instance;
            }

            set => _instance = value;
        }

        #region Keys

#if DEBUG
        public static string DbConnectionString => "Server=devsonsoftware.dedicated.co.za;Database=MoralDev;User Id=Moral; Password=PIx3PckQpMnOubktot60;";
#else
        public static string DbConnectionString => "Database=SoccerApp;Data Source=WARRICK-PC\\SQLEXPRESS;Integrated Security=true;Min Pool Size=0;Max Pool Size = 50;Timeout=60;";
#endif

        #endregion Keys

        private static void Dispose()
        {
            GC.SuppressFinalize(_instance);
            GC.SuppressFinalize(_syncRoot);

            _instance = null;
            _syncRoot = new object();
        }

        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}
