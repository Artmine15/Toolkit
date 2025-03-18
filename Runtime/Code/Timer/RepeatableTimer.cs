using System;

namespace Artmine15.Toolkit
{
    public class RepeatableTimer : Timer
    {
        public event Action OnRepeated;

        protected override void DoOnTimeLimitExceeded()
        {
            Repeat();
        }

        private void Repeat()
        {
            SetTimeLimit(TimeLimit);
            OnRepeated?.Invoke();
        }
    }
}
