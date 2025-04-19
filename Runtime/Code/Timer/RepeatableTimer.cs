using System;

namespace Artmine15.Toolkit
{
    public class RepeatableTimer : Timer
    {
        private float _nextTimeLimit;
        private bool _isHasNextTimeLimit;

        public event Action OnRepeated;

        protected override void DoOnTimeLimitExceeded()
        {
            Repeat();
        }

        /// <summary>
        /// Set the time limit that will be applied when timer repeats.
        /// </summary>
        public void SetNextTimeLimit(float seconds)
        {
            _nextTimeLimit = seconds;
            _isHasNextTimeLimit = true;
        }

        private void Repeat()
        {
            if(_isHasNextTimeLimit == true)
            {
                SetTimeLimit(_nextTimeLimit);
                _isHasNextTimeLimit = false;
            }
            Reset();
            OnRepeated?.Invoke();
        }
    }
}
