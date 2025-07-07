using Refit;

public interface ILocationWebhookApi
{
    [Post("")]
    Task SendLocationAsync([Body] object payload);
}
