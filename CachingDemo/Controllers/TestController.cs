using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public string GetDateTime()
        {
            return DateTime.Now.ToLongTimeString();
        }
        
    }

    

