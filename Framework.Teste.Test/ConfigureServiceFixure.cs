using System;
using System.Net.Http;
using Framework.Teste.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Teste.Test
{
    public class ConfigureServiceFixure
    {
        public IServiceProvider Services;

        public ConfigureServiceFixure() => Register();

        private void Register()
        {
            var builder = new WebHostBuilder();
            builder.UseStartup<Startup>();

            var server = new TestServer(builder);
            Services = server.Host.Services;
        }
    }
}