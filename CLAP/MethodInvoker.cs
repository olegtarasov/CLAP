using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace CLAP
{
    /// <summary>
    /// A helper for method invoking to allow mocking for tests
    /// </summary>
    public static class MethodInvoker
    {
        public static IMethodInvoker Invoker { get; set; }

        static MethodInvoker()
        {
            Invoker = new DefaultMethodInvoker();
        }

        public static void Invoke(MethodInfo method, object obj, object[] parameters)
        {
            Debug.Assert(method != null);

            Invoker.Invoke(method, obj, parameters);
        }

        public static async Task InvokeAsync(MethodInfo method, object obj, object[] parameters)
        {
            Debug.Assert(method != null);

            await Invoker.InvokeAsync(method, obj, parameters);
        }

        private class DefaultMethodInvoker : IMethodInvoker
        {
            public void Invoke(MethodInfo method, object obj, object[] parameters)
            {
                method.Invoke(obj, parameters);
            }

            public async Task InvokeAsync(MethodInfo method, object obj, object[] parameters)
            {
                if (method.IsAwaitable())
                {
                    await (Task)method.Invoke(obj, parameters);
                }
                else
                {
                    await Task.Run(() => method.Invoke(obj, parameters));
                }
            }
        }
    }

    public interface IMethodInvoker
    {
        Task InvokeAsync(MethodInfo method, object obj, object[] parameters);
    }
}