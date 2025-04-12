namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToStringEvent : IntActionMono_IntegerToGenericDataEvent<string>
    {
        public IntActionMono_IntegerToStringEvent(params IntToDataLink<string>[] parameters) : base(parameters)
        {
        }

        public override void GetDefaultValueForReset(out IntToDataLink<string>[] parameters)
        {
            parameters = new IntToDataLink<string>[0];
        }
    }

}