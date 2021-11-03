using System;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.T0064;


namespace R5T.D0065
{
    /// <summary>
    /// Get the executable file path as the first input argument.
    /// </summary>
    [ServiceImplementationMarker]
    public class ExecutableFilePathProvider : IExecutableFilePathProvider, IServiceImplementation
    {
        public Task<string> GetExecutableFilePath()
        {
            var executableFilePath = ExecutableFilePathHelper.GetExecutableFilePath();

            return Task.FromResult(executableFilePath);
        }
    }
}
