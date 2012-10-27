using System;
using System.Diagnostics;

using URFU.ASOAD.Core;

namespace URFU.ASOAD.Tests
{
    /// <summary>
    /// Утилиты для тестов
    /// </summary>
    public static class TestUtils
    {
        /// <summary>
        /// Залогировать время выполнения переданной операции
        /// </summary>
        /// <param name="action">операция</param>
        public static void LogTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Debug.WriteLine("Method {0} ExecuteTime = {1} ms", ObjectUtils.CallerMethodName(), stopwatch.ElapsedMilliseconds);
        }
    }
}
