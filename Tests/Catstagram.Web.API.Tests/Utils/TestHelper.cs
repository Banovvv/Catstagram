using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Web.API.Tests.Utils
{
    public class TestHelper
    {
        public static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
