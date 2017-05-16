///
/// Copyright 2017
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
/// 
///     http://www.apache.org/licenses/LICENSE-2.0
/// 
/// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///


using System;
using System.IO;
using ZeroMQ;

namespace NavInterfaceClient {
    /// <summary>
    /// Provides an interface to connect to the simulation server 
    /// </summary>
    public class Client {
        public const string SERVER_HOST = "localhost";
        public const int SERVER_PORT = 20170;
        public const string DEFAULT_USER = "hsdc";
        public const string DEFAULT_PASS = "harris";


        private ZContext context = new ZContext();
        private ZSocket socket;
        private bool connected = false;
        public bool Connected { get { return connected; } }
        /// <summary>
        /// If Verbose is set, send and receive print the raw messages to the console
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// Connects to the simulation server
        /// </summary>
        /// <param name="host">The address of the server (OPTIONAL)</param>
        /// <param name="port">The port of the server (OPTIONAL)</param>
        /// <returns>True if the connection was successful</returns>
        public bool connect(string host = SERVER_HOST, int port = SERVER_PORT, string username = DEFAULT_USER, string password = DEFAULT_PASS) {
            string connect = string.Format("tcp://{0}:{1}", host, port);
            
            socket = new ZSocket(context, ZSocketType.REQ);

            if (Verbose)
                Console.WriteLine("Connecting to " + connect);
            socket.Connect(connect);
            try {
                
                send(string.Format("hello {0} {1}", username, password));

                string message = receive()[0];
                connected = message == "hello";
            }
            catch (IOException) {
                connected = false;
            }

            return connected;
        }

        /// <summary>
        /// Disconnects from the server
        /// </summary>
        public void disconnect() {
            send("finish");
            receive();
        }

        /// <summary>
        /// Sends a message to the server. <para/> 
        /// Send must ALWAYS be followed by a call to <seealso cref="receive()">receive()</seealso>
        /// </summary>
        /// <param name="message">Server command to be sent</param>
        /// <param name="value">Any extra value to be sent (OPTIONAL)</param>
        public void send(string message, string value = "") {
            if (Verbose)
                Console.WriteLine(string.Format("nav -->     {0}", message + " " + value));
            try {
                 socket.Send(new ZFrame(message + " " + value));
            }
            catch (ZException e) {
                Console.WriteLine(e.Message);
                throw new IOException(e.Message);
            }
        }

        /// <summary>
        /// Receives a message from the server.<para />
        /// [0] contains the server command received.<para />
        /// [1] (if it exists) contain any values received
        /// </summary>
        public string[] receive() {
            try {
                string s = socket.ReceiveFrame().ReadString();

                if (Verbose)
                    Console.WriteLine(string.Format("   <-- sim  {0}", s));

                string[] splitMessage = s.Split(new[] { ' ' }, 2);
                return splitMessage;
            }
            catch (ZException e) {
                Console.WriteLine(e.Message);
                throw new IOException(e.Message);
            }
        }

    }
}
