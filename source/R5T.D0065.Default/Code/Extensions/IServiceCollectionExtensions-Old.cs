using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;


namespace R5T.D0065
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ExecutableFilePathProvider"/> implementation of <see cref="IExecutableFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IExecutableFilePathProvider> AddExecutableFilePathProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IExecutableFilePathProvider>(() => services.AddExecutableFilePathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ExecutableDirectoryPathProvider"/> implementation of <see cref="IExecutableDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddExecutableDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IExecutableFilePathProvider> executableFilePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services
                .AddSingleton<IExecutableDirectoryPathProvider, ExecutableDirectoryPathProvider>()
                .Run(executableFilePathProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ExecutableDirectoryPathProvider"/> implementation of <see cref="IExecutableDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IExecutableDirectoryPathProvider> AddExecutableDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IExecutableFilePathProvider> executableFilePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<IExecutableDirectoryPathProvider>(() => services.AddExecutableDirectoryPathProvider(
                executableFilePathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }
    }
}
