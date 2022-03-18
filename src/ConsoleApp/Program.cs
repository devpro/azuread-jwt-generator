Console.WriteLine("Hello, World!");

var clientId = args[0];
var tenantId = args[1];
var username = args[2];
var password = args[3];
var scope = args[4];

var app = PublicClientApplicationBuilder.Create(clientId)
    .WithTenantId(tenantId)
    .Build();

var scopes = new string[] { $"api://{clientId}/{scope}" };

try
{
    var result = await app.AcquireTokenByUsernamePassword(scopes, username, new NetworkCredential("", password).SecurePassword)
        .ExecuteAsync();

    Console.WriteLine(result.AccessToken);
    return 0;
}
catch (MsalUiRequiredException exc)
{
    Console.WriteLine($"Error: MsalUiRequiredException {exc.Message}. The application doesn't have sufficient permissions?");
    return -2;
}
catch (MsalServiceException exc) when (exc.Message.Contains("AADSTS70011"))
{
    Console.WriteLine($"Error: MsalServiceException {exc.Message}. Invalid scope?");
    return -2;
}
catch (Exception exc)
{
    Console.WriteLine($"Error: {exc.GetType()} {exc.Message}. Check inner exception");
    Console.WriteLine(exc.StackTrace);
    return -2;
}
