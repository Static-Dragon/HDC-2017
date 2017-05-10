using NavInterfaceClient;

namespace HDC {
    public class SailAI {
        Client SimAPI;
        bool debug;
        public SailAI(ref Client SimAPI,bool debug) {
            this.SimAPI = SimAPI;
            this.debug = debug;
        }
        public void start() {
            SimAPI.send("anchor", "false");
            SimAPI.receive();
        }
    }
}
