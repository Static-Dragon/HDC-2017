using NavInterfaceClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HDC {
    public class sailUtils {
        public static string getStatus(ref Client simAPI, String message) {
            simAPI.send(message);
            String data = simAPI.receive()[1];
            switch (message) {
                case "boatPosition":
                case "goalPosition": //Trying to round the coordinates to 2 decimal places, but my for loop only acts on coords[0]; FIXED!
                    double[] coords = new double[2];
                    String[] tmp = data.Split();
                    for (int i = 0; i < coords.Length; i++) {
                        coords[i] = Math.Truncate(double.Parse(tmp[i]) * 100 / 100);
                        tmp[i] = coords[i].ToString();
                    }
                    return string.Join(" , ", tmp);
                default:
                    double s = 0;
                    if (double.TryParse(data, out s)) {
                        //s = Math.Round(double.Parse(data), 2);
                        //return s.ToString();
                        return Math.Round(double.Parse(data), 2).ToString();
                    } else {
                        return data;
                    }
            };
        }
        public static string[] send(ref Client simAPI, String subject, String message) {
            simAPI.send(subject + message);
            return simAPI.receive();
        }
        public static string[] send(ref Client simAPI, String subject) {
            simAPI.send(subject);
            return simAPI.receive();
        }

        public static PointF getPoints(ref Client simAPI, String obj) {
            String[] cArray = getStatus(ref simAPI, obj).Split(',');
            float[] cFloat = new float[2];
            for (int i = 0; i != cArray.Length; i++) {
                cFloat[i] = float.Parse(cArray[i]);
            }
            return new PointF(cFloat[0], cFloat[1]);
        }
        public static void anchorToggle(ref Client simAPI, bool state) {
            if (state == false && getStatus(ref simAPI, "anchor") == "true") {
                send(ref simAPI, "anchor", "false");
            }
            if (state == true && getStatus(ref simAPI, "anchor") == "false") {
                send(ref simAPI, "anchor", "true");
            }
        }
        public static void turnBoatLeft(ref Client simAPI) {
            String[] msg;
            try {
                /*simAPI.send("boatHeading");
                msg = simAPI.receive();*/
                msg = send(ref simAPI, "boatHeading");
                double xd = Double.Parse(msg[1]);

                msg = send(ref simAPI, "boatHeading " + (xd - 10));


            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
        public static void turnBoatRight(ref Client simAPI) {
            String[] msg;
            try {
                //simAPI.send("boatHeading");
                msg = send(ref simAPI, "boatHeading");
                //msg = simAPI.receive();
                double xd = Double.Parse(msg[1]);

                //simAPI.send("boatHeading " + (xd + 10));
                //msg = simAPI.receive();
                msg = send(ref simAPI, "boatHeading " + (xd + 10));
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
        public static void faceDirection(ref Client simAPI,double x2,double y2) {
            String[] msg;
            String[] msg2;
            try {
                msg = send(ref simAPI, "boatPosition");
                msg2 = msg[1].Split(' ');

                double x1 = Double.Parse(msg2[0]);
                double y1 = Double.Parse(msg2[1]);

                double degrees = RadianToDegree(Math.Atan2(y2 - y1, x2 - x1));
                if (degrees < 0) {
                    degrees += 360;
                }
                degrees = (450 - degrees) % 360;
                Console.WriteLine("\n\nDegrees = %f", degrees);
                msg = send(ref simAPI, "boatHeading " + degrees);

            } catch (Exception e) {
                // TODO Auto-generated catch block
                Console.WriteLine(e);
            }
        }
        public static void receiveHeading(ref Client simAPI, Label statusLabel) {
            try {
                /*
                simAPI.send("windHeading");
                String[] msgs = simAPI.receive();
                */
                String[] msgs = send(ref simAPI, "windHeading");
                statusLabel.Text = msgs[0] + " " + msgs[1];
            } catch (System.IO.IOException e1) {
                Console.WriteLine(e1);
            }
           

        }
        private static double RadianToDegree(double angle) {
            return angle * (180.0 / Math.PI);
        }
    }
}