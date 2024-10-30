using System;
using System.Collections;
using UnityEngine;

namespace Artmine15.Utils.Toolkit.Code
{
    public enum TimerType { None, Common, Coroutine, Repeatable, Stopped };

    public class Timer
    {
        private float _timerTime;
        private float _mainTimer;

        public event Action OnTimerEnded;
        //public event Action OnCommonTimerEnded;
        //public event Action OnRepeatableTimerEnded;
        //public event Action OnCoroutineTimerEnded;

        private TimerType _currentTimerType;

        public void UpdateTimer(float deltaTime)
        {
            switch (_currentTimerType)
            {
                case TimerType.Common:
                    if (_mainTimer <= 0)
                    {
                        StopTimer();
                        OnTimerEnded?.Invoke();
                        //OnCommonTimerEnded?.Invoke();
                    }
                    break;
                case TimerType.Repeatable:
                    if (_mainTimer <= 0)
                    {
                        //OnRepeatableTimerEnded?.Invoke();
                        OnTimerEnded?.Invoke();
                        RepeatRepeatableTimer();
                    }
                    break;
            }

            if(_mainTimer > 0)
                _mainTimer -= deltaTime;
        }

        private void StartCommonTimer()
        {
            _mainTimer = _timerTime;
            _currentTimerType = TimerType.Common;
        }

        private void StartRepeatableTimer()
        {
            if(_currentTimerType != TimerType.Repeatable)
            {
                _mainTimer = _timerTime;
                _currentTimerType = TimerType.Repeatable;
            }
            else
            {
                throw new Exception("Repeatable timer is already running. To set a new value use RepeatRepeatableTimer()");
            }
        }

        public IEnumerator StartCoroutineTimer(float seconds)
        {
            _currentTimerType = TimerType.Coroutine;
            yield return new WaitForSeconds(seconds);
            //OnCoroutineTimerEnded?.Invoke();
            OnTimerEnded?.Invoke();
            yield break;
        }

        public void StartTimer(float seconds, TimerType type)
        {
            _timerTime = seconds;
            switch (type)
            {
                case TimerType.Common:
                    StartCommonTimer();
                    break;
                case TimerType.Coroutine:
                    throw new Exception("CoroutineTimer can be started only via StartCoroutine(StartCoroutineTimer())");
                case TimerType.Repeatable:
                    StartRepeatableTimer();
                    break;
            }
        }

        public void RepeatRepeatableTimer()
        {
            switch (_currentTimerType)
            {
                case TimerType.Repeatable:
                    _mainTimer = _timerTime;
                    return;
                case TimerType.Stopped:
                    _currentTimerType = TimerType.None;
                    return;
            }
            throw new Exception("RepeatRepeatableTimer() invokes not in the repeatable timer");
        }

        public void StopTimer()
        {
            if(_currentTimerType == TimerType.Repeatable)
                _currentTimerType = TimerType.Stopped;
            else
                _currentTimerType = TimerType.None;
            _mainTimer = 0;
        }

        public float GetTimerValue()
        {
            return _mainTimer;
        }

        public TimerType GetCurrentTimerType()
        {
            return _currentTimerType;
        }
    }
}
