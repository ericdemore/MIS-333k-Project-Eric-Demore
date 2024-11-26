using BevoBnB.DAL;

namespace BevoBnB.Utilities
{
    public class GenerateNextConfirmationNumber
    {
        public static Int32 GetNextConfirmationNumber(AppDbContext _context)
        {
            const Int32 START_NUMBER = 21901;

            Int32 intMaxConfirmationNumber; // Current max confirmation number
            Int32 intNextConfirmationNumber; // Next confirmation number

            if (!_context.Reservations.Any()) // No reservations in the database yet
            {
                intMaxConfirmationNumber = START_NUMBER;
            }
            else
            {
                // Handle nullable ConfirmationNumber and find the max
                intMaxConfirmationNumber = _context.Reservations
                    .Where(c => c.ConfirmationNumber.HasValue)
                    .Max(c => c.ConfirmationNumber.Value);
            }

            // Ensure the starting point is never below START_NUMBER
            if (intMaxConfirmationNumber < START_NUMBER)
            {
                intMaxConfirmationNumber = START_NUMBER;
            }

            // Increment to get the next confirmation number
            intNextConfirmationNumber = intMaxConfirmationNumber + 1;

            return intNextConfirmationNumber;
        }

    }
}
