using BaseServerTest.Contracts.Services.Classifieds;
using BaseServerTest.Data;
using BaseServerTest.Services.Classifieds;
using BaseServerTest.Shared.Domain.Classifieds;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BaseServerTest.Components.Pages.Classifieds
{
    public partial class PostAd
    {
        [SupplyParameterFromForm]
        public ClassifiedAd Ad { get; set; }

        [Inject]
        public IClassifiedAdService ClassifiedAdService { get; set; }
        [Inject]
        public IClassifiedUserService ClassifiedUserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        UserManager<ApplicationUser> UserManager { get; set; }

        ApplicationUser CurrentUser { get; set; }
        ClassifiedUser ClassifiedUser { get; set; }


        private bool IsInitialized = false; // Add this flag


        public bool IsEditing;
        public List<string> Categories = new List<string> { "Electronics", "Furniture", "Vehicles", "Services", "Other" };

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
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            CurrentUser = await UserManager.GetUserAsync(authState.User);
            ClassifiedUser = await ClassifiedUserService.GetUserByIdAsync(CurrentUser?.Id);
            if (CurrentUser != null && ClassifiedUser == null)
            {
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

        protected override void OnInitialized()
        {
            Ad ??= new();
        }

        public async Task SaveAd()
        {
            if (IsEditing)
            {
                await ClassifiedAdService.UpdateAdAsync(Ad);
            }
            else
            {
                Ad.Id = Guid.NewGuid().ToString();
                Ad.DatePosted = DateTime.UtcNow;
                Ad.UserId = CurrentUser.Id;
                Ad.User = ClassifiedUser;
                await ClassifiedAdService.CreateAdAsync(Ad);
            }

            NavigationManager.NavigateTo("/classifieds");
        }
    }
}
