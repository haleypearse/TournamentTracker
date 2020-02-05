using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig // Static means can't instantiate. Data is global.
    {
        /// <summary>
        /// Static class to hold connection interface.
        /// </summary>
        public static List<IDataConnection> Connections 
            { get; private set; } = new List<IDataConnection>();
        // Only methods inside of this global config class can set value of connections. 
        // Otherwise read only. List means can have >=1 data source 

        /// <summary>
        /// Identify which classes to put in list of connections
        /// </summary>
        /// <param name="database"></param>
        /// <param name="textFiles"></param>
        public static void InitializeConnections(bool database, bool textFiles)
            
        {
            if (database)
            {
                // TODO - Set up sql connector properly
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }  
            if (textFiles)
            {
                // TODO - Create the text connection
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }

        public static string CnnString(string name) 
            // If call globalconfig.CnnString(name),
            //they get back the connection string in app.config
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
