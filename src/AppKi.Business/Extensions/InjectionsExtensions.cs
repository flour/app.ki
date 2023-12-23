using Quartz;

namespace AppKi.Business.Extensions;

internal static class InjectionsExtensions
{
    public static IServiceCollectionQuartzConfigurator AddJobs<T>(
        this IServiceCollectionQuartzConfigurator configurator,
        TimeSpan simpleInterval,
        int minuteOffset = 0) where T : IJob
    {
        var now = DateTime.UtcNow;
        var startTime = (minuteOffset <= 0 ? now : now.AddMinutes(minuteOffset - now.Minute % minuteOffset))
            .AddSeconds(-now.Second);

        return configurator
            .AddJob<T>(opts => opts.WithIdentity(typeof(T).Name))
            .AddTrigger(opts =>
            {
                var builder = opts
                    .ForJob(typeof(T).Name)
                    .WithIdentity($"{typeof(T).Name}-trigger")
                    .StartAt(new DateTimeOffset(startTime));

                builder.WithSimpleSchedule(e => e.WithInterval(simpleInterval).RepeatForever());
            });
    }
}