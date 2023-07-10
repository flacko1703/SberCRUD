namespace SberCrudOps.Application.Extensions;

public static class DateTimeExtensions
{
    public static DateTime Truncate(this DateTime dateTime, long ticks)
    {
        bool isValid = ticks is TimeSpan.TicksPerDay or TimeSpan.TicksPerHour or TimeSpan.TicksPerMinute
            or TimeSpan.TicksPerSecond or TimeSpan.TicksPerMillisecond;

        return isValid 
            ? DateTime.SpecifyKind(
                new DateTime(
                    dateTime.Ticks - (dateTime.Ticks % ticks)
                ),
                dateTime.Kind
            )
            : throw new ArgumentException("Invalid ticks value given. Only TimeSpan tick values are allowed.");
    }
}