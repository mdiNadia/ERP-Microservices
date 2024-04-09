namespace Common.Infrastructure.Services.SMS
{
    public interface ISmsSender
    {
        //راز پیامک
        Task<bool> SendVertificateCode(string receptor, string sender, string text);
    }
}
