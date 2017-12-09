using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSDemos.Lock
{
    [Mainxx.CsOutput.Example("Lock例子", "Task 无lock")]
    public class LockDemo1
    {
        public void Run()
        {

            for (int i = 0; i <= 50; i++)
            {
                var result = Task.Run<string>(() => GenerateId());
            }
            Thread.Sleep(5000);
        }
        /// <summary>
        /// 订单增长值
        /// </summary>
        private static int _sn = 0;
        /// <summary>
        /// 生成订单编号
        /// </summary>
        public static Task<string> GenerateId()
        {
            if (_sn == 99)
            {
                _sn = 0;
            }
            _sn++;
            Thread.Sleep(50);
            var order = $"D{DateTime.Now.ToString("yyyyMMdd")}{_sn.ToString().PadLeft(3, '0')}({Thread.CurrentThread.ManagedThreadId.ToString()})";
            Console.WriteLine(order);
            return Task.FromResult(order);
        }

    }
}
