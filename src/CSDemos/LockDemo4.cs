﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSDemos.Lock
{
    [Mainxx.CsOutput.Example("Lock例子", "有lock")]
    public class LockDemo4
    {
        public void Run()
        {

            for (int i = 0; i <= 1200; i++)
            {
                //多线程
                var result = Task.Run<string>(() => GenerateId());
            }
            Thread.Sleep(200000);
        }

       /// <summary>
       /// lock对象
       /// </summary>
        private static readonly object Locker = new object();
        /// <summary>
        /// 订单增长值
        /// </summary>
        private static int _sn = 0;

        /// <summary>
        /// 生成订单编号 (多线程调用无重复)
        /// </summary>
        public static string GenerateId()
        {
            lock (Locker)  //lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。
            {
                if (_sn == 999)
                {
                    _sn = 0;
                }
                _sn++;
               // Thread.Sleep(50);
                var order = $"SSC{DateTime.Now.ToString("yyyyMMddHHmmss")}{_sn.ToString().PadLeft(3, '0')}({Thread.CurrentThread.ManagedThreadId.ToString()})";
                Console.WriteLine(order);
                return order;
            }
        }
    }
}
