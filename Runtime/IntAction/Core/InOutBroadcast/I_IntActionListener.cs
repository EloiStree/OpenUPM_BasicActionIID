namespace Eloi.IntAction
{
    /// <summary>
    /// I am a class that is used to listen and emit integer representing actions
    /// Give me integer and I may do action based on it.
    /// </summary>
    public interface I_IntActionListener
    {
        void HandleIntegerAction(int integerValue);
    }
}