using UnityEngine.Events;

namespace Eloi.IntAction
{
    public interface I_IntegerEmitter { 
    
        void AddEmissionListener(UnityAction<int> listener);
        void RemoveEmissionListener(UnityAction<int> listener);
    }

}
