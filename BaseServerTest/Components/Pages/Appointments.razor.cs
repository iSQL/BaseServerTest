using BaseServerTest.Contracts.Services;
using BaseServerTest.Shared.Domain;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using System.Globalization;
namespace BaseServerTest.Components.Pages
{
    public partial class Appointments
    {
        public List<Appointment> AppointmentList { get; set; } = default;

        [Inject]
        public IAppointmentDataService? AppointmentDataService { get; set; }

        DxSchedulerDataStorage DataStorage = new DxSchedulerDataStorage()
        {
            //AppointmentsSource = GetAppointments(),
            AppointmentMappings = new DxSchedulerAppointmentMappings()
            {
                Start = "StartDate",
                End = "EndDate",
                Subject = "Caption",
                LabelId = "Label",
                StatusId = "Status"
            }
        };

        protected async override Task OnInitializedAsync()
        {
            DataStorage.AppointmentsSource = (await AppointmentDataService.GetAllAppointments()).ToList();
        }
        public static List<Appointment> GetAppointments()
        {
            DateTime date = DateTime.Today;
            var dataSource = new List<Appointment>() {
                new Appointment {
                    Caption = "Upgrade Personal Computers",
                    StartDate = date + (new TimeSpan(0,  14, 0, 0)),
                    EndDate = date + (new TimeSpan(0, 16, 30, 0)),
                    Label = 1,
                    Status = 1
                },
                new Appointment {
                    Caption = "Install New Router in Dev Room",
                    StartDate = date + (new TimeSpan(2, 11, 30, 0)),
                    EndDate = date + (new TimeSpan(2, 13, 30, 0)),
                    Label = 6,
                    Status = 1
                },
                new Appointment {
                    Caption = "New Brochures",
                    StartDate = date + (new TimeSpan(2, 15, 00, 0)),
                    EndDate = date + (new TimeSpan(2, 16, 45, 0)),
                    Label = 8,
                    Status = 1
                },
                new Appointment {
                    Caption = "Approve Personal Computer Upgrade Plan",
                    StartDate = date + (new TimeSpan(3, 13, 30, 0)),
                    EndDate = date + (new TimeSpan(3, 16, 0, 0)),
                    Label = 1,
                    Status = 1
                },
                new Appointment {
                    Caption = "Customer Workshop",
                    StartDate = date + (new TimeSpan(4,  11, 0, 0)),
                    EndDate = date + (new TimeSpan(4, 12, 0, 0)),
                    AllDay = true,
                    Label = 8,
                    Status = 1
                },
                new Appointment {
                    Caption = "Upgrade Server Hardware",
                    StartDate = date + (new TimeSpan(6, 11, 0, 0)),
                    EndDate = date + (new TimeSpan(6, 13, 30, 0)),
                    Label = 6,
                    Status = 1
                }
            };
        return dataSource;
        }
        private static string ToString(DateTime dateTime)
        {
            return dateTime.ToString(CultureInfo.InvariantCulture);
        }

    }
}
