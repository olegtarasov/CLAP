using System;
using System.Diagnostics;
using System.Threading.Tasks;
#if !FW2
using System.Linq;
#endif

namespace CLAP
{
    /// <summary>
    /// A command-line arguments parser
    /// </summary>
    public partial class Parser : MultiParser
    {
        /// <summary>
        /// Creates a parser based on the specified types
        /// </summary>
        /// <param name="types"></param>
        public Parser(params Type[] types)
            : base(types)
        {
        }

        /// <summary>
        /// Executes a parser of instance-verbs based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="targets">The instances of the verb classes</param>
        public static Task<int> RunAsync(string[] args, params object[] targets)
        {
            Debug.Assert(targets.Any());
            Debug.Assert(targets.All(t => t != null));

            var p = new Parser(targets.Select(t => t.GetType()).ToArray());

            return ((MultiParser)p).RunTargetsAsync(args, targets);
        }

        public static Task<int> RunAsync(string[] args, TargetResolver targetResolver)
        {
            Debug.Assert(targetResolver != null);

            var p = new Parser(targetResolver.RegisteredTypes);

            return p.RunTargetsAsync(args, targetResolver);
        }

        /// <summary>
        /// Executes a generic static parser of a specified type
        /// </summary>
        /// <typeparam name="T">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        public static Task<int> RunAsync<T>(string[] args)
        { return new Parser<T>().RunStaticAsync(args); }

        /// <summary>
        /// Executes a generic parser of a specified type
        /// </summary>
        /// <typeparam name="T">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        /// <param name="t">An instance of the verb class</param>
        public static Task<int> RunAsync<T>(string[] args, T t)
        { return new Parser<T>().RunTargetsAsync(args, t); }

        /// <summary>
        /// Executes a generic static parser of some specified types
        /// </summary>
        /// <param name="args">The user arguments</param>
        public static Task<int> RunAsync<T1, T2>(string[] args)
        { return new Parser<T1, T2>().RunStaticAsync(args); }

        /// <summary>
        /// Executes a generic parser of some specified types
        /// </summary>
        /// <typeparam name="T1">The type of the parser</typeparam>
        /// <typeparam name="T2">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        public static Task<int> RunAsync<T1, T2>(string[] args, T1 t1, T2 t2)
        { return new Parser<T1, T2>().RunTargetsAsync(args, t1, t2); }

        /// <summary>
        /// Executes a generic static parser of some specified types
        /// </summary>
        /// <param name="args">The user arguments</param>
        public static Task<int> RunAsync<T1, T2, T3>(string[] args)
        { return new Parser<T1, T2, T3>().RunStaticAsync(args); }

        /// <summary>
        /// Executes a generic parser of some specified types
        /// </summary>
        /// <typeparam name="T1">The type of the parser</typeparam>
        /// <typeparam name="T2">The type of the parser</typeparam>
        /// <typeparam name="T3">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        public static Task<int> RunAsync<T1, T2, T3>(string[] args, T1 t1, T2 t2, T3 t3)
        { return new Parser<T1, T2, T3>().RunTargetsAsync(args, t1, t2, t3); }

        /// <summary>
        /// Executes a generic static parser of some specified types
        /// </summary>
        /// <param name="args">The user arguments</param>
        public static Task<int> RunAsync<T1, T2, T3, T4>(string[] args)
        { return new Parser<T1, T2, T3, T4>().RunStaticAsync(args); }

        /// <summary>
        /// Executes a generic parser of some specified types
        /// </summary>
        /// <typeparam name="T1">The type of the parser</typeparam>
        /// <typeparam name="T2">The type of the parser</typeparam>
        /// <typeparam name="T3">The type of the parser</typeparam>
        /// <typeparam name="T4">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        public static Task<int> RunAsync<T1, T2, T3, T4>(string[] args, T1 t1, T2 t2, T3 t3, T4 t4)
        { return new Parser<T1, T2, T3, T4>().RunTargetsAsync(args, t1, t2, t3, t4); }

        /// <summary>
        /// Executes a generic static parser of some specified types
        /// </summary>
        /// <param name="args">The user arguments</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5>(string[] args)
        { return new Parser<T1, T2, T3, T4, T5>().RunStaticAsync(args); }

        /// <summary>
        /// Executes a generic parser of some specified types
        /// </summary>
        /// <typeparam name="T1">The type of the parser</typeparam>
        /// <typeparam name="T2">The type of the parser</typeparam>
        /// <typeparam name="T3">The type of the parser</typeparam>
        /// <typeparam name="T4">The type of the parser</typeparam>
        /// <typeparam name="T5">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5>(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        { return new Parser<T1, T2, T3, T4, T5>().RunTargetsAsync(args, t1, t2, t3, t4, t5); }

        /// <summary>
        /// Executes a generic static parser of some specified types
        /// </summary>
        /// <param name="args">The user arguments</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5, T6>(string[] args)
        { return new Parser<T1, T2, T3, T4, T5, T6>().RunStaticAsync(args); }

        /// <summary>
        /// Executes a generic parser of some specified types
        /// </summary>
        /// <typeparam name="T1">The type of the parser</typeparam>
        /// <typeparam name="T2">The type of the parser</typeparam>
        /// <typeparam name="T3">The type of the parser</typeparam>
        /// <typeparam name="T4">The type of the parser</typeparam>
        /// <typeparam name="T5">The type of the parser</typeparam>
        /// <typeparam name="T6">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        /// <param name="t6">An instance of the verb class</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5, T6>(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        { return new Parser<T1, T2, T3, T4, T5, T6>().RunTargetsAsync(args, t1, t2, t3, t4, t5, t6); }

        /// <summary>
        /// Executes a generic static parser of some specified types
        /// </summary>
        /// <param name="args">The user arguments</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5, T6, T7>(string[] args)
        { return new Parser<T1, T2, T3, T4, T5, T6, T7>().RunStaticAsync(args); }

        /// <summary>
        /// Executes a generic parser of some specified types
        /// </summary>
        /// <typeparam name="T1">The type of the parser</typeparam>
        /// <typeparam name="T2">The type of the parser</typeparam>
        /// <typeparam name="T3">The type of the parser</typeparam>
        /// <typeparam name="T4">The type of the parser</typeparam>
        /// <typeparam name="T5">The type of the parser</typeparam>
        /// <typeparam name="T6">The type of the parser</typeparam>
        /// <typeparam name="T7">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        /// <param name="t6">An instance of the verb class</param>
        /// <param name="t7">An instance of the verb class</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5, T6, T7>(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        { return new Parser<T1, T2, T3, T4, T5, T6, T7>().RunTargetsAsync(args, t1, t2, t3, t4, t5, t6, t7); }

        /// <summary>
        /// Executes a generic static parser of some specified types
        /// </summary>
        /// <param name="args">The user arguments</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5, T6, T7, T8>(string[] args)
        { return new Parser<T1, T2, T3, T4, T5, T6, T7, T8>().RunStaticAsync(args); }

        /// <summary>
        /// Executes a generic parser of some specified types
        /// </summary>
        /// <typeparam name="T1">The type of the parser</typeparam>
        /// <typeparam name="T2">The type of the parser</typeparam>
        /// <typeparam name="T3">The type of the parser</typeparam>
        /// <typeparam name="T4">The type of the parser</typeparam>
        /// <typeparam name="T5">The type of the parser</typeparam>
        /// <typeparam name="T6">The type of the parser</typeparam>
        /// <typeparam name="T7">The type of the parser</typeparam>
        /// <typeparam name="T8">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        /// <param name="t6">An instance of the verb class</param>
        /// <param name="t7">An instance of the verb class</param>
        /// <param name="t8">An instance of the verb class</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5, T6, T7, T8>(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        { return new Parser<T1, T2, T3, T4, T5, T6, T7, T8>().RunTargetsAsync(args, t1, t2, t3, t4, t5, t6, t7, t8); }

        /// <summary>
        /// Executes a generic static parser of some specified types
        /// </summary>
        /// <param name="args">The user arguments</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string[] args)
        { return new Parser<T1, T2, T3, T4, T5, T6, T7, T8, T9>().RunStaticAsync(args); }

        /// <summary>
        /// Executes a generic parser of some specified types
        /// </summary>
        /// <typeparam name="T1">The type of the parser</typeparam>
        /// <typeparam name="T2">The type of the parser</typeparam>
        /// <typeparam name="T3">The type of the parser</typeparam>
        /// <typeparam name="T4">The type of the parser</typeparam>
        /// <typeparam name="T5">The type of the parser</typeparam>
        /// <typeparam name="T6">The type of the parser</typeparam>
        /// <typeparam name="T7">The type of the parser</typeparam>
        /// <typeparam name="T8">The type of the parser</typeparam>
        /// <typeparam name="T9">The type of the parser</typeparam>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        /// <param name="t6">An instance of the verb class</param>
        /// <param name="t7">An instance of the verb class</param>
        /// <param name="t8">An instance of the verb class</param>
        /// <param name="t9">An instance of the verb class</param>
        public static Task<int> RunAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        { return new Parser<T1, T2, T3, T4, T5, T6, T7, T8, T9>().RunTargetsAsync(args, t1, t2, t3, t4, t5, t6, t7, t8, t9); }
    }

    /// <summary>
    /// A command-line arguments parser of the specified type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Parser<T> : MultiParser
    {
        /// <summary>
        /// Executes the parser based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="t">An instance of the verb class</param>
        public void Run(string[] args, T t)
        {
            base.RunTargetsAsync(args, t);
        }
    }

    public class Parser<T1, T2> : MultiParser
    {
        /// <summary>
        /// Executes the parser based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        public void Run(string[] args, T1 t1, T2 t2)
        {
            base.RunTargetsAsync(args, t1, t2);
        }
    }

    public class Parser<T1, T2, T3> : MultiParser
    {
        /// <summary>
        /// Executes the parser based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        public void Run(string[] args, T1 t1, T2 t2, T3 t3)
        {
            base.RunTargetsAsync(args, t1, t2, t3);
        }
    }

    public class Parser<T1, T2, T3, T4> : MultiParser
    {
        /// <summary>
        /// Executes the parser based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        public void Run(string[] args, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            base.RunTargetsAsync(args, t1, t2, t3, t4);
        }
    }

    public class Parser<T1, T2, T3, T4, T5> : MultiParser
    {
        /// <summary>
        /// Executes the parser based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        public void Run(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            base.RunTargetsAsync(args, t1, t2, t3, t4, t5);
        }
    }

    public class Parser<T1, T2, T3, T4, T5, T6> : MultiParser
    {
        /// <summary>
        /// Executes the parser based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        /// <param name="t6">An instance of the verb class</param>
        public void Run(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            base.RunTargetsAsync(args, t1, t2, t3, t4, t5, t6);
        }
    }

    public class Parser<T1, T2, T3, T4, T5, T6, T7> : MultiParser
    {
        /// <summary>
        /// Executes the parser based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        /// <param name="t6">An instance of the verb class</param>
        /// <param name="t7">An instance of the verb class</param>
        public void Run(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            base.RunTargetsAsync(args, t1, t2, t3, t4, t5, t6, t7);
        }
    }

    public class Parser<T1, T2, T3, T4, T5, T6, T7, T8> : MultiParser
    {
        /// <summary>
        /// Executes the parser based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        /// <param name="t6">An instance of the verb class</param>
        /// <param name="t7">An instance of the verb class</param>
        /// <param name="t8">An instance of the verb class</param>
        public void Run(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8)
        {
            base.RunTargetsAsync(args, t1, t2, t3, t4, t5, t6, t7, t8);
        }
    }

    public class Parser<T1, T2, T3, T4, T5, T6, T7, T8, T9> : MultiParser
    {
        /// <summary>
        /// Executes the parser based on the specified targets
        /// </summary>
        /// <param name="args">The user arguments</param>
        /// <param name="t1">An instance of the verb class</param>
        /// <param name="t2">An instance of the verb class</param>
        /// <param name="t3">An instance of the verb class</param>
        /// <param name="t4">An instance of the verb class</param>
        /// <param name="t5">An instance of the verb class</param>
        /// <param name="t6">An instance of the verb class</param>
        /// <param name="t7">An instance of the verb class</param>
        /// <param name="t8">An instance of the verb class</param>
        /// <param name="t9">An instance of the verb class</param>
        public void Run(string[] args, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
        {
            base.RunTargetsAsync(args, t1, t2, t3, t4, t5, t6, t7, t8, t9);
        }
    }
}