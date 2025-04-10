namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToByteEvent : IntActionMono_IntegerToGenericDataEvent<byte>
    {
        public IntActionMono_IntegerToByteEvent(params IntToDataLink<byte>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<byte>[] parameters)
        {
            parameters = new IntToDataLink<byte>[0];
        }

    }




}