namespace van.Core
{
    public class ActionConfirmation
    {
        private ActionConfirmation() { }

        public static ActionConfirmation CreateSuccessConfirmation(string message)
        {
            ActionConfirmation confirmation = new ActionConfirmation();
            confirmation.Message = message;
            confirmation.WasSuccessful = true;
            return confirmation;
        }

        public static ActionConfirmation CreateFailureConfirmation(string message)
        {
            ActionConfirmation confirmation = new ActionConfirmation();
            confirmation.Message = message;
            confirmation.WasSuccessful = false;
            return confirmation;
        }

        public bool WasSuccessful { get; private set; }
        public string Message { get; set; }
        public object Value { get; set; }
        
    }
}