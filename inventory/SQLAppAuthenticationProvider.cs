using System.Threading.Tasks;
using  ;
using Microsoft.Data.SqlClient;
/// <summary>
/// An implementation of SqlAuthenticationProvider that implements Active Directory Interactive SQL authentication.
/// </summary>
public class SqlAppAuthenticationProvider : SqlAuthenticationProvider
{
    private static readonly AzureServiceTokenProvider _tokenProvider = new AzureServiceTokenProvider();

    /// <summary>
    /// Acquires an access token for SQL using AzureServiceTokenProvider with the given SQL authentication parameters.
    /// </summary>
    /// <param name="parameters">The parameters needed in order to obtain a SQL access token</param>
    /// <returns></returns>
    public override async Task<SqlAuthenticationToken> AcquireTokenAsync(SqlAuthenticationParameters parameters)
    {
        var authResult = await _tokenProvider.GetAuthenticationResultAsync("https://database.windows.net/").ConfigureAwait(false);

        return new SqlAuthenticationToken(authResult.AccessToken, authResult.ExpiresOn);
    }

    /// <summary>
    /// Implements virtual method in SqlAuthenticationProvider. Only Active Directory Interactive Authentication is supported.
    /// </summary>
    /// <param name="authenticationMethod">The SQL authentication method to check whether supported</param>
    /// <returns></returns>
    public override bool IsSupported(SqlAuthenticationMethod authenticationMethod)
    {
        return authenticationMethod == SqlAuthenticationMethod.ActiveDirectoryInteractive;
    }
}