using System;

using R5T.Dacia;

using IExecutingAssemblyFilePathProvider = R5T.D0071.ExecutingAssembly.IFilePathProvider;


namespace R5T.D0065.Standard
{
    public interface IExecutableDirectoryPathAggregation02
    {
        public IServiceAction<IExecutableDirectoryPathProvider> ExecutableDirectoryPathProviderAction { get; set; }
        public IServiceAction<IExecutingAssemblyFilePathProvider> ExecutingAssemblyFilePathProviderAction { get; set; }
    }
}
