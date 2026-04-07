using Microsoft.Extensions.Primitives;

namespace LcmAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

            var app = builder.Build();

            app.MapGet("/aigerim_10803_gmail_com", (HttpContext context) =>
            {
                var query = context.Request.Query;

                if (!query.TryGetValue("x", out StringValues xVal) ||
                    !query.TryGetValue("y", out StringValues yVal))
                    return "NaN";

                if (!long.TryParse(xVal, out long x) ||
                    !long.TryParse(yVal, out long y) ||
                    x <= 0 || y <= 0)
                    return "NaN";

                long Gcd(long a, long b)
                {
                    while (b != 0)
                    {
                        var t = b;
                        b = a % b;
                        a = t;
                    }
                    return a;
                }

                var gcd = Gcd(x, y);
                var lcm = (x / gcd) * y;

                return lcm.ToString();
            });

            app.Run();
        }
    }
}