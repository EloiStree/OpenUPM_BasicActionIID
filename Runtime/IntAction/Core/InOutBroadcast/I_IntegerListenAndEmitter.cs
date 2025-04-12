namespace Eloi.IntAction
{


    /// <summary>
    /// I am a class that is used to listen and emit integer representing actions
    /// Give me integer and I may do action based on it and I will notify you when I do need to emit an integer actions to be be handled with.
    /// </summary>
    public interface I_IntegerListenAndEmitter : I_IntActionListener, I_IntActionEmitter { }

}