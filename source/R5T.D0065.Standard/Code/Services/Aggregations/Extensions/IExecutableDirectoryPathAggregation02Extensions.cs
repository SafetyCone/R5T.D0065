using System;

using R5T.D0065.Standard;


namespace System
{
    public static class IExecutableDirectoryPathAggregation02Extensions
    {
        public static T FillFrom<T>(this T aggregation,
            IExecutableDirectoryPathAggregation02 other)
            where T : IExecutableDirectoryPathAggregation02
        {
            aggregation.ExecutableDirectoryPathProviderAction = other.ExecutableDirectoryPathProviderAction;
            aggregation.ExecutingAssemblyFilePathProviderAction = other.ExecutingAssemblyFilePathProviderAction;

            return aggregation;
        }
    }
}
