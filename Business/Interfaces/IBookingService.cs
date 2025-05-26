using Business.Models;

namespace Business.Interfaces;

public interface IBookingService
{
    Task<ServiceResponse> CreateBookingAsync(CreateBookingRequest request);
}
