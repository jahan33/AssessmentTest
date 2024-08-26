namespace DataAccess.DAL
{

    // Define a public class named DbFactory that implements the IDbFactory interface.
    public class DbFactory : IDbFactory
    {
        // Declare a private variable to hold the instance of FlightDBContext.
        private FlightDBContext _context;

        /// <summary>
        /// Method to get the current FlightDBContext instance.
        /// </summary>
        /// <returns>Returns an instance of FlightDBContext.</returns>
        public FlightDBContext Get()
        {
            // Dispose of the current context if necessary and reset it.
            Dispose(true);

            // Return the current context if it exists; otherwise, create a new instance of FlightDBContext.
            return _context ?? (_context = new FlightDBContext());
        }

        #region Dispose

        // Declare a private boolean variable to track whether the object has been disposed.
        private bool _disposed;

        /// <summary>
        /// Method to dispose of the resources used by the DbFactory.
        /// </summary>
        /// <param name="disposing">Indicates whether managed resources should be disposed.</param>
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // If disposing is true, dispose of the context if it exists.
                // This block of code is commented out, so the context will not actually be disposed.
                // if (_context != null)
                // {
                //     _context.Dispose();
                //     _context = null;
                // }
            }
        }

        /// <summary>
        /// Public method to dispose of the resources, calling the protected Dispose method.
        /// </summary>
        public void Dispose()
        {
            // Call the Dispose method with true to release managed resources.
            Dispose(true);

            // Suppress finalization of this object to prevent the finalizer from running.
            GC.SuppressFinalize(this);
        }

        #endregion

        // Finalizer to ensure the object is disposed of when it is collected by the garbage collector.
        ~DbFactory()
        {
            // Call the Dispose method to clean up resources.
            Dispose();
        }
    }
}

