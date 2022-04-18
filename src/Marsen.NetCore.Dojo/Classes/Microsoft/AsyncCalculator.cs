using System.Threading.Tasks;

namespace Marsen.NetCore.Dojo.Classes.Microsoft;

public sealed class AsyncCalculator
{
    public async Task<int> Add(int num1, int num2)
    {
        await Task.Delay(10);
        return num1 + num2;
    }

    public async Task<int> Subtract(int num1, int num2)
    {
        await Task.Delay(10);
        return num1 - num2;
    }

    public async Task<int> Multiply(int num1, int num2)
    {
        await Task.Delay(10);
        return num1 * num2;
    }

    public async Task<(int divisor, int remainder)> Divide(int num1, int num2)
    {
        await Task.Delay(10);
        return (num1 / num2, num1 % num2);
    }
}