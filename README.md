# Distributed Cache with Redis in ASP.NET Core 2.2

# installation


* install npm packages 
    ```<PackageReference Include="Microsoft.AspNetCore.Session" Version="2.2.0" />```
    ```<PackageReference Include="Microsoft.Extensions.Caching.Redis" Version="2.2.0" />```


* First download redis zip file from https://github.com/MicrosoftArchive/redis/releases
* Extract it into c:\redis
* Open cmd and run -> cd c:\redis
* Then run redis   -> server with
* Then run the project and use it 


In startup file 

```
public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //For Redis
            services.AddSession();
            services.AddDistributedRedisCache(options =>
            {
                options.InstanceName = "Sample";
                options.Configuration = "localhost:6379";
            });

        }
        
         public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        
        
```


# Usage

to set 

```
 public class HomeController : Controller
    {
        private readonly IDistributedCache _distributedCache;
        public HomeController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

   
   public IActionResult Index()
        {
            var distributedCacheEntryOptions = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromSeconds(20)
            };

            _distributedCache.SetString("helloFromRedis", "world" , distributedCacheEntryOptions);
            return View();
        }
        
        ...
   }
```


to get 


```

public IActionResult Privacy()
        {
            var valueFromRedis = _distributedCache.GetString("helloFromRedis");

            return View();
        }
        
```


