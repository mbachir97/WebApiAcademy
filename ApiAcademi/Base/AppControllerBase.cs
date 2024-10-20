using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using  AcademiProject.Core.Basic;
using System.Reflection.Metadata.Ecma335;
namespace ApiAcademi.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;
        public AppControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ObjectResult NewResult<T>(Response<T> response)
        {

            List<string> errors = [];
            return response.StatusCode switch
            {

                HttpStatusCode.OK => new OkObjectResult(response),
                HttpStatusCode.Created => new CreatedResult(string.Empty, response),
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
                HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
                HttpStatusCode.NotFound => new NotFoundObjectResult(response),
                HttpStatusCode.Accepted => new AcceptedResult(string.Empty, response),
                HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response), HttpStatusCode
                _ => new BadRequestObjectResult(response)

            }; 
            //switch (response.StatusCode)
            //{
            //    case HttpStatusCode.OK:
            //        return new OkObjectResult(response);
            //    case HttpStatusCode.Created:
            //        return new CreatedResult(string.Empty, response);
            //    case HttpStatusCode.Unauthorized:
            //        return new UnauthorizedObjectResult(response);
            //    case HttpStatusCode.BadRequest:
            //        return new BadRequestObjectResult(response);
            //    case HttpStatusCode.NotFound:
            //        return new NotFoundObjectResult(response);
            //    case HttpStatusCode.Accepted:
            //        return new AcceptedResult(string.Empty, response);
            //    case HttpStatusCode.UnprocessableEntity:
            //        return new UnprocessableEntityObjectResult(response);
            //    default:
            //        return new BadRequestObjectResult(response);
            //}

            
        }


    }
}
