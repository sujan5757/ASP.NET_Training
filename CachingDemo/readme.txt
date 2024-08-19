Step 1:
In Program.cs

Add service 
builder.Services.AddResponseCaching();

Add  middleware
app.UseResponseCaching();

Step  2:
On controller/action method
[HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public string GetDateTime()
        {
            return DateTime.Now.ToLongTimeString();
        }

step 3:
Run the app

step 4:
Note: Make sure cache not disabled in postman.
If it is disabled enable it in settings->general
In postman see the response header "Cache-Control"