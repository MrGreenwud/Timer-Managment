using System;

namespace TimerManagment
{
    public class Timer
    {
        private float m_Time;
        private float m_CurrentTime;
        private bool m_IsLooped;

        public event Action OnEnd;
        public event Action<Timer> OnRemove;

        public Timer(float time, bool isLooped)
        {
            m_Time = time;
            m_IsLooped = isLooped;
        }

        public void Update(float deltaTime)
        {
            m_CurrentTime -= deltaTime;

            if (m_CurrentTime <= 0)
            {
                OnEnd?.Invoke();

                if (m_IsLooped == true)
                    m_CurrentTime = m_Time;
                else
                    OnRemove?.Invoke(this);
            }
        }
    }
}