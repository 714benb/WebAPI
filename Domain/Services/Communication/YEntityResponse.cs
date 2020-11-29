using WebAPI.API.Domain.Models;

namespace WebAPI.API.Domain.Services.Communication
{
    public class YEntityResponse : BaseResponse<YEntity>
    {

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="YEntity">Saved or deleted yEntity.</param>
        /// <returns>Response.</returns>
        public YEntityResponse(YEntity YEntity) : base(YEntity)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public YEntityResponse(string message) : base( message)
        { }
    }


}