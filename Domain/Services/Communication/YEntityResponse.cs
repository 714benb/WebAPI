using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services.Communication
{
    public class YEntityResponse : BaseResponse
    {
        public YEntity YEntity { get; private set; }

        private YEntityResponse(bool success, string message, YEntity yEntity) : base(success, message)
        {
            YEntity = yEntity;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="YEntity">Saved or deleted yEntity.</param>
        /// <returns>Response.</returns>
        public YEntityResponse(YEntity YEntity) : this(true, string.Empty, YEntity)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public YEntityResponse(string message) : this(false, message, null)
        { }
    }


}