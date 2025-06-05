
//using Consul;

//namespace Product.Services.ProductAPI
//{
//    public class ConsulServiceRegistration : IHostedService
//    {

//        private readonly IConsulClient _consulClient;
//        private readonly IHostApplicationLifetime _Lifetime;

//        private readonly ILogger<ConsulServiceRegistration> _logger;

//        private string _registrationId;
//        public ConsulServiceRegistration(IHostApplicationLifetime Lifetime, IConsulClient consulClient,ILogger<ConsulServiceRegistration> logger)
//        {
//            _Lifetime =Lifetime;
//            _consulClient = consulClient;
//            _logger = logger;
//        }
//        public Task StartAsync(CancellationToken cancellationToken)
//        {

//            try
//            {
//                _registrationId = $"Products-Service-{Guid.NewGuid()}";

//                var address = "productapi";
//                var port = 80;

//                _logger.LogInformation("Registering with Consul at address: {address}, port: {port}, id: {id}", address, port, _registrationId);

//                var registration = new AgentServiceRegistration()
//                {
//                    ID = _registrationId,
//                    Name = "Products-Service",
//                    Address = address,
//                    Port = port,
//                    Tags = new[] { "Products" }
//                };


//                const int maxRetries = 10;
//                for (int i = 0; i < maxRetries; i++)
//                {
//                    try
//                    {
//                        _consulClient.Agent.ServiceRegister(registration).Wait();
//                        break; // Success
//                    }
//                    catch (Exception ex)
//                    {
//                        if (i == maxRetries - 1)
//                            throw; // Give up after max retries
//                        Thread.Sleep(2000); // Wait 2 seconds before retrying
//                    }
//                }


//                _Lifetime.ApplicationStopping.Register(() =>
//                {
//                    _consulClient.Agent.ServiceDeregister(_registrationId).Wait();
//                });

//                _logger.LogInformation("Registering with Consul at address: {address}, port: {port}, id: {id}", address, port, _registrationId);

//            }
//            catch (Exception e)
//            {
//                _logger.LogError(e, "Error registering with Consul");
//            }
//                return Task.CompletedTask;
           
//        }

//        public Task StopAsync(CancellationToken cancellationToken)=>Task.CompletedTask;
//    }
//}
