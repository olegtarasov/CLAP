using System.Reflection;
using System.Threading.Tasks;

namespace CLAP
{
    public static class ReflectionHelper
    {
        public static bool IsAwaitable(this MethodInfo method)
        {
            return typeof(Task).IsAssignableFrom(method.ReturnType);
        }
    }
}