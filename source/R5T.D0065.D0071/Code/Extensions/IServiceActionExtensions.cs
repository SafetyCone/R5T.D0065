using System;

using R5T.Lombardy;

using R5T.T0062;
using R5T.T0063;

using R5T.D0071.ExecutingAssembly;


namespace R5T.D0065.D0071
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ExecutableDirectoryPathProvider"/> implementation of <see cref="IExecutableDirectoryPathProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IExecutableDirectoryPathProvider> AddExecutableDirectoryPathProviderAction(this IServiceAction _,
            IServiceAction<IFilePathProvider> filePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IExecutableDirectoryPathProvider>(services => services.AddExecutableDirectoryPathProvider(
                filePathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }
    }
}
