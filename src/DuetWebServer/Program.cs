﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;

namespace DuetWebServer
{
    /// <summary>
    /// Main class of the ASP.NET Core endpoint
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Default path to the configuration file
        /// </summary>
        public const string DefaultConfigFile = "/opt/dsf/conf/http.json";
        
        /// <summary>
        /// Global cancel source for program termination
        /// </summary>
        public static readonly CancellationTokenSource CancelSource = new CancellationTokenSource();

        /// <summary>
        /// Called when the application is launched
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) => CancelSource.Cancel();
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a new WebHost instance
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        /// <returns>Web host builder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile(DefaultConfigFile, false, true);
                    config.AddCommandLine(args);
                })
                .UseStartup<Startup>();
    }
}
