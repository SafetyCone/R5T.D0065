using System;

using R5T.Dacia;


namespace R5T.D0065.Standard
{
    public class ExecutableDirectoryPathAggregation01
    {
        public IServiceAction<IExecutableDirectoryPathProvider> ExecutableDirectoryPathProviderAction { get; set; }
        public IServiceAction<IExecutableFilePathProvider> ExecutableFilePathProviderAction { get; set; }
    }
}
