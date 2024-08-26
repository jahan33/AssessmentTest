namespace Service.IServices
{
    // Define a public interface named IFlightChangeDetectionService.
    public interface IFlightChangeDetectionService
    {
        /// <summary>
        /// Method to detect flight changes within a specified date range and for a specific agency.
        /// </summary>
        /// <param name="startDate">The start date of the period to check for flight changes.</param>
        /// <param name="endDate">The end date of the period to check for flight changes.</param>
        /// <param name="agencyId">The ID of the agency for which flight changes are being detected.</param>
        void DetectChanges(DateTime startDate, DateTime endDate, int agencyId);
    }
}
