namespace Eloi.IntAction
{
    public class IntActionMono_IntegerToIntEvent : IntActionMono_IntegerToGenericDataEvent<int>
    {
        public IntActionMono_IntegerToIntEvent()
        {
        }

        public IntActionMono_IntegerToIntEvent(params IntToDataLink<int>[] parameters) : base(parameters)
        {
        }

        public override void GetDefaultValueForReset(out IntToDataLink<int>[] parameters)
        {
            parameters = new IntToDataLink<int>[0];
        }

    }

}