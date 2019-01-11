namespace Elmah.Model
{
    public interface IService
    {
        /// <summary>
        /// This method will run without any exception.
        /// </summary>
        void ProcessWithNoError(Product product);

        /// <summary>
        /// This won't run. It throws an exception. 
        /// </summary>
        /// <exception cref="BusinessException">The exception that will happen.</exception>
        void ProcessWithError(Product product);
    }

    public class Service : IService
    {
        public void ProcessWithError(Product product)
        {
            throw new BusinessException(product);
        }

        public void ProcessWithNoError(Product product) { }
    }
}
