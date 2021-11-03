using System;


namespace R5T.D0065.Standard
{
    public static class IExecutableDirectoryPathActionAggregationExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IExecutableDirectoryPathActionAggregation other)
            where T : IExecutableDirectoryPathActionAggregation
        {
            (aggregation as IExecutableDirectoryPathActionAggregationIncrement).FillFrom(other);

            return aggregation;
        }
    }
}
