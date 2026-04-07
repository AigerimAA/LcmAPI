using Microsoft.Extensions.Primitives;
using System.Numerics;

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

            app.MapGet("/aigerim_10803_gmail_com", (string? x, string? y) =>
            {
                if (!BigInteger.TryParse(x, out BigInteger b1) || 
                    !BigInteger.TryParse(y, out BigInteger b2) || 
                    b1 < 0 || b2 < 0)
                {
                    return Results.Text("NaN", "text/plain");
                }
            
                if (b1 == 0 || b2 == 0) return Results.Text("0", "text/plain");
            
                BigInteger gcd = BigInteger.GreatestCommonDivisor(b1, b2);
                BigInteger lcm = BigInteger.Abs(b1 * b2) / gcd;
            
                return Results.Text(lcm.ToString(), "text/plain");
            });

            app.Run();
        }
    }
}
