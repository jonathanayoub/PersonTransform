using PersonTransform.Core;

namespace PersonTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            var transform = Bootstrap.Configure().Resolve<IPersonTransform>();
            transform.Run();
        }
    }
}
