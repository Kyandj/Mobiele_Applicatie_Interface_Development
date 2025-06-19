using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Refit;

public interface ILocationWebhookApi
{
    [Post("")]
    Task SendLocationAsync([Body] object payload);
}
