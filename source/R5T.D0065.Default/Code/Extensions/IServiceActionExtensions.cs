using System;

using R5T.Lombardy;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0065.Default
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ExecutableFilePathProvider"/> implementation of <see cref="IExecutableFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IExecutableFilePathProvider> AddExecutableFilePathProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IExecutableFilePathProvider>(services => services.AddExecutableFilePathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ExecutableDirectoryPathProvider"/> implementation of <see cref="IExecutableDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IExecutableDirectoryPathProvider> AddExecutableDirectoryPathProviderAction(this IServiceAction _,
            IServiceAction<IExecutableFilePathProvider> executableFilePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IExecutableDirectoryPathProvider>(services => services.AddExecutableDirectoryPathProvider(
                executableFilePathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }
    }
}
