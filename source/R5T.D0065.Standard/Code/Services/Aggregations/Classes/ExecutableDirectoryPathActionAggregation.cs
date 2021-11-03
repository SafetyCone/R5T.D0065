using System;

using R5T.T0063;


namespace R5T.D0065.Standard
{
    public class ExecutableDirectoryPathActionAggregation : IExecutableDirectoryPathActionAggregation
    {
        public IServiceAction<IExecutableDirectoryPathProvider> ExecutableDirectoryPathProviderAction { get; set; }
        public IServiceAction<IExecutableFilePathProvider> ExecutableFilePathProviderAction { get; set; }
        public IServiceAction<R5T.D0071.ExecutingAssembly.IFilePathProvider> ExecutingAssemblyFilePathProviderAction { get; set; }
    }
}
