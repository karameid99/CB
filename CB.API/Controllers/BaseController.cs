using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using CB.Models.Constants;
using CB.Models.Models;
using System.Collections.Generic;
using CB.Models.Resources;
using System.Net;

namespace CB.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected string UserId;
        protected string Language;
        protected APIResponse _response;

        public BaseController()
        {
            _response = new APIResponse();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!context.ModelState.IsValid)
            {
                context.Result = new ObjectResult(new APIResponseError
                {
                    Status = false,
                    Message = MessageResource.MissingRequiredFields,
                    Error = new BadRequestObjectResult(context.ModelState).Value
                })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            if (User.Identity.IsAuthenticated)
            {
                UserId = User.FindFirst(Claims.UserId).Value;
            }

            Language = Thread.CurrentThread.CurrentUICulture.Name;
        }
        #region Response

      


        /// <summary>
        /// Get General Error response
        /// </summary>
        /// <param name="responseEnum">Delete or NotFound</param>
        /// <returns>Ok response (Status=false, Data=null, Message=GeneralError)</returns>
        [NonAction]
        public IActionResult GetErrorResponse()
        {
            _response.Status = false;
            _response.Message = MessageResource.GeneralError;
            return Ok(_response);
        }

        /// <summary>
        /// Get Error response
        /// </summary>
        /// <param name="message">error Message </param>
        /// <returns>Ok response (Status=false, Data=null, Message=message)</returns>
        [NonAction]
        public IActionResult GetErrorResponse(string message)
        {
            _response.Status = false;
            _response.Message = message;
            return Ok(_response);
        }
        #endregion
        #region Success
        /// <summary>
        /// Get Success response with entity(es).
        /// </summary>
        /// <param name="data">Base entity to return it with response data</param>
        /// <returns>Ok response (Status=true, Data=data, Message=GeneralSucess)</returns>
        [NonAction]
        public IActionResult GetResponse(object data)
        {
            _response.Status = true;
            _response.Message = MessageResource.Succses;
            _response.Data = data;
            return Ok(_response);
        }

        /// <summary>
        /// Get General Sucess response with paging entities
        /// </summary>
        /// <param name="count">tatal result count</param>
        /// <param name="data">list of data items</param>
        /// <returns>Ok response (Status=true, Data=PagingVm, Message=GeneralSucess)</returns>
        [NonAction]
        public IActionResult GetResponsePagin<T>(int count, IEnumerable<T> data)
        {
            _response.Status = true;
            _response.Message = MessageResource.Succses;
            _response.Data = new PagingVm()
            {
                Data = data.ToString(),
                Total = count
            };
            return Ok(_response);
        }

        /// <summary>
        /// Get General Sucess response
        /// </summary>
        /// <returns>Ok response (Status=false, Data=null, Message=GeneralSucess)</returns>
        [NonAction]
        public IActionResult GetResponse()
        {
            _response.Status = true;
            _response.Message = MessageResource.Succses;
            return Ok(_response);
        }
        #endregion
        #region Full
        /// <summary>
        /// Get Api response object
        /// </summary>
        /// <param name="data">object Data</param>
        /// <param name="message">reponse message</param>
        /// <param name="status">True if success, and false if there is any failer</param>
        /// <returns>Ok response (Status=status, Data=data, Message=message)</returns>
        [NonAction]
        public IActionResult GetResponse(object data, string message, bool status)
        {
            _response.Status = status;
            _response.Message = message;
            _response.Data = data;
            return Ok(_response);
        }
        #endregion

    }
}
