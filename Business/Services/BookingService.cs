using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;

    public async Task<ServiceResponse> CreateBookingAsync(CreateBookingRequest request)
    {
        var bookingEntity = new BookingEntity
        {
            EventId = request.EventId,
            TicketQuantity = request.TicketQuantity,
            BookingOwner = new BookingOwnerEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Address = new BookingAddressEntity
                {
                    StreetName = request.StreetName,
                    PostalCode = request.PostalCode,
                    City = request.City
                }
            }
        };

        var result = await _bookingRepository.AddAsync(bookingEntity);
        return result.Succeeded
            ? new ServiceResponse { Succeeded = true, Message = "Booking created successfully." }
            : new ServiceResponse { Succeeded = false, Error = result.Error };

    }
}
