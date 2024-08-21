using BaseServerTest.Contracts.Repositories;
using BaseServerTest.Data;
using BaseServerTest.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace BaseServerTest.Repositories
{
    public class AppointmentRepository : IAppointmentRepository, IDisposable
    {
        private readonly ApplicationDbContext _appDbContext;

        public AppointmentRepository(IDbContextFactory<ApplicationDbContext> DbFactory)
        {
            _appDbContext = DbFactory.CreateDbContext();
        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _appDbContext.Appointments.ToListAsync();
        }

        public Task<Appointment> GetAppointmentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
