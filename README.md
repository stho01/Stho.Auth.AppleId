# Stho.Auth.AppleId

# Config Section 

```xml
<configuration>
  <configSections>
    <section name="apple" type="Stho.Auth.Apple.Configuration.AppleSection"  />
  </configSections>

  <apple clientId="com.your.client"
         redirectUri="https://example-app.com/redirect"
         audience="https://appleid.apple.com"
         keyId="your_key_id"
         issuer="your_issuer_id"
         expiresInMinutes="5"
         privateKey="your_pk_code" />
</configuration>
```
# Signin precedure

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