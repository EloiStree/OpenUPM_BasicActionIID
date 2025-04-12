namespace Eloi.IntAction
{
    // long ushort, uint, double
    //ulong 



    public class IntActionMono_IntegerToDoubleEvent : IntActionMono_IntegerToGenericDataEvent<double>
    {
        public IntActionMono_IntegerToDoubleEvent(params IntToDataLink<double>[] parameters) : base(parameters)
        {
        }

        public override void GetDefaultValueForReset(out IntToDataLink<double>[] parameters)
        {
            parameters = new IntToDataLink<double>[0];
        }
    }




}