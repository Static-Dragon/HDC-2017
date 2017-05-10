using NavInterfaceClient;
using System;

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
                        coords[i] = double.Parse(tmp[i]);
                        coords[i] = Math.Truncate(coords[i] * 100) / 100;
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

    }
}
