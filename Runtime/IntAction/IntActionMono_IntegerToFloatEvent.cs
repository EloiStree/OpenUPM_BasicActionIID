using UnityEngine;

namespace Eloi.IntAction
{

    [System.Serializable]
    public class IntAction_IntegerToFloatEvent : IntAction_IntegerToGenericDataEvent<float>
    {
        public IntAction_IntegerToFloatEvent(params IntToDataLink<float>[] parameters) : base(parameters)
        {
        }
    }

    [System.Serializable]
    public class IntAction_IntegerToGameObjectEvent : IntAction_IntegerToGenericDataEvent<GameObject>
    {
        public IntAction_IntegerToGameObjectEvent(params IntToDataLink<GameObject>[] parameters) : base(parameters)
        {
        }
    }

    // for transform

    [System.Serializable]
    public class IntAction_IntegerToTransformEvent : IntAction_IntegerToGenericDataEvent<Transform>
    {
        public IntAction_IntegerToTransformEvent(params IntToDataLink<Transform>[] parameters) : base(parameters)
        {
        }
    }

    // for material
    [System.Serializable]
    public class IntAction_IntegerToMaterialEvent : IntAction_IntegerToGenericDataEvent<Material>
    {
        public IntAction_IntegerToMaterialEvent(params IntToDataLink<Material>[] parameters) : base(parameters)
        {
        }
    }

    // for texture
    [System.Serializable]
    public class IntAction_IntegerToTextureEvent : IntAction_IntegerToGenericDataEvent<Texture>
    {
        public IntAction_IntegerToTextureEvent(params IntToDataLink<Texture>[] parameters) : base(parameters)
        {
        }
    }

    // for sprite
    [System.Serializable]
    public class IntAction_IntegerToSpriteEvent : IntAction_IntegerToGenericDataEvent<Sprite>
    {
        public IntAction_IntegerToSpriteEvent(params IntToDataLink<Sprite>[] parameters) : base(parameters)
        {
        }
    }

    // for audio clip

    [System.Serializable]
    public class IntAction_IntegerToAudioClipEvent : IntAction_IntegerToGenericDataEvent<AudioClip>
    {
        public IntAction_IntegerToAudioClipEvent(params IntToDataLink<AudioClip>[] parameters) : base(parameters)
        {
        }
    }

    // for int
    [System.Serializable]

    public class IntAction_IntegerToIntEvent : IntAction_IntegerToGenericDataEvent<int>
    {
        public IntAction_IntegerToIntEvent(params IntToDataLink<int>[] parameters) : base(parameters)
        {
        }
    }
    [System.Serializable]
    // for long
    public class IntAction_IntegerToLongEvent : IntAction_IntegerToGenericDataEvent<long>
    {
        public IntAction_IntegerToLongEvent(params IntToDataLink<long>[] parameters) : base(parameters)
        {
        }
    }

    // for double

    [System.Serializable]
    public class IntAction_IntegerToDoubleEvent : IntAction_IntegerToGenericDataEvent<double>
    {
        public IntAction_IntegerToDoubleEvent(params IntToDataLink<double>[] parameters) : base(parameters)
        {
        }
    }



    // for color


    [System.Serializable]
    public class IntAction_IntegerToColorEvent : IntAction_IntegerToGenericDataEvent<Color>
    {
        public IntAction_IntegerToColorEvent(params IntToDataLink<Color>[] parameters) : base(parameters)
        {
        }
    }


    [System.Serializable]
    public class IntAction_IntegerToStringEvent : IntAction_IntegerToGenericDataEvent<string>
    {
        public IntAction_IntegerToStringEvent(params IntToDataLink<string>[] parameters) : base(parameters)
        {
        }
    }
    [System.Serializable]
    public class IntAction_IntegerToBoolEvent : IntAction_IntegerToGenericDataEvent<bool>
    {
        public IntAction_IntegerToBoolEvent(params IntToDataLink<bool>[] parameters) : base(parameters)
        {
        }
    }
    [System.Serializable]
    public class IntAction_IntegerToByteEvent : IntAction_IntegerToGenericDataEvent<byte>
    {
        public IntAction_IntegerToByteEvent(params IntToDataLink<byte>[] parameters) : base(parameters)
        {
        }

    }

    public class IntActionMono_IntegerToFloatEvent : IntActionMono_IntegerToGenericDataEvent<float>
    {
        public IntActionMono_IntegerToFloatEvent(params IntToDataLink<float>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<float>[] parameters)
        {
            parameters = new IntToDataLink<float>[0];
        }
    }

    public class IntActionMono_IntegerToUIntEvent : IntActionMono_IntegerToGenericDataEvent<uint>
    {
        public IntActionMono_IntegerToUIntEvent(params IntToDataLink<uint>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<uint>[] parameters)
        {
            parameters = new IntToDataLink<uint>[0];
        }
    }
    public class IntActionMono_IntegerToSByteEvent : IntActionMono_IntegerToGenericDataEvent<sbyte>
    {
        public IntActionMono_IntegerToSByteEvent(params IntToDataLink<sbyte>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<sbyte>[] parameters)
        {
            parameters = new IntToDataLink<sbyte>[0];
        }
    }
    public class IntActionMono_IntegerToShortEvent : IntActionMono_IntegerToGenericDataEvent<short>
    {
        public IntActionMono_IntegerToShortEvent(params IntToDataLink<short>[] parameters) : base(parameters)
        {
        }

        public override void GetDefaultValueForReset(out IntToDataLink<short>[] parameters)
        {
            parameters = new IntToDataLink<short>[0];
        }
    }




}