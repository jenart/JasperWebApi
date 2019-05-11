namespace JasperWebApi.Commands
{
    public class SendMessageCommand
    {
        public string Msg { get; }

        public SendMessageCommand(string msg)
        {
            Msg = msg;
        }
    }
}