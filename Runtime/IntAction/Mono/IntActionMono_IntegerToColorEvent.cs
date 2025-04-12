using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToColorEvent : IntActionMono_IntegerToGenericDataEvent<Color>
    {
        public IntActionMono_IntegerToColorEvent(params IntToDataLink<Color>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<Color>[] parameters)
        {
            parameters = new IntToDataLink<Color>[] {
                new IntToDataLink<Color>(700, Color.red),
                new IntToDataLink<Color>(701, Color.green),
                new IntToDataLink<Color>(702, Color.blue),
                new IntToDataLink<Color>(703, new Color(1, 0.5f, 0, 1)),
                new IntToDataLink<Color>(704, Color.yellow),
                new IntToDataLink<Color>(705, new Color(0.5f, 0, 0.5f, 1)),
                new IntToDataLink<Color>(706, new Color(1, 0.5f, 0.5f, 1)),
                new IntToDataLink<Color>(707, Color.cyan),
                new IntToDataLink<Color>(708, Color.white),
            };
        }
    }

}