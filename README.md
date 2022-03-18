# Azure AD JWT Generator

Command line tool to generate authentication tokens with Azure Active Directory.

## How to use the tool

```bash
aadtokengen <client_id> <tenant_id> <username> <userpassword> <scope>
```

## How to set up an application in Azure

* In [Azure Portal](https://portal.azure.com/), in "Azure Active Directory > Application registrations", select "New registration"
* Once created, update the application
  * "Manifest": manually edit the file (`accessTokenAcceptedVersion` and `allowPublicClient` are null by default)

  ```json
  {
    "accessTokenAcceptedVersion": 2,
    "allowPublicClient": true,
  }
  ```

  * "Api permissions": do "Grant admin consent for Default Directory" (Microsoft Graph > User.Read has been added by default)
  * "Expose an API": set the application ID URI ("api://<client_id>" is the default and correct choice)
  * "Expose an API": add a scope (for example "access_as_user", "Admins and users" can consent)

## How to debug in Visual Studio

* Create the `src/ConsoleApp/Properties/launchSettings.json` file

```
{
  "profiles": {
    "ConsoleApp": {
      "commandName": "Project",
      "commandLineArgs": "<client_id> <tenant_id> <username> <userpassword> <scope>"
    }
  }
}
```
