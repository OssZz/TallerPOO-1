using System;

namespace Taller01
{
    public class Time
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }
        public Time(int hour)
        {
            ValidateHour(hour);
            _hour = hour;

            _minute = 0;
            _second = 0;
            _millisecond = 0;
        }
        public Time(int hour, int minute)
        {
            ValidateHour(hour);
            ValidateMinute(minute);

            _hour = hour;
            _minute = minute;
            _second = 0;
            _millisecond = 0;
        }
        public Time(int hour, int minute, int second)
        {
            ValidateHour(hour);
            ValidateMinute(minute);
            ValidateSecond(second);

            _hour = hour;
            _minute = minute;
            _second = second;
            _millisecond = 0;
        }
        public Time(int hour, int minute, int second, int millisecond)
        {
            ValidateHour(hour);
            ValidateMinute(minute);
            ValidateSecond(second);
            ValidateMillisecond(millisecond);

            _hour = hour;
            _minute = minute;
            _second = second;
            _millisecond = millisecond;
        }
        public override string ToString()
        {
            int displayHour = _hour;
            string amPm = "AM";

            if (_hour == 0)
            {
                displayHour = 12;
            }
            else if (_hour == 12)
            {
                amPm = "PM";
            }
            else if (_hour > 12)
            {
                displayHour = _hour - 12;
                amPm = "PM";
            }
            return string.Format("{0:00}:{1:00}:{2:00}.{3:000} {4}",
                displayHour, _minute, _second, _millisecond, amPm);
        }
        public long ToMilliseconds()
        {
            return (long)_hour * 3600000
                 + (long)_minute * 60000
                 + (long)_second * 1000
                 + _millisecond;
        }
        public long ToSeconds()
        {
            return (long)_hour * 3600
                 + (long)_minute * 60
                 + _second;
        }
        public long ToMinutes()
        {
            return (long)_hour * 60
                 + _minute;
        }
        public bool IsOtherDay(Time otherTime)
        {
            long sumMs = this.ToMilliseconds() + otherTime.ToMilliseconds();
            long msPerDay = 24L * 3600000;

            return (sumMs >= msPerDay);
        }
        public Time Add(Time otherTime)
        {
            long sumMs = this.ToMilliseconds() + otherTime.ToMilliseconds();
            long msPerDay = 24L * 3600000;
            sumMs = sumMs % msPerDay;

            int newHour = (int)(sumMs / 3600000);
            long remainder = sumMs % 3600000;

            int newMinute = (int)(remainder / 60000);
            remainder = remainder % 60000;

            int newSecond = (int)(remainder / 1000);
            int newMillisecond = (int)(remainder % 1000);

            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }
        private void ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentException($"The hour: {hour}, is not valid.");
            }
        }

        private void ValidateMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException($"The minute: {minute}, is not valid.");
            }
        }

        private void ValidateSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentException($"The second: {second}, is not valid.");
            }
        }

        private void ValidateMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentException($"The millisecond: {millisecond}, is not valid.");
            }
        }
    }
}