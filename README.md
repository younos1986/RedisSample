# installation

* First download redis zip file from https://github.com/MicrosoftArchive/redis/releases
* Extract it into c:\redis
* Open cmd and run -> cd c:\redis
* Then run redis   -> server with
* Then run the project and use it 



in startup file 

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
```
