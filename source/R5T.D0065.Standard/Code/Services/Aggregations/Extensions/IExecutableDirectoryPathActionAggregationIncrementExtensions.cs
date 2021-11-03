using System;


namespace R5T.D0065.Standard
{
    public static class IExecutableDirectoryPathActionAggregationIncrementExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IExecutableDirectoryPathActionAggregationIncrement other)
            where T : IExecutableDirectoryPathActionAggregationIncrement
        {
            aggregation.ExecutableDirectoryPathProviderAction = other.ExecutableDirectoryPathProviderAction;
            aggregation.ExecutableFilePathProviderAction = other.ExecutableFilePathProviderAction;
            aggregation.ExecutingAssemblyFilePathProviderAction = other.ExecutingAssemblyFilePathProviderAction;

            return aggregation;
        }
    }
}
