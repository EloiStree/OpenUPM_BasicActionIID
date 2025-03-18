using UnityEngine.Events;

namespace Eloi.IntAction
{
    public interface I_IntegerEmitter { 
    
        void AddEmissionListener(UnityAction<int> p_listener);
        void RemoveEmissionListener(UnityAction<int> p_listener);
    }

}
