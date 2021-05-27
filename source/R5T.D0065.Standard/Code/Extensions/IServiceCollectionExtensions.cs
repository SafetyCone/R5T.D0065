using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.D0065.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static
            (
            IServiceAction<IExecutableDirectoryPathProvider> _,
            IServiceAction<IExecutableFilePathProvider> IExecutableFilePathProviderAction
            )
        AddExecutableDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // Level 0.
            var executableFilePathProviderAction = services.AddExecutableFilePathProviderAction();

            // Level 1.
            var executableDirectoryPathProviderAction = services.AddExecutableDirectoryPathProviderAction(
                executableFilePathProviderAction,
                stringlyTypedPathOperatorAction);

            return
                (
                executableDirectoryPathProviderAction,
                executableFilePathProviderAction);
        }
    }
}
