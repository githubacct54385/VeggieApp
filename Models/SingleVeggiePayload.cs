using System;
namespace DotNetReact.Models {
    public class SingleVeggiePayload {
        public Veggie Veggie { get; set; }
        public bool Success { get; set; }
        public string Msg { get; set; }

        public SingleVeggiePayload () {

        }

        public SingleVeggiePayload (Veggie veggie, bool success, string msg) {
            Veggie = veggie;
            Success = success;
            Msg = msg;
        }
    }
}