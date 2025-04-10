namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToUShortEvent : IntActionMono_IntegerToGenericDataEvent<ushort>
    {
        public IntActionMono_IntegerToUShortEvent(params IntToDataLink<ushort>[] parameters) : base(parameters)
        {
        }

        public override void GetDefaultValueForReset(out IntToDataLink<ushort>[] parameters)
        {
            parameters = new IntToDataLink<ushort>[0];
        }
    }




}