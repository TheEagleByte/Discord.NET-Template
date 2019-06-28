using System.Threading.Tasks;

namespace Template
{
    internal class Program
    {
        public static Task Main(string[] args)
            => Startup.RunAsync(args);
    }
}
