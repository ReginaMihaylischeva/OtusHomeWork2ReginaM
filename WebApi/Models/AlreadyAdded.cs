using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApi.Models
{
    [DefaultStatusCode(409)]
    public class AlreadyAdded : StatusCodeResult
    {
        public AlreadyAdded() : base(409)
        {
        }
    }
}
