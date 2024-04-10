namespace MCDA_APP.Model.Api
{
    public class AccountInformation
    {
        private readonly string _apiKey;
        private readonly string _userEmail;
        private readonly string _subscription;

        public AccountInformation(string apiKey, string userEmail, string subscription)
        {
            _apiKey = apiKey;
            _userEmail = userEmail;
            _subscription = subscription;
        }

        public string ApiKey { get { return _apiKey; } }

        public string UserEmail { get { return _userEmail; } }

        public string Subscription { get { return _subscription; } }
    }
}