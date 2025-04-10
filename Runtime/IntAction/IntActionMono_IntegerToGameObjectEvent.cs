using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToGameObjectEvent : IntActionMono_IntegerToGenericDataEvent<GameObject>
    {
        public IntActionMono_IntegerToGameObjectEvent(params IntToDataLink<GameObject>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<GameObject>[] parameters)
        {
            parameters = new IntToDataLink<GameObject>[0];
        }
    }

}