using BaseServerTest.Contracts.Repositories;
using BaseServerTest.Contracts.Services;
using BaseServerTest.Shared.Domain;

namespace BaseServerTest.Services
{
    public class AppointmentDataService : IAppointmentDataService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentDataService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _appointmentRepository.GetAllAppointments();
        }

        public Task<Appointment> GetAppointmentDetails(string id)
        {
            throw new NotImplementedException();
        }
    }
}
