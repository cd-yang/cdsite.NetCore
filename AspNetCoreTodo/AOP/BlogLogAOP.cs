using Blog.Core.Common.LogHelper;
using Castle.DynamicProxy;
using Newtonsoft.Json;
using StackExchange.Profiling;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AspNetCoreTodo.AOP
{
    public class BlogLogAOP : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var dataIntercept = $"{DateTime.Now:yyyyMMddHHmmss} " +
                                $"当前执行方法： {invocation.Method.Name} " +
                                $"参数：{string.Join(", ", invocation.Arguments.Select(async => (async ?? "").ToString()).ToArray())} " +
                                $"\r\n";
            try
            {
                //MiniProfiler.Current.Step($"执行 Service 方法: {invocation.Method.Name} () ->");
                invocation.Proceed();

                
                //if (IsAsyncMethod(invocation.Method)) // 异步获取异常，先执行
                //{
                //    if (invocation.Method.ReturnType == typeof(Task))
                //    {
                //        invocation.ReturnValue = InternalAsyncHelper.AwaitTaskWithPostActionAndFinally(
                //            (Task)invocation.ReturnValue,
                //            async () => await SuccessAction(invocation, dataIntercept),
                //            ex =>
                //            {
                //                LogEx(ex, dataIntercept);
                //            });
                //    }
                //    else //Task<TResult>
                //    {
                //        Console.WriteLine("Intercept: 4");
                //        invocation.ReturnValue = InternalAsyncHelper.CallAwaitTaskWithPostActionAndFinallyAndGetResult(
                //            invocation.Method.ReturnType.GenericTypeArguments[0],
                //            invocation.ReturnValue,
                //            async () => await SuccessAction(invocation, dataIntercept),/*成功时执行*/
                //            ex =>
                //            {
                //                LogEx(ex, dataIntercept);
                //            });
                //    }
                //}
                //else // 同步
                {
                    dataIntercept += ($"【执行完成结果】：{invocation.ReturnValue}");
                    Parallel.For(0, 1, e =>
                    {
                        LogLock.OutSql2Log("AOPLog", new string[] { dataIntercept });
                    });
                }
            }
            catch (Exception ex)// 同步2
            {
                LogEx(ex, dataIntercept);
            }
        }

        //private bool IsAsyncMethod(MethodInfo method)
        //{
        //    return method.ReturnType == typeof(Task) ||
        //        (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>));
        //}

        ///// <summary>
        ///// Service 成功时执行
        ///// </summary>
        ///// <param name="invocation"></param>
        ///// <param name="dataIntercept"></param>
        ///// <returns></returns>
        //private async Task SuccessAction(IInvocation invocation, string dataIntercept)
        //{
        //    var type = invocation.Method.ReturnType;
        //    if (typeof(Task).IsAssignableFrom(type))
        //    {
        //        var resultProperty = type.GetProperty("Result");
        //        dataIntercept += ($"【执行完成结果】：{JsonConvert.SerializeObject(resultProperty.GetValue(invocation.ReturnValue))}");
        //    }
        //    else
        //    {
        //        dataIntercept += ($"【执行完成结果】：{invocation.ReturnValue}");
        //    }

        //    await Task.Run(() =>
        //    {
        //        Parallel.For(0, 1, e =>
        //        {
        //            LogLock.OutSql2Log("AOPLog", new string[] { dataIntercept });
        //        });
        //    });
        //}

        private void LogEx(Exception ex, string dataIntercept)
        {
            if (ex != null)
            {
                //执行的 service 中，收录异常
                MiniProfiler.Current.CustomTiming("Errors：", ex.Message);
                //执行的 service 中，捕获异常
                dataIntercept += ($"【执行完成结果】：方法中出现异常：{ex.Message + ex.InnerException}\r\n");

                // 异常日志里有详细的堆栈信息
                Parallel.For(0, 1, e =>
                {
                    LogLock.OutSql2Log("ExLog", new string[] { dataIntercept });
                });
            }
        }

        //internal static class InternalAsyncHelper
        //{
        //    public static async Task AwaitTaskWithPostActionAndFinally(Task actualReturnValue, Func<Task> postAction, Action<Exception> finalAction)
        //    {
        //        Exception exception = null;

        //        try
        //        {
        //            await actualReturnValue;
        //            await postAction();
        //        }
        //        catch (Exception ex)
        //        {
        //            exception = ex;
        //        }
        //        finally
        //        {
        //            finalAction(exception);
        //        }
        //    }

        //    public static async Task<T> AwaitTaskWithPostActionAndFinallyAndGetResult<T>(Task<T> actualReturnValue, Func<Task> postAction, Action<Exception> finalAction)
        //    {
        //        Exception exception = null;

        //        try
        //        {
        //            var result = await actualReturnValue;
        //            await postAction();
        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            exception = ex;
        //            throw;
        //        }
        //        finally
        //        {
        //            finalAction(exception);
        //        }
        //    }

        //    public static object CallAwaitTaskWithPostActionAndFinallyAndGetResult(Type taskReturnType, object actualReturnValue, Func<Task> action, Action<Exception> finalAction)
        //    {
        //        return typeof(InternalAsyncHelper)
        //            .GetMethod("AwaitTaskWithPostActionAndFinallyAndGetResult", BindingFlags.Public | BindingFlags.Static)
        //            .MakeGenericMethod(taskReturnType)
        //            .Invoke(null, new object[] { actualReturnValue, action, finalAction });
        //    }
        //}
    }
}
