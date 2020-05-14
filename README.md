# Stho.Auth.AppleId

# Config Section 

```xml
<configuration>
    <configSections>
        <section name="apple" type="Stho.Auth.Apple.Configuration.AppleSection"  />
    </configSections>
    <apple>
        <appleId redirectUri="https://example-app.com/redirect" audience="https://appleid.apple.com">
            <client clientId="com.your.client"  keyId="key_id" issuer="issuer_id" privateKey="pk" />
        </appleId>
    </apple>
</configuration>
```
# Signin procedure

```cs
public ActionResult SignInWithApple()
{
    var signInUri = _appleIdService.GetAppleSignInUri(AuthScope.Email | AuthScope.Name);
    HttpContext.Session["state"] = signInUri.State;
    return Redirect(signInUri.ToString());
}

// Handle callback from Apple API. 
[HttpPost]
public ActionResult AppleCallback(AppleCallbackRequest request)
{
    if (HttpContext.Session["state"] != request.State) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest)
    }

    try
    {
        AppleAccessToken response = _appleIdService.FetchAccessToken(request.Code);
        return View();
    }
    catch (Exception ex)
    {
        // catch errors
    }
}

public class AppleAccessToken
{
    public AppleAccessToken(bool valid)
    {
        IsTokenValid = valid;
    }

    public AppleIdentity Identity { get; set; }
    public AppleAccessTokenResponse ClientResponse { get; set; }
    public bool IsTokenValid { get; }
}
```

# Dependency setup

With Unity framwork
```cs
public static void RegisterTypes(IUnityContainer container)
{
    container.RegisterType<IAppleIdClient, AppleIdClient>();
    container.RegisterType<IAppleIdService, AppleIdService>();
    container.RegisterType<IAppleIdentityTokenReader, AppleIdentityTokenReader>();
    container.RegisterType<IAppleClientSecretGenerator, AppleSecretGenerator>();
    container.RegisterType<IAppleConfigurationProvider, AppleWebConfigurationProvider>();
}
```

or use extension method in `Stho.Auth.UnityExtension.Apple`

```cs
using Stho.Auth.UnityExtension.Apple;

public static void RegisterTypes(IUnityContainer container)
{
    container.AddAppleIdService();
}
```