/* HDC 2017 Sail sim
* Justin T. Doyle, Tommy Chang, Bryce James, Eric Munoz
*/

/*                          TODO:
*  Find a way to asynchronously run the updatestatus() DONE!
*  Implement algorithims 
*  Should our AI run every 500 MS or 1 sec?
*/

using System;
using NavInterfaceClient;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace HDC {
    public partial class Form1 : Form {
        String serverHost, username, password;
        static bool debug = false, anchorState;
        bool connected = false;
        int serverPort;
        Pen pen = new Pen (Color.Black);
        
        Thread sampleThread;
        static Client simAPI = new Client();
        SailAI seaFire = new SailAI(ref simAPI, debug);

        public Form1() { InitializeComponent(); }
        private void Form1_Load(object sender, EventArgs e) {
            Thread sampleThread = new Thread(delegate () {
                this.statusStrip1.Invoke (new MethodInvoker(delegate () {
                    timer_UIUpdate.Start();
                    timer_roboTick.Start();
                }));
            });
            seaFire.start();
            sampleThread.Start();
        }
        private void btn_connect_Click (object sender, EventArgs e) {
            serverHost = txtbx_Host.Text == "" ? "sim.sailsim.org" : txtbx_Host.Text;
            serverPort = txtbx_port.Text == "" ? 20170 : int.Parse(txtbx_port.Text);
            username = txtbx_uName.Text == "" ? "SeaFire" : txtbx_uName.Text;
            password = txtbx_passwd.Text == "" ? "possum" : txtbx_passwd.Text;
            connected = simAPI.connect(serverHost, serverPort, username, password);

            /** Check whether the connection was successful */
            if (connected) {
                updateStatus();
                if (debug)
                    Console.WriteLine("Connected to server");
                    simAPI.Verbose = true;
            } else {
                lbl_boatStatus.Text = lbl_boatStatus.Text + "\nConnected: False";
                if (debug)
                    Console.WriteLine("Something went wrong");
            }
            sampleThread = new Thread (delegate ()
            
            {
                // Invoke your control like this
                this.statusStrip1.Invoke(new MethodInvoker(delegate ()
                {
                    //timer_UIUpdate.Start();
                }));
            });
            sampleThread.Start();
            pbox_Grid.Show ();
            Bitmap bmp = new Bitmap (pbox_Grid.Width, pbox_Grid.Height);
            using (Graphics g = Graphics.FromImage (bmp)) {
                g.Clear (Color.White);
            }
            pbox_Grid.Image = bmp;
            /*
            PointF points = new PointF (20.0f, 20.0f);
            PointF points2 = new PointF (40.0f, 40.0f);
            PointF[] point = new PointF [2] {points, points2 };*/
            Console.WriteLine (pbox_Grid.Size);
            using (Graphics g = Graphics.FromImage (bmp)) {
                for (float x = 0f; x == 500f; x = x + 10f) {
                    g.DrawLine (pen, x, 0);
                }
            }
        }
        private void btn_discon_Click (object sender, EventArgs e) {
            if (connected) {
                simAPI.disconnect();
                connected = false;
                updateStatus();
                if (sampleThread.IsAlive) {
                    Console.WriteLine("killing...");
                    sampleThread.Abort();
                }
            }
        }

        private void timer_UIUpdate_Tick (object sender, EventArgs e) { updateStatus(); }
        private void timer_robotTick_Tick (object sender, EventArgs e) {
            
        }
        private void drpdwn_Debug_Click (object sender, EventArgs e) { debug = debug == false ? true : false; }

        private void btn_scan_Click (object sender, EventArgs e) {
            simAPI.send ("obstacleScan");
            simAPI.receive();
        }

        private void pictureBox1_Click (object sender, EventArgs e) {

        }

        private void btn_quit_Click (object sender, EventArgs e) {
            if (connected) {
                simAPI.disconnect();
                Application.Exit();
            } else {
                Application.Exit();
            }
        }

        private void dd_manualAnchor_Click(object sender, EventArgs e) {
            anchorState = sailUtils.getStatus(ref simAPI, "anchor") == "down" ? true : false;
            timer_UIUpdate.Stop();
            if (anchorState) {
                simAPI.send("anchor false");
                simAPI.receive();
            } else {
                simAPI.send("anchor true");
                simAPI.receive();
            }
            timer_UIUpdate.Start();
            updateStatus();
            
        }

        public void updateStatus() {
            if (connected) {
                lbl_boatStatus.Text = "Status:" +
                    "\nConnected: " + connected +
                    "\nAnchor: " + sailUtils.getStatus(ref simAPI, "anchor") +
                    "\nWind Heading && Strength: " + sailUtils.getStatus(ref simAPI, "windHeading") + "°  " + sailUtils.getStatus(ref simAPI, "windStrength") + " Newtons" +
                    "\nSpeed: " + sailUtils.getStatus(ref simAPI, "boatSpeed") +
                    "\nBoat Heading: " + sailUtils.getStatus(ref simAPI, "boatHeading") +
                    "\nBoat Pos: " + sailUtils.getStatus(ref simAPI, "boatPosition") +
                    "\nGoal Pos: " + sailUtils.getStatus(ref simAPI, "goalPosition");
            } else {
                lbl_boatStatus.Text = "Status:" +
                    "\nConnected: " + connected + 
                    "\nAnchor: N/A" +
                    "\nWind Heading && Strength: N/A" + " Newtons" +
                    "\nSpeed: N/A " +
                    "\nBoat Heading: N/A" +
                    "\nBoat Pos: N/A" +
                    "\nGoal Pos: N/A";
            }
        }
    }
}