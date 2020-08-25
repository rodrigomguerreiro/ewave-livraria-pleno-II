using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using ToDo.Domain.Exceptions;

namespace ToDo.API.Configs
{
    public class AppExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var res = context.HttpContext.Response;
            res.ContentType = "application/json; charset=utf-8";

            if (context.Exception is ArgumentException || context.Exception is ExceptionBase)
            {
                res.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                res.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Result = new JsonResult(context.Exception.Message);
        }
    }
}
