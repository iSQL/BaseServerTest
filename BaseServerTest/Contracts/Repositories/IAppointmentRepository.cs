using BaseServerTest.Shared.Domain;

namespace BaseServerTest.Contracts.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointments();
        Task<Appointment> GetAppointmentById(int id);
    }
}
