using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToTransformEvent : IntActionMono_IntegerToGenericDataEvent<Transform>
    {
        public IntActionMono_IntegerToTransformEvent(params IntToDataLink<Transform>[] parameters) : base(parameters)
        {
        }

        public override void GetDefaultValueForReset(out IntToDataLink<Transform>[] parameters)
        {
            parameters = new IntToDataLink<Transform>[0];
        }
    }

}