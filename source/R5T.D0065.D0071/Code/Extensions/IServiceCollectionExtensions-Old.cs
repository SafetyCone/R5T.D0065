using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;

using R5T.D0071.ExecutingAssembly;


namespace R5T.D0065.D0071
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ExecutableDirectoryPathProvider"/> implementation of <see cref="IExecutableDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddExecutableDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IFilePathProvider> filePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services.AddSingleton<IExecutableDirectoryPathProvider, ExecutableDirectoryPathProvider>()
                .Run(filePathProviderAction)
                .Run(stringlyTypedPathOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ExecutableDirectoryPathProvider"/> implementation of <see cref="IExecutableDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IExecutableDirectoryPathProvider> AddExecutableDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IFilePathProvider> filePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<IExecutableDirectoryPathProvider>(() => services.AddExecutableDirectoryPathProvider(
                filePathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }
    }
}
