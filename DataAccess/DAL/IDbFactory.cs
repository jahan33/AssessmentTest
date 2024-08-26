namespace DataAccess.DAL
{
    // Define a public interface named IDbFactory that inherits from IDisposable.
    public interface IDbFactory : IDisposable
    {

        /// <summary>
        /// Method to retrieve an instance of FlightDBContext.
        /// </summary>
        /// <returns>Returns an instance of FlightDBContext.</returns>
        FlightDBContext Get();
    }
}
