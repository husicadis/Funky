using System;

namespace Funky
{
    public static class FuncExtensions
    {
        /// <summary>
        /// Memoizes an encapsulated method that has 1 parameter and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T">The type of the parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T, TResult> Memoize<T, TResult>(
            this Func<T, TResult> func,
            bool isExpirable = false)
        {
            IMemoizeThings<T, TResult> memoizer;
            if (isExpirable)
            {
                memoizer = new ExpirableMemoizer<T, TResult>(func);
            }
            else
            {
                memoizer = new Memoizer<T, TResult>(func);
            }

            return argument => memoizer.GetOrInvoke(argument);
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 2 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, TResult> Memoize<T1, T2, TResult>(
            this Func<T1, T2, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>() };
            var tupled = CastByExample(t => func(t.a, t.b), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b) => memoized(new { a, b });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 3 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, TResult> Memoize<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c) => memoized(new { a, b, c });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 4 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, TResult> Memoize<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d) => memoized(new { a, b, c, d });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 5 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, TResult> Memoize<T1, T2, T3, T4, T5, TResult>(
            this Func<T1, T2, T3, T4, T5, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e) => memoized(new { a, b, c, d, e });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 6 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, TResult> Memoize<T1, T2, T3, T4, T5, T6, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f) => memoized(new { a, b, c, d, e, f });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 7 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g) => memoized(new { a, b, c, d, e, f, g });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 8 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>(), h = D<T8>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g, t.h), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g, h) => memoized(new { a, b, c, d, e, f, g, h });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 9 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>(), h = D<T8>(), i = D<T9>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g, t.h, t.i), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g, h, i) => memoized(new { a, b, c, d, e, f, g, h, i });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 10 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>(), h = D<T8>(), i = D<T9>(), j = D<T10>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g, t.h, t.i, t.j), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g, h, i, j) => memoized(new { a, b, c, d, e, f, g, h, i, j });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 11 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T11">The type of the elevenh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>(), h = D<T8>(), i = D<T9>(), j = D<T10>(), k = D<T11>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g, t.h, t.i, t.j, t.k), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g, h, i, j, k) => memoized(new { a, b, c, d, e, f, g, h, i, j, k });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 12 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T11">The type of the elevenh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>(), h = D<T8>(), i = D<T9>(), j = D<T10>(), k = D<T11>(), l = D<T12>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g, t.h, t.i, t.j, t.k, t.l), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g, h, i, j, k, l) => memoized(new { a, b, c, d, e, f, g, h, i, j, k, l });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 13 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T11">The type of the elevenh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>(), h = D<T8>(), i = D<T9>(), j = D<T10>(), k = D<T11>(), l = D<T12>(), m = D<T13>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g, t.h, t.i, t.j, t.k, t.l, t.m), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g, h, i, j, k, l, m) => memoized(new { a, b, c, d, e, f, g, h, i, j, k, l, m });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 14 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T11">The type of the elevenh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>(), h = D<T8>(), i = D<T9>(), j = D<T10>(), k = D<T11>(), l = D<T12>(), m = D<T13>(), n = D<T14>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g, t.h, t.i, t.j, t.k, t.l, t.m, t.n), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g, h, i, j, k, l, m, n) => memoized(new { a, b, c, d, e, f, g, h, i, j, k, l, m, n });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 15 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T11">The type of the elevenh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>(), h = D<T8>(), i = D<T9>(), j = D<T10>(), k = D<T11>(), l = D<T12>(), m = D<T13>(), n = D<T14>(), o = D<T15>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g, t.h, t.i, t.j, t.k, t.l, t.m, t.n, t.o), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o) => memoized(new { a, b, c, d, e, f, g, h, i, j, k, l, m, n, o });
        }

        /// <summary>
        /// Memoizes an encapsulated method that has 16 parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T2">The type of the second parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T3">The type of the third parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T4">The type of the fourth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T5">The type of the fifth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T6">The type of the sixth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T7">The type of the seventh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T8">The type of the eighth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T9">The type of the ninth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T10">The type of the tenth parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T11">The type of the elevenh parameter of the encapsulated method that this delegate will memoize</typeparam>
        /// <typeparam name="T12">The type of the twelfth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T13">The type of the thirteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T14">The type of the fourteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T15">The type of the fifteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="T16">The type of the sixteenth parameter of the encapsulated method that this delegate will memoize.</typeparam>
        /// <typeparam name="TResult">The type of the retun value of the encapsulated method that this delegate will memoize.</typeparam>
        /// <param name="func">The encapsulated method that this delegate will memoize.</param>
        /// <param name="isExpirable">A value that specifies whether the garbage collector can collect the memoized values.</param>
        /// <returns>A memoized version of the encapsulated method represented by the <paramref name="func"/> parameter.</returns>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func,
            bool isExpirable = false)
        {
            var example = new { a = D<T1>(), b = D<T2>(), c = D<T3>(), d = D<T4>(), e = D<T5>(), f = D<T6>(), g = D<T7>(), h = D<T8>(), i = D<T9>(), j = D<T10>(), k = D<T11>(), l = D<T12>(), m = D<T13>(), n = D<T14>(), o = D<T15>(), p = D<T16>() };
            var tupled = CastByExample(t => func(t.a, t.b, t.c, t.d, t.e, t.f, t.g, t.h, t.i, t.j, t.k, t.l, t.m, t.n, t.o, t.p), example);
            var memoized = tupled.Memoize(isExpirable);
            return (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => memoized(new { a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p });
        }

        // ReSharper disable once UnusedParameter.Local
        private static Func<TArg, TResult> CastByExample<TArg, TResult>(this Func<TArg, TResult> function, TArg example)
        {
            return function;
        }

        private static T D<T>()
        {
            return default(T);
        }
    }
}