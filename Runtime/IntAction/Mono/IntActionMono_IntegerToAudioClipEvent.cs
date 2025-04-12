using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToAudioClipEvent : IntActionMono_IntegerToGenericDataEvent<AudioClip>
    {
        public IntActionMono_IntegerToAudioClipEvent(params IntToDataLink<AudioClip>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<AudioClip>[] parameters)
        {
            parameters = new IntToDataLink<AudioClip>[0];
        }
    }

}