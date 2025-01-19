using System;
using System.Collections;
using UnityEngine;

namespace Artmine15.Packages.Utils.Toolkit.Code
{
    public class Timer
    {
        private float _time;
        private float _mainTimer;
        private float _mainTimerNormalizedBuffer;

        public event Action OnTimerEnded;
        public event Action OnTimerRepeated;

        private TimerType _currentTimerType;
        private TimerGrowing _currentTimerGrowing;
        private bool _isCurrentTimerActive;

        public void UpdateTimer(float deltaTime)
        {
            if (_isCurrentTimerActive == false) return;

            if (_currentTimerGrowing == TimerGrowing.Decreasing)
            {
                if (_mainTimer > 0)
                {
                    _mainTimer -= deltaTime;
                }
                else if (_mainTimer <= 0)
                {
                    if (_currentTimerType == TimerType.Repeatable)
                    {
                        RepeatRepeatableTimer();
                    }
                    else
                    {
                        Stop();
                    }
                }
            }
            else if(_currentTimerGrowing == TimerGrowing.Increasing)
            {
                if (_mainTimer < _time)
                {
                    _mainTimer += deltaTime;
                }
                else if (_mainTimer >= _time)
                {
                    if (_currentTimerType == TimerType.Repeatable)
                    {
                        RepeatRepeatableTimer();
                    }
                    else
                    {
                        Stop();
                    }
                }
            }
        }

        private void SetTimer(float seconds)
        {
            _time = seconds;
            if (_currentTimerGrowing == TimerGrowing.Decreasing)
                _mainTimer = _time;
            else
                _mainTimer = 0;
        }

        public void StartTimer(float seconds, TimerType type, TimerGrowing timerGrowing = TimerGrowing.Decreasing)
        {
            if (type == TimerType.None) return;
            _currentTimerGrowing = timerGrowing;
            SetTimer(seconds);

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
            _isCurrentTimerActive = true;
        }

        private void StartCommonTimer()
        {
            _currentTimerType = TimerType.Common;
        }

        private void StartRepeatableTimer()
        {
            if (_currentTimerType != TimerType.Repeatable)
            {
                _currentTimerType = TimerType.Repeatable;
            }
            else
            {
                throw new Exception("Repeatable timer is already running. To set a new value use RepeatRepeatableTimer()");
            }
        }

        /// <summary>
        /// Can be decreasing only. You can't get timer value.
        /// </summary>
        public IEnumerator StartCoroutineTimer(float seconds)
        {
            _currentTimerType = TimerType.Coroutine;
            yield return new WaitForSeconds(seconds);
            OnTimerEnded?.Invoke();
            yield break;
        }

        public void RepeatRepeatableTimer()
        {
            if (_currentTimerType != TimerType.Repeatable) throw new Exception("RepeatRepeatableTimer() invokes not in the repeatable timer");

            if (_isCurrentTimerActive == true)
            {
                SetTimer(_time);
                OnTimerRepeated?.Invoke();
            }
        }

        public void Pause()
        {
            _isCurrentTimerActive = false;
        }

        public void Resume()
        {
            _isCurrentTimerActive = true;
        }

        public void Stop()
        {
            _currentTimerType = TimerType.None;
            _isCurrentTimerActive = false;

            _mainTimer = 0;
            OnTimerEnded?.Invoke();
        }

        public float GetTimerValue()
        {
            return _mainTimer;
        }

        public float GetTimerNormalizedValue()
        {
            return _mainTimer / _time;
        }

        public TimerType GetCurrentTimerType()
        {
            return _currentTimerType;
        }
    }
}
