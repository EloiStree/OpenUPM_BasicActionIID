using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToMaterialEvent : IntActionMono_IntegerToGenericDataEvent<Material>
    {
        public IntActionMono_IntegerToMaterialEvent(params IntToDataLink<Material>[] parameters) : base(parameters)
        {
        }

        public override void GetDefaultValueForReset(out IntToDataLink<Material>[] parameters)
        {
            parameters = new IntToDataLink<Material>[0];
        }
    }

}