using System;
using System.Threading.Tasks;

using R5T.Magyar;


namespace R5T.D0065
{
    public class ExecutableFilePathProvider : IExecutableFilePathProvider
    {
        public Task<string> GetExecutableFilePath()
        {
            var executableFilePath = ExecutableFilePathHelper.GetExecutableFilePath();

            return Task.FromResult(executableFilePath);
        }
    }
}
