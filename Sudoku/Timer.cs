using System;

namespace Sudoku
{
    public class Timer
    {
        private DateTime _startTime = new DateTime();
        private DateTime _stopTime = new DateTime();
        private DateTime _pauseTimeStart = new DateTime();
        private DateTime _pauseTimeEnd = new DateTime();
        private TimeSpan _time = new TimeSpan();
        private bool _running;

        public void Start()
        {
            if (_running)
                throw new InvalidOperationException("Stopwatch is already running");

            if (_stopTime != DateTime.MinValue)
            {
                _pauseTimeEnd = DateTime.Now;
                TimeSpan difference = _pauseTimeEnd - _pauseTimeStart;
                _startTime = _startTime + difference;
            }
            else
            {
                _startTime = DateTime.Now;
            }
            _running = true;
        }

        public void Stop()
        {
            if (!_running)
                throw new InvalidOperationException("Stopwatch is not running");

            _stopTime = DateTime.Now;
            _pauseTimeStart = DateTime.Now;
            _running = false;
        }

        private void CalcTime()
        {
            if (_stopTime == DateTime.MinValue || _startTime == DateTime.MinValue)
                throw new InvalidOperationException("Stopwatch time failed to record");

            _time = _stopTime - _startTime;
        }

        private void ResetTime()
        {
            _stopTime = new DateTime();
            _startTime = new DateTime();
        }

        public string GetTime()
        {
            CalcTime();
            ResetTime();
            return _time.ToString();
        }
    }
}
