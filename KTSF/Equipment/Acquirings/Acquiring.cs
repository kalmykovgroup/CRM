using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Equipment.Acquirings
{
    public interface IAcquiringApi
    {
        public async Task<(bool result, string? message)> Pay(int price)
        {
            await Task.Delay(1000);

            return (result: true, message: null);
        }

        public async Task<(bool result, string? message)> TestSuccessPay(int price, int delay)
        {
            await Task.Delay(delay);

            return (result: true, message: null);
        }

        public async Task<(bool result, string? message)> TestErrorPay(int price, int delay)
        {
            await Task.Delay(delay);

            return (result: true, message: "Не достаточно средств");
        }
    }
}
