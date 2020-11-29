using WebAPI.API.Domain.Models;

namespace WebAPI.API.Domain.Services.Communication
{
    public class XEntityResponse : BaseResponse<XEntity>
    {

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="xEntity">Saved or deleted xEntity.</param>
        /// <returns>Response.</returns>
        public XEntityResponse(XEntity xEntity) : base(xEntity)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public XEntityResponse(string message) : base(message)
        { }
    }


}