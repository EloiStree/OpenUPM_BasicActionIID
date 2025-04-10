namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToLongEvent : IntActionMono_IntegerToGenericDataEvent<long>
    {
        public IntActionMono_IntegerToLongEvent(params IntToDataLink<long>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<long>[] parameters)
        {
            parameters = new IntToDataLink<long>[0];
        }
    }




}