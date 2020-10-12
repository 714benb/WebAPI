using WebAPI.API.Domain.Models;

namespace WebAPI.API.Domain.Services.Communication
{
    public class XEntityResponse : BaseResponse
    {
        public XEntity XEntity { get; private set; }

        private XEntityResponse(bool success, string message, XEntity xEntity) : base(success, message)
        {
            XEntity = xEntity;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="xEntity">Saved or deleted xEntity.</param>
        /// <returns>Response.</returns>
        public XEntityResponse(XEntity xEntity) : this(true, string.Empty, xEntity)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public XEntityResponse(string message) : this(false, message, null)
        { }
    }


}