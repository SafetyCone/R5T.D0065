using System;
using System.Threading.Tasks;

using R5T.Lombardy;


namespace R5T.D0065
{
    public class ExecutableDirectoryPathProvider : IExecutableDirectoryPathProvider
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
