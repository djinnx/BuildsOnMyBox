namespace BOMB.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BOMB.Data;

    /// <summary>
    /// A way to run the data migrations from higher layers
    /// </summary>
    public static class DataMigrations
    {
        /// <summary>
        /// Runs the data migrations
        /// </summary>
        public static void Run()
        {
            UnitOfWork uow = new UnitOfWork();
            uow.RunDataMigrations();
        }
    }
}
