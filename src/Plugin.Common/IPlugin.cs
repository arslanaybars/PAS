using System;
using System.Threading.Tasks;

namespace Plugin.Common
{
    public interface IPlugin
    {
        string Name { get; }

        Task<PluginResponse> ExecuteAsync(string request);

        PluginResponse Execute(string request);
    }
}
