using System;

namespace Artmine15.Toolkit
{
    public abstract class Timer
    {
        protected float TimeLimit;
        protected float MainTimer;

        protected TimerGrowing Growing;
        public bool IsActive { get; private set; }

        public event Action OnEnded;

        public void Update(float deltaTime)
        {
            if (IsActive == false) return;

            if (Growing == TimerGrowing.Decreasing)
            {
                if (MainTimer > 0)
                {
                    MainTimer -= deltaTime;
                }
                else if (MainTimer <= 0)
                {
                    MainTimer = 0;
                    DoOnTimeLimitExceeded();
                }
            }
            else if (Growing == TimerGrowing.Increasing)
            {
                if (MainTimer < TimeLimit)
                {
                    MainTimer += deltaTime;
                }
                else if (MainTimer >= TimeLimit)
                {
                    MainTimer = TimeLimit;
                    DoOnTimeLimitExceeded();
                }
            }
        }

        protected abstract void DoOnTimeLimitExceeded();

        public void SetTimeLimit(float seconds)
        {
            TimeLimit = seconds;
        }

        public void Start(float seconds, TimerGrowing timerGrowing = TimerGrowing.Decreasing)
        {
            Growing = timerGrowing;
            SetTimeLimit(seconds);
            Reset();

            IsActive = true;
        }

        public void Pause()
        {
            IsActive = false;
        }

        public void Resume()
        {
            IsActive = true;
        }

        public void Stop()
        {
            IsActive = false;

            MainTimer = 0;
            OnEnded?.Invoke();
        }

        public void Reset()
        {
            if (Growing == TimerGrowing.Decreasing)
                MainTimer = TimeLimit;
            else
                MainTimer = 0;
        }

        public float GetTime()
        {
            return MainTimer;
        }

        public float GetNormalizedTime()
        {
            return MainTimer / TimeLimit;
        }
    }
}
