namespace DotNetReact.Models {
    public class CreateVeggiePayload {
        public bool Success { get; set; }
        public string Msg { get; set; }

        public CreateVeggiePayload () {

        }

        public CreateVeggiePayload (bool success, string msg) {
            Success = success;
            Msg = msg;
        }
    }
}