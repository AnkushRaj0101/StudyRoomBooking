using StudyRoomBooking.Core.Services.Interfaces;
using System;

namespace StudyRoomBooking.Core.Services
{
    public class ServiceHandlerFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResponse ProcessService<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            var service = (IServiceHandler<TRequest, TResponse>)_serviceProvider.GetService(typeof(IServiceHandler<TRequest, TResponse>));

            if (service == null)
            {
                throw new NotImplementedException($"No service register for this type : {nameof(TRequest)}");
            }
            return service.ExecuteService(request); //iservice
        }
    }
}
