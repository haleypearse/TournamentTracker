using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        // TODO = Make the CreatePrize method save to the db.
        /// <summary>
        /// Saves a new prize to db.
        /// </summary>
        /// <param name="model">Thr prize info</param>
        /// <returns>The prize info, including the ID</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            /// Microsoft's interface data connection 
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id"); // gets id as int

                return model;


            } // Above connection is destroyed here
        }  
    }
}

//@Placenumber int, 
//	@PlaceName nvarchar(50), -- limit incoming data to amount that

//    @PrizeAmount money,
//    @PrizePercentage float,
//	@id int = 0 output   