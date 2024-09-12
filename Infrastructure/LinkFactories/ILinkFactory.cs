using Microsoft.AspNetCore.Http;

namespace AnytourApi.Infrastructure.LinkFactories;

public interface ILinkFactory
{
    public string GetImageUrl(HttpRequest httpRequest, string guid);
}
