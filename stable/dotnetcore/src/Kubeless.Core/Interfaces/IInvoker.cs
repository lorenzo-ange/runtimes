using System.Reflection;
using Kubeless.Functions;
using System.Threading.Tasks;

namespace Kubeless.Core.Interfaces
{
    public interface IInvoker
    {
        MethodInfo MethodInfo { get; }
        IFunction Function { get; }

        Task<object> Execute(Event kubelessEvent, Context kubelessContext);
    }
}
