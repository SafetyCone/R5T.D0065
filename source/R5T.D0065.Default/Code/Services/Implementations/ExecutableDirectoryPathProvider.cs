using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.T0064;


namespace R5T.D0065
{
    [ServiceImplementationMarker]
    public class ExecutableDirectoryPathProvider : IExecutableDirectoryPathProvider, IServiceImplementation
    {
        private IExecutableFilePathProvider ExecutableFilePathProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public ExecutableDirectoryPathProvider(
            IExecutableFilePathProvider executableFilePathProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.ExecutableFilePathProvider = executableFilePathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public async Task<string> GetExecutableDirectoryPath()
        {
            var executableFilePath = await this.ExecutableFilePathProvider.GetExecutableFilePath();

            var executableDirectoryPath = this.StringlyTypedPathOperator.GetDirectoryPathForFilePath(executableFilePath);

            return executableDirectoryPath;
        }
    }
}
