﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Capstone
{
    public class Program
    {
        private const string apiUrl = "https://localhost:44315/";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

