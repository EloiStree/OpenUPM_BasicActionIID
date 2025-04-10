using System;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public interface I_IntegerEmitter { 
    
        void AddEmissionListener(Action<int> listener);
        void RemoveEmissionListener(Action<int> listener);
    }

}
