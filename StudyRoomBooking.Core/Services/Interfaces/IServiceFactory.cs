namespace StudyRoomBooking.Core.Services.Interfaces
{
    public interface IServiceFactory
    {
        TResponse ProcessService<TRequest, TResponse>(TRequest request) 
             where TRequest : class
             where TResponse : class;
    }
}
