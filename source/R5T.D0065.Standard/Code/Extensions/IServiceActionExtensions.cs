using System;

using R5T.Lombardy;

using R5T.D0071.Default;
using R5T.T0062;
using R5T.T0063;

using R5T.D0065.Default;
using R5T.D0065.D0071;


namespace R5T.D0065.Standard
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Uses the <see cref="R5T.D0071.ExecutingAssembly.IFilePathProvider"/> service to get the executable directory path expected from working with console applications (the directory containing all assembly DLLs).
        /// This directory path is robust to running under tooling (like with EF Core or MSTest) where the tool executable running the code is the entry point or first input argument to the process.
        /// </summary>
        public static ExecutableDirectoryPathActionAggregation AddExecutableDirectoryPathProviderActions(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // Level 0.
            var executingAssemblyFilePathProviderAction = _.AddFilePathProviderAction();
            var executableFilePathProviderAction = _.AddExecutableFilePathProviderAction();

            // Level 1.
            var executableDirectoryPathProviderAction = _.AddExecutableDirectoryPathProviderAction(
                executingAssemblyFilePathProviderAction,
                stringlyTypedPathOperatorAction);

            return new ExecutableDirectoryPathActionAggregation
            {
                ExecutingAssemblyFilePathProviderAction = executingAssemblyFilePathProviderAction,
                ExecutableFilePathProviderAction = executableFilePathProviderAction,
                ExecutableDirectoryPathProviderAction = executableDirectoryPathProviderAction,
            };
        }
    }
}
