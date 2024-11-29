namespace PLA.Api.ApplicationBusinessRules.Helpers;

internal static class ExtencionMethods
{
    internal static DateTime CleanDateTime(this DateTime dateTime, bool isEnd)
    {
        if (isEnd)
            dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0).AddDays(1);
        else
            dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        return dateTime;
    }

    internal static bool IsNullOrEmpty(this string text)
        => string.IsNullOrEmpty(text);

    /// <summary>
    /// Validar si un elemento es null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="elemento"></param>
    /// <returns></returns>
    public static bool IsNull<T>(this T elemento) =>
        elemento == null;

    /// <summary>
    /// Validar si un elemento no es null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="elemento"></param>
    /// <returns></returns>
    public static bool IsNotNull<T>(this T elemento) =>
        elemento != null;

    public static bool IsNullOrEmpty<T>(this List<T> elemento) =>
        elemento == null || elemento.Count == 0;

    public static int GetValueClaim(this ClaimsPrincipal claims, string nameClaim)
    {
        var usuarioClaimId = claims.Claims.FirstOrDefault(f => f.Type == nameClaim).Value;
        return int.Parse(Crypto.DecryptStringAES(usuarioClaimId));
    }
}
