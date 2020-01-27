﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
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
            model.Id = 1;

            return model;
        }
    }
}
