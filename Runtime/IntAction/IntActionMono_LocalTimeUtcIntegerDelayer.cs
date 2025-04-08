using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction {
    /// <summary>
    /// I am a simple class that can queue integer to send later based on local time
    /// </summary>
    public class IntActionMono_LocalTimeUtcIntegerDelayer : MonoBehaviour
{
    public UnityEvent<int> m_pushInteger = new UnityEvent<int>();
    public List<QueuedIntegerToPushLocalTime> m_queuedIntegerToPush = new List<QueuedIntegerToPushLocalTime>();

        public void Update()
        {
            CheckCurrentWaitingItemsToPushThem();
        }

        [ContextMenu("Check and push")]
        public void CheckCurrentWaitingItemsToPushThem()
        {
            DateTime now = DateTime.UtcNow;
            if (m_queuedIntegerToPush.Count > 0)
            {
                for (int i = m_queuedIntegerToPush.Count - 1; i >= 0; i--)
                {
                    QueuedIntegerToPushLocalTime queuedIntegerToPush = m_queuedIntegerToPush[i];
                    if (now >= queuedIntegerToPush.m_whenToSend)
                    {
                        m_pushInteger.Invoke(queuedIntegerToPush.m_integerToPush);
                        m_queuedIntegerToPush.RemoveAt(i);
                    }
                }
            }
        }

        public void ClearWaitingItems() { m_queuedIntegerToPush.Clear(); }

    public void DelayInSeconds(int integerToPush, float delayInSeconds) {

            if (delayInSeconds <=0)
            {
                m_pushInteger?.Invoke(integerToPush);
                return;
            }
            QueuedIntegerToPushLocalTime queuedIntegerToPush = new QueuedIntegerToPushLocalTime();
        queuedIntegerToPush.m_integerToPush = integerToPush;
        queuedIntegerToPush.m_whenToSend = DateTime.UtcNow.AddSeconds(delayInSeconds);
        m_queuedIntegerToPush.Add(queuedIntegerToPush);
    }
    public void DelayInMilliseconds(int integerToPush, long delayInMilliseconds) {
            if (delayInMilliseconds <= 0)
            {
                m_pushInteger?.Invoke(integerToPush);
                return;
            }
            QueuedIntegerToPushLocalTime queuedIntegerToPush = new QueuedIntegerToPushLocalTime();
        queuedIntegerToPush.m_integerToPush = integerToPush;
        queuedIntegerToPush.m_whenToSend = DateTime.UtcNow.AddMilliseconds(delayInMilliseconds);
        m_queuedIntegerToPush.Add(queuedIntegerToPush);
    }
    public void DelayAtGivenDateTime(int integerToPush, DateTime dateTime)
    {
        if (dateTime < DateTime.UtcNow)
            {
                m_pushInteger?.Invoke(integerToPush);
                return;
            }
            QueuedIntegerToPushLocalTime queuedIntegerToPush = new QueuedIntegerToPushLocalTime();
        queuedIntegerToPush.m_integerToPush = integerToPush;
        queuedIntegerToPush.m_whenToSend = dateTime;
        m_queuedIntegerToPush.Add(queuedIntegerToPush);
    }
        public void PushInteger(int integerToPush)=> m_pushInteger?.Invoke(integerToPush);

        public void PushIntegerNowUtcWithMillisecondsDelay(int integer, DateTime now, long millisecondsDelay)
        {
            if (millisecondsDelay <= 0)
            {
                m_pushInteger?.Invoke(integer);
                return;
            }
            QueuedIntegerToPushLocalTime queuedIntegerToPush = new QueuedIntegerToPushLocalTime();
            queuedIntegerToPush.m_integerToPush = integer;
            queuedIntegerToPush.m_whenToSend = now.AddMilliseconds(millisecondsDelay);
            m_queuedIntegerToPush.Add(queuedIntegerToPush);
        }
    }


}