using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model); 
        // In an interface, all is public, so no need to mark public
        // When CreatePrize is called passing in a PrizeModel, returns  a PrizeModel
        // Returns same data but filled in
    }
}
