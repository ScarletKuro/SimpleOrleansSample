using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Orleans;
using Microsoft.Extensions.Logging;
using SimpleOrleansSample.Interfaces;

namespace SimpleOrleansSample.Grains
{
    public class DemoGrain : Grain, IDemoGrain
    {
        private readonly ILogger<DemoGrain> _logger;

        public DemoGrain(ILogger<DemoGrain> logger)
        {
            _logger = logger;
        }

        public Task<int> GetRandomNumber()
        {
            using RNGCryptoServiceProvider rng = new();
            byte[] randomNumber = new byte[4];
            rng.GetBytes(randomNumber);
            int value = BitConverter.ToInt32(randomNumber, 0);

            return Task.FromResult(value);
        }

        public override Task OnActivateAsync()
        {
            _logger.LogInformation($"GRAIN {nameof(DemoGrain)} is activated with key {this.GetPrimaryKeyString()}.");

            return base.OnActivateAsync();
        }
    }
}
