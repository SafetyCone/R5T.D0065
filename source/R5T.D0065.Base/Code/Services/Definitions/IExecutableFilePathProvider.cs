using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0065
{
    [ServiceDefinitionMarker]
    public interface IExecutableFilePathProvider : IServiceDefinition
    {
        Task<string> GetExecutableFilePath();
    }
}
