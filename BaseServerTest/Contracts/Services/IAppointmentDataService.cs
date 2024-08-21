using BaseServerTest.Shared.Domain;

namespace BaseServerTest.Contracts.Services
{
    public interface IAppointmentDataService
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentDetails(string id);
    }
}
