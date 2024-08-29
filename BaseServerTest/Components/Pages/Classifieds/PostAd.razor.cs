using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;
using BaseServerTest.State;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Differencing;

namespace BaseServerTest.Components.Pages.Classifieds
{
    public partial class PostAd
    {
        [SupplyParameterFromForm]
        public ClassifiedAd Ad { get; set; }
        [Parameter]
        [SupplyParameterFromQuery]
        public string? IsEditing { get; set; }
        [Parameter]
        public string? Id { get; set; }

        [Inject]
        public IClassifiedAdService ClassifiedAdService { get; set; }
        [Inject]
        public IClassifiedUserService ClassifiedUserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        ApplicationState ApplicationState { get; set; }
        ClassifiedUser ClassifiedUser { get; set; }
        [Inject]
        IHttpContextAccessor HttpContextAccessor { get; set; }

        public List<string> Categories = new List<string> { "KupoProdaja", "Usluge", "Ostalo" };

        //protected override async Task OnInitializedAsync()
        //{
        //    if (!IsInitialized)
        //    {
        //        if (IsEditing)
        //        {
        //            Load the existing ad for editing
        //           Ad = await ClassifiedAdService.GetAdByIdAsync(1);
        //        }
        //        else
        //        {
        //            Initialize a new ad for posting
        //           Ad = new ClassifiedAd();
        //        }

        //        IsInitialized = true; // Mark as initialized
        //    }
        //}

        //ToDo: Check where to create classified user
        protected override async Task OnInitializedAsync()
        {
            var CurrentUser = ApplicationState.CurrentUser;
            ClassifiedUser = await ClassifiedUserService.GetUserByIdAsync(CurrentUser?.Id);
            
            if (IsEditing=="true" && HttpMethods.IsGet(HttpContextAccessor.HttpContext.Request.Method))
            {
                Ad = await ClassifiedAdService.GetAdByIdAsync(Id);
            }
            else
            {
                if (CurrentUser != null && ClassifiedUser == null)
                {
                    //ToDo: add a prompt to ask user to create a classified user
                    await ClassifiedUserService.CreateUserAsync(new ClassifiedUser { UserName = CurrentUser.UserName, Id = CurrentUser.Id, Email = CurrentUser.Email, DateRegistered = DateTime.UtcNow });
                }
                else if (CurrentUser != null && ClassifiedUser != null)
                {
                    // Classified user already exist
                }
                else
                {
                    // Handle the case where the user is not authenticated
                }
            }
        }

        protected override void OnInitialized()
        {
            Ad ??= new();
        }

        public async Task SaveAd()
        {
            if (IsEditing == "true")
            {
                //To Do: Check if there is a better way to preserve Ad ID and user ID
                Ad.Id = Id;
                Ad.UserId = ApplicationState.CurrentUser.Id;
                await ClassifiedAdService.UpdateAdAsync(Ad);
            }
            else
            {
                Ad.Id = Guid.NewGuid().ToString();
                Ad.DatePosted = DateTime.UtcNow;
                Ad.UserId = ApplicationState.CurrentUser.Id; //ToDo: check if transient can be used, singleton is shared across whole app
                Ad.User = ClassifiedUser;
                await ClassifiedAdService.CreateAdAsync(Ad);
            }

            NavigationManager.NavigateTo("/classifieds");
        }
    }
}
