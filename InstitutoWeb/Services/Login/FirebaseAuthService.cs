using InstitutoServices.Models.Login;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace InstitutoWeb.Services.Login
{
    public class FirebaseAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string UserIdKey = "firebaseUserId";
        public event Action OnChangeLogin;

        public FirebaseAuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<FirebaseUser> SignInWithEmailPassword(string email, string password, bool remenberPassword)
        {
            var user = await _jsRuntime.InvokeAsync<FirebaseUser>("firebaseAuth.signInWithEmailPassword", email, password);
            if (user.EmailVerified == false)
            {
                return user;
            }
            if (user != null)
            {
                
                if (remenberPassword)
                {
                    await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, user);
                }
                else
                {
                    await _jsRuntime.InvokeVoidAsync("sesionStorageHelper.setItem", UserIdKey, user);
                }
                OnChangeLogin?.Invoke();
            }
            return user;
        }

        public async Task<FirebaseUser> SignInWithGoogle()
        {
            var user = await _jsRuntime.InvokeAsync<FirebaseUser>("firebaseAuth.SignInWithGoogle");

            if (user != null)
            {

                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, user);
                OnChangeLogin?.Invoke();
            }
            return user;
        }

        public async Task SignOut()
        {
            await _jsRuntime.InvokeVoidAsync("firebaseAuth.signOut");
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", UserIdKey);
            await _jsRuntime.InvokeVoidAsync("sesionStorageHelper.removeItem", UserIdKey);
            OnChangeLogin?.Invoke();
        }

        public async Task<string> createUserWithEmailAndPassword(string email, string password)
        {
            var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.createUserWithEmailAndPassword", email, password);
            return userId;
        }
            public async Task<string> GetUserIdInLocalStorage()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", UserIdKey);
        }
        private async Task<string> GetUserIdInSesionStorage()
        {
            return await _jsRuntime.InvokeAsync<string>("sesionStorageHelper.getItem", UserIdKey);
        }
        public async Task<bool> IsUserAuthenticated()
        {
            var userId = await GetUserIdInLocalStorage();
            if (string.IsNullOrEmpty(userId))
            {
                userId = await GetUserIdInSesionStorage();
            }

            return !string.IsNullOrEmpty(userId);
        }

        
    }
}
