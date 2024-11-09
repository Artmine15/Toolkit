using Artmine15.Utils.Toolkit.Enums;
using System;
using System.Collections;
using UnityEngine;

namespace Artmine15.Utils.Toolkit.Code
{
    public class Timer
    {
        private float _timerTime;
        private float _mainTimer;

        public event Action OnTimerEnded;
        public event Action OnTimerRepeated;

        private TimerType _currentTimerType;
        private TimerState _currentTimerState;

        public void UpdateTimer(float deltaTime)
        {
            if (_currentTimerState == TimerState.Stopped) return;

            switch (_currentTimerType)
            {
                case TimerType.Common:
                    if (_mainTimer <= 0)
                    {
                        StopTimer();
                    }
                    break;
                case TimerType.Repeatable:
                    if (_mainTimer <= 0)
                    {
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
            if (_currentTimerType != TimerType.Repeatable) throw new Exception("RepeatRepeatableTimer() invokes not in the repeatable timer");
            
            if(_currentTimerState == TimerState.Active)
            {
                _mainTimer = _timerTime;
                OnTimerRepeated?.Invoke();
            }

            //switch (_currentTimerState)
            //{
            //    case TimerState.Active:
            //        return;
            //    case TimerState.Stopped:
            //        _currentTimerType = ActiveTimerType.None;
            //        return;
            //}
        }

        public void StopTimer()
        {
            _currentTimerType = TimerType.None;
            _currentTimerState = TimerState.Stopped;

            //if (_currentTimerType == ActiveTimerType.Repeatable)
            //{
            //    _currentTimerState = TimerState.Stopped;
            //}
            //else
            //{
                
            //}
            _mainTimer = 0;
            OnTimerEnded?.Invoke();
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
