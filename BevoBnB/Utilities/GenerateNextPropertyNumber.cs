using BevoBnB.DAL;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace BevoBnB.Utilities
{
    public class GenerateNextPropertyNumber
    {
        public static int GetNextPropertyNumber(AppDbContext _context)
        {
            const int START_NUMBER = 3000;

            int intMaxPropertyNumber;
            int intNextPropertyNumber;

            if (_context.Properties.Any() == false)
            {
                intMaxPropertyNumber = START_NUMBER;
            }
            else
            {
                intMaxPropertyNumber = _context.Properties.Max(c => c.PropertyNumber);
            }

            if (intMaxPropertyNumber < START_NUMBER)
            {
                intMaxPropertyNumber = START_NUMBER;
            }

            intNextPropertyNumber = intMaxPropertyNumber + 1;

            return intNextPropertyNumber;
        }
    }
}
