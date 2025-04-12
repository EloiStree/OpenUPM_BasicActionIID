namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToBoolEvent : IntActionMono_IntegerToGenericDataEvent<bool>
    {
        public IntActionMono_IntegerToBoolEvent(params IntToDataLink<bool>[] parameters) : base(parameters)
        {
        }
        public override void GetDefaultValueForReset(out IntToDataLink<bool>[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }

}