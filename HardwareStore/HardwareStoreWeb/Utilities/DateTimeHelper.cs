namespace HardwareStoreWeb.Utilities
{
    public static class DateTimeHelper
    {
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dateTime;
        }

        public static long DateTimeToUnixTimeStamp(DateTime time)
        {
            return ((DateTimeOffset)time).ToUnixTimeSeconds();
        }

        public static long GetCurrentUnixTimeStamp()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        }
    }
}
