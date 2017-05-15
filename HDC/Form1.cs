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
        static bool debug = true, connected = false, anchorState;
        int serverPort;
        Thread sampleThread;
        static Client simAPI = new Client();
        SailAI seaFire = new SailAI(ref simAPI, debug);

        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e) {
            lbl_boatStatus.Text = "\nConnected: " +
                    "\nAnchor: " +
                    "\nWind Heading && Strength: " + " N" +
                    "\nSpeed:  " +
                    "\nBoat Heading: " +
                    "\nBoat Pos: " +
                    "\nGoal Pos: ";
            Thread sampleThread = new Thread(delegate () {
                this.statusStrip1.Invoke (new MethodInvoker(delegate () {
                    timer_UIUpdate.Start();
                    //timer_roboTick.Start();
                }));
            });

            sampleThread.Start();
            
        }
 /*       public void drawGrid() {
            Bitmap bmp = new Bitmap(pbox_Grid.Width, pbox_Grid.Height);
            pbox_Grid.Image = bmp;
            Console.WriteLine(pbox_Grid.Size);
            using (Graphics g = Graphics.FromImage(bmp)) {
                Size size = new Size(10, 10);
                String[] asdf = sailUtils.getStatus(ref simAPI, "boatPosition").Split(',');
                int[] coords = { int.Parse(asdf[0]), int.Parse(asdf[1])};
                Point location = new Point(coords[0],coords[1]);
                Rectangle rectangle = new Rectangle(location, size);
                g.Clear(Color.White);
                
                float cellSize = 80.5f;
                using (Pen pen = new Pen(Color.Black)) {
                    for (int y = 0; y < 5; ++y) {
                        g.DrawLine(pen, 0, y * cellSize, 10 * cellSize, y * cellSize);
                    }

                    for (int x = 0; x < 5; ++x) {
                        g.DrawLine(pen, x * cellSize, 0, x * cellSize, 10 * cellSize);
                    }
                    g.DrawEllipse(pen, rectangle);
                }
                PointF shipCoords = sailUtils.getPoints(ref simAPI, "boatPosition");

            }
        }*/
        public void updateStatus() {
            if (connected) {
                lbl_boatStatus.Text = "Status:" +
                    "\nConnected: " + connected +
                    "\nAnchor: " + sailUtils.getStatus(ref simAPI, "anchor") +
                    "\nWind Heading && Strength: " + sailUtils.getStatus(ref simAPI, "windHeading") + "°  " + sailUtils.getStatus(ref simAPI, "windStrength") + " N" +
                    "\nSpeed: " + sailUtils.getStatus(ref simAPI, "boatSpeed") +
                    "\nBoat Heading: " + sailUtils.getStatus(ref simAPI, "boatHeading") +
                    "\nBoat Pos: " + sailUtils.getStatus(ref simAPI, "boatPosition") +
                    "\nGoal Pos: " + sailUtils.getStatus(ref simAPI, "goalPosition");
            } else {
                lbl_boatStatus.Text = "Status:" +
                    "\nConnected: " + connected + 
                    "\nAnchor: N/A" +
                    "\nWind Heading && Strength: N/A" + " N" +
                    "\nSpeed: N/A " +
                    "\nBoat Heading: N/A" +
                    "\nBoat Pos: N/A" +
                    "\nGoal Pos: N/A";
            }
        }

        private void btn_connect_Click(object sender, EventArgs e) {
            serverHost = txtbx_Host.Text == "" ? "sim.sailsim.org" : txtbx_Host.Text;
            serverPort = txtbx_port.Text == "" ? 20170 : int.Parse(txtbx_port.Text);
            username = txtbx_uName.Text == "" ? "SeaFire" : txtbx_uName.Text;
            password = txtbx_passwd.Text == "" ? "possum" : txtbx_passwd.Text;
            if (!connected) {
                connected = simAPI.connect(serverHost, serverPort, username, password);
                //drawGrid();
                /** Check whether the connection was successful */
                if (connected) {
                    updateStatus();
                    if (debug) {
                        Console.WriteLine("Connected to server");
                        simAPI.Verbose = true;
                    }
                    //Console.WriteLine(sailUtils.send(ref simAPI, "obstacle", "1")[1]);
                    seaFire.start();
                } else {
                    updateStatus();
                    if (debug)
                        Console.WriteLine("Something went wrong");

                }
                sampleThread = new Thread(delegate ()

                {
                    // Invoke your control like this
                    this.statusStrip1.Invoke(new MethodInvoker(delegate ()
                    {
                        //timer_UIUpdate.Start();
                    }));
                });
                sampleThread.Start();
            }
        }
        private void btn_discon_Click(object sender, EventArgs e) {
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

        private void timer_UIUpdate_Tick(object sender, EventArgs e) { updateStatus(); }

        private void timer_robotTick_Tick(object sender, EventArgs e) {
            seaFire.tick();
        }

        private void drpdwn_Debug_Click(object sender, EventArgs e) { debug = debug == false ? true : false; }

        private void btn_scan_Click(object sender, EventArgs e) {
            simAPI.send("obstacleScan");
            simAPI.receive();
        }
        private void btn_quit_Click(object sender, EventArgs e) {
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
            sailUtils.anchorToggle(ref simAPI, anchorState);
            timer_UIUpdate.Start();
            updateStatus();

        }
    }
}