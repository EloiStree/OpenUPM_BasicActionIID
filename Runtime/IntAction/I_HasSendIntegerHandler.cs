namespace Eloi.IntAction
{
    public interface  I_HasSendIntegerHandler
    {
        /// <summary>
        /// Allows to request a integer to be sent by the handler. 
        /// If the integer pass the filter it will be sent to the an emitter depending of the developer code
        /// </summary>
        /// <param name="integerValue"></param>
        public void SendInteger(int integerValue);

    }
}