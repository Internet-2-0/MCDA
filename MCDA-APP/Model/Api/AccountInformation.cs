namespace MCDA_APP.Model.Api
{
    public class AccountInformation
    {
        public string? ApiKey;
        public string? UserEmail;
        public string? Subscription;
        public string? Message;
        public bool Success;

        public void ResetValues()
        {
            ApiKey = "";
            UserEmail = "";
            Subscription = "";
            Message = "";
            Success = false;
        }
    }
}