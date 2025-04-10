using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToTextureEvent : IntActionMono_IntegerToGenericDataEvent<Texture>
    {
        public IntActionMono_IntegerToTextureEvent(params IntToDataLink<Texture>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<Texture>[] parameters)
        {
            parameters = new IntToDataLink<Texture>[0];
        }
    }

}