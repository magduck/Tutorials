using System;
using System.Windows.Forms;
using DomainModel.Infrastructure;
using DomainModel.SQL;
using Presentation.View;
using Presentation.Presenter;
using System.Configuration;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IView view = new Presentation.View.View();
            view.OnePageRowsCount = GetOnePageRowsCountFromConfigFile();
            IDataRepository model = new AdoDataRepository(GetDBConnectionStringFromConfigFile(), UseDataCache());
            Presenter presenter = new Presenter(view, model);

            Application.Run(new MainForm(view));
        }

        #region Config values 

        private static IDataCache UseDataCache()
        {
            var useDataCaching = ConfigurationManager.AppSettings["UseDataCaching"];

            if (useDataCaching != null)
            {
                
                if (int.Parse(useDataCaching) > 0)
                    return new SqlDataCache();
            }

            return null; 
        }

        private static int GetOnePageRowsCountFromConfigFile()
        {
            var rowCountParamValue = ConfigurationManager.AppSettings["OnePageRowsCount"];

            if (rowCountParamValue == null)
                throw new NullReferenceException("There is no config section for one page rows count parameter!");

            return int.Parse(rowCountParamValue);    
        }

        private static string GetDBConnectionStringFromConfigFile()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            if (connectionString == null)
                throw new NullReferenceException("There is no config section for DB connection string!");

            return connectionString;
        }

        #endregion
    }
}
