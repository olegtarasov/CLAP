using System;
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
        
        public static Task InvokeAsync(MethodInfo method, object obj, object[] parameters)
        {
            Debug.Assert(method != null);

            return Invoker.InvokeAsync(method, obj, parameters);
        }

        private class DefaultMethodInvoker : IMethodInvoker
        {
            void IMethodInvoker.Invoke(MethodInfo method, object obj, object[] parameters)
            {
                method.Invoke(obj, parameters);
            }

            Task IMethodInvoker.InvokeAsync(MethodInfo method, object obj, object[] parameters)
            {
                if (!IsAwaitable(method))
                {
                    method.Invoke(obj, parameters);
                    return Task.CompletedTask;
                }

                return (Task)method.Invoke(obj, parameters);
            }

            private static bool IsAwaitable(MethodInfo method)
            {
                return typeof(Task).IsAssignableFrom(method.ReturnType);
            }
        }
    }

    public interface IMethodInvoker
    {
        void Invoke(MethodInfo method, object obj, object[] parameters);
        Task InvokeAsync(MethodInfo method, object obj, object[] parameters);
    }
}