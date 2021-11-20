using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;

namespace SimpleOrleansSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseOrleans(siloBuilder =>
                {
                    siloBuilder.UseLocalhostClustering()
                        .Configure<HostOptions>(options =>
                        {
                            options.ShutdownTimeout = TimeSpan.FromMinutes(1);
                        })
                        .Configure<ClusterOptions>(options =>
                        {
                            options.ClusterId = "demo-gateway";
                            options.ServiceId = "demo-gateway";
                        })
                        .Configure<EndpointOptions>(options =>
                        {
                            options.AdvertisedIPAddress = IPAddress.Loopback;
                        })
                        .ConfigureApplicationParts(parts =>
                        {
                            parts.AddFromApplicationBaseDirectory();
                        });
                });
    }
}
