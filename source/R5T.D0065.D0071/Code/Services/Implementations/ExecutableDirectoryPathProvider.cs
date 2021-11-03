using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.T0064;

using R5T.D0071.ExecutingAssembly;


namespace R5T.D0065.D0071
{
    [ServiceImplementationMarker]
    public class ExecutableDirectoryPathProvider : IExecutableDirectoryPathProvider, IServiceImplementation
    {
        private IFilePathProvider FilePathProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public ExecutableDirectoryPathProvider(
            IFilePathProvider filePathProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.FilePathProvider = filePathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public async Task<string> GetExecutableDirectoryPath()
        {
            var filePath = await this.FilePathProvider.GetFilePath();

            var directoryPath = this.StringlyTypedPathOperator.GetDirectoryPathForFilePath(filePath);
            return directoryPath;
        }
    }
}
