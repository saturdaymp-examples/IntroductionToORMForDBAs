using System;
using System.Linq;
using SaturdayMP.GameTracker.Models;

namespace SaturdayMP.GameTracker.Data
{
    public static class DbInitializer
    {

        public static void Initialize(GameTrackerContext context)
        {
            if (context.GameResultTypes.Any())
            {
                // DB has already been seeded.
                return;
            }


            // Seed the Game Type Enums.
            foreach(GameResultTypeEnums result in Enum.GetValues(typeof(GameResultTypeEnums)))
            {
                context.Add<GameResultType>(result);
                context.SaveChanges();
            }
                
        }
    }
}
