using System;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

namespace TimerManagment
{
    public class TimerManager : MonoBehaviour
    {
        public List<Timer> m_Timers = new List<Timer>();

        public static ProfilerMarker s_TimersUpdate = new ProfilerMarker("Timers Update");

        public Timer CreatTimer(float time, bool isLooped = false)
        {
            Timer timer = new Timer(time, isLooped);
            timer.OnRemove += RemoveTimer;
            m_Timers.Add(timer);

            return timer;
        }

        private void Update()
        {
            s_TimersUpdate.Begin();

            foreach (Timer timer in m_Timers)
                timer.Update(Time.deltaTime);

            s_TimersUpdate.End();
        }

        private void RemoveTimer(Timer timer) => m_Timers.Remove(timer);
    }
}
