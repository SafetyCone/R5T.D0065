using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;

using R5T.D0071.Default;

using R5T.D0065.D0071;


namespace R5T.D0065.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Uses the <see cref="R5T.D0071.ExecutingAssembly.IFilePathProvider"/> service to get the executable directory path expected from working with console applications (the directory containing all assembly DLLs).
        /// This directory path is robust to running under tooling (like with EF Core or MSTest) where the tool executable running the code is the entry point or first input argument to the process.
        /// </summary>
        public static ExecutableDirectoryPathAggregation02 AddToolingRobustExecutableDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // Level 0.
            var executingAssemblyFilePathProviderAction = services.AddFilePathProviderAction();

            // Level 1.
            var executableDirectoryPathProviderAction = services.AddExecutableDirectoryPathProviderAction(
                executingAssemblyFilePathProviderAction,
                stringlyTypedPathOperatorAction);

            return new ExecutableDirectoryPathAggregation02
            {
                ExecutingAssemblyFilePathProviderAction = executingAssemblyFilePathProviderAction,
                ExecutableDirectoryPathProviderAction = executableDirectoryPathProviderAction,
            };
        }

        /// <summary>
        /// Uses the <see cref="R5T.D0065.IExecutableFilePathProvider"/> service to get the executable directory path from the first input argument provided by the OS to the .NET process. This is usually the expected entry point or executable file path, like when working with console application.
        /// However, the executable directory path when determined this way can be undesirable when running under tooling (like with EF Core or MSTest) where the tool executable running the code is the entry point or first input argument to the process.
        /// </summary>
        public static ExecutableDirectoryPathAggregation01 AddToolingBrittleExecutableDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // Level 0.
            var executableFilePathProviderAction = services.AddExecutableFilePathProviderAction();

            // Level 1.
            var executableDirectoryPathProviderAction = services.AddExecutableDirectoryPathProviderAction(
                executableFilePathProviderAction,
                stringlyTypedPathOperatorAction);

            return new ExecutableDirectoryPathAggregation01
            {
                ExecutableFilePathProviderAction = executableFilePathProviderAction,
                ExecutableDirectoryPathProviderAction = executableDirectoryPathProviderAction,
            };
        }

        /// <summary>
        /// Chooses the executing assembly (robust to tooling) method of getting the executable directory path as the default.
        /// </summary>
        public static ExecutableDirectoryPathAggregation02 AddExecutableDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            return services.AddToolingRobustExecutableDirectoryPathProviderAction(
                stringlyTypedPathOperatorAction);
        }
    }
}
