using NavInterfaceClient;
using System;
using System.Drawing;

namespace HDC {
    public class sailUtils {
        public static string getStatus (ref Client simAPI, String message) {
            simAPI.send(message);
            String data = simAPI.receive()[1];
            switch (message) {
                case "boatPosition":
                case "goalPosition": //Trying to round the coordinates to 2 decimal places, but my for loop only acts on coords[0]; FIXED!
                    double[] coords = new double[2];
                    String[] tmp = data.Split();
                    for (int i = 0; i < coords.Length; i++) {
                        coords[i] = Math.Truncate(double.Parse (tmp[i]) * 100 / 100);
                        tmp[i] = coords[i].ToString();
                    }
                    return string.Join(" , ", tmp);
                default:
                    double s = 0;
                    if (double.TryParse(data, out s)) {
                        s = Math.Round(double.Parse(data), 2);
                        return s.ToString();
                    } else {
                        return data;
                    }
            };
        }
        public static string[] send (ref Client simAPI, String subject, String message) {
            simAPI.send (subject, message);
            return simAPI.receive ();
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
        public static void anchorToggle(ref Client simAPI,bool state) {
            if (state == false && getStatus(ref simAPI, "anchor") == "true") {
                send(ref simAPI, "anchor", "false");
            }
            if (state == true && getStatus(ref simAPI, "anchor") == "false") {
                send(ref simAPI, "anchor", "true");
            }
        }
    }

}
