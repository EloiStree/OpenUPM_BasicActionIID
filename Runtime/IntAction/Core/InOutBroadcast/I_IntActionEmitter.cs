using System;
using UnityEngine.Events;

namespace Eloi.IntAction
{

    /// <summary>
    /// I am a class that allows to notify that I can emit integer representing actions
    /// You can subscribe to me to be notified when I emit an integer
    /// </summary>
    public interface I_IntActionEmitter {


        /// <summary>
        /// Add a listener to the event that will be called when the integer is emitted.
        /// </summary>
        /// <param name="listener"></param>
        void AddEmissionListener(Action<int> listener);
        /// <summary>
        /// Remove a listener from the event that will be called when the integer is emitted.
        /// </summary>

        void RemoveEmissionListener(Action<int> listener);
    }

}
