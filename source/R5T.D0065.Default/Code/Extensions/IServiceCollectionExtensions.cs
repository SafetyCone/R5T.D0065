﻿using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.T0063;


namespace R5T.D0065
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ExecutableFilePathProvider"/> implementation of <see cref="IExecutableFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddExecutableFilePathProvider(this IServiceCollection services)
        {
            services.AddSingleton<IExecutableFilePathProvider, ExecutableFilePathProvider>();

            return services;
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
    }
}
