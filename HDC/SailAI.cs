using NavInterfaceClient;
using System;

namespace HDC {
    public class SailAI {
        Client simAPI;
        bool debug;
        double[,] map = new double[2000,1500];

        public SailAI(ref Client SimAPI,bool debug) {
            this.simAPI = SimAPI;
            this.debug = debug;
        }
        public void start() {
            sailUtils.anchorToggle(ref simAPI, false);
        }
        public void tick() {
            Console.WriteLine("sail!");
            calcuAbsoAngle();
        }
        private double sailAngle() {
            /*double windHeadingorg;
            double angle = 0; // Example windHeading = 270;
            windHeadingorg = Math.Abs(windHeadingorg + 540) % 360; // Retrieves wind source
            double angleSub = boatHeading - windHeadingorg;*/
            /*
             *     if wind is coming from 90 and we want windHeading to be normalized to north
             *     boatHeading - windHeadingorg works.
             *     
             *     Ex. 
             *     boatHeading = 90;
             *     windHeading = 120;
             *     boatHeading - windHeading = -30;
             *     angleSub = -30; -> 330
             *     angleSub represents the angle relevant to the windHeading when normalized to north
             *     
             */
            /*
           if (angleSub < 0) {
               angleSub += 360;// if given -30 - transforms into -> 330
           }

           if (angleSub > 0 && angleSub < 180) {
               angle = angleSub * .5; // Formula to be adjusted. 
               angle = -angle;
           } else if (angleSub >= 180) {
               angleSub %= 180;
               angle = angleSub * .5;
           }
           return angle;*/
            return 0.0;
        }

        /*        private void mapPopulate() {
                    int obstacleCount = int.Parse(sailUtils.send(ref simAPI, "obstacleCount")[1]);

                     int[] obstacleSizes = new int[obstacleCount];
                     double[,] obstacleCoords = new double[obstacleCount, obstacleCount];
                     String[][] obstacles = new string[obstacleCount][];
                     for (int a = 0; a != obstacleCount; a++) {
                         obstacles[a] = sailUtils.send(ref simAPI, "obstacle", a.ToString());
                         String b = obstacles[a].ToString();
                         String[] c = b.Split(',');
                         obstacleCoords.SetValue(double.Parse(c[1]), 1, 1);
                         obstacleCoords.SetValue(double.Parse(c[2]), 1, 1);
                         obstacleSizes[a] = int.Parse(c[3]);
                     }
                     for(int i = 0; i != obstacleCount; i++) {
                         for (int x = -(obstacleSizes[i]/2); x != obstacleSizes[i] / 2; x++) {
                             for (int y = -(obstacleSizes[i] / 2); y != obstacleSizes[i] / 2; y++) {
                                 map.SetValue( (double)obstacleCoords.GetValue(x, 0) + x, x, 0);
                                 map.SetValue( (double)obstacleCoords.GetValue(0, y) + y, 0, y);
                                 Console.WriteLine(map[x, y]);
                             }
                         }
                     }
               }
               */
        private void calcuAbsoAngle() {
            String[] msg;
            try {
                double windHeadingorg, boatHeading, sailAngle;
                double[] windHeading = new double[2];
                simAPI.send("windHeading");
                msg = simAPI.receive();
                Console.WriteLine(msg[1]);
                windHeadingorg = Double.Parse(msg[1]);

                simAPI.send("sailAngle");
                msg = simAPI.receive();
                Console.WriteLine(msg[1]);
                sailAngle = Double.Parse(msg[1]);

                simAPI.send("boatHeading");
                msg = simAPI.receive();
                Console.WriteLine(msg[1]);
                boatHeading = Double.Parse(msg[1]);

                double angle = 0; // Example windHeading = 270;
                windHeadingorg = Math.Abs(windHeadingorg + 540) % 360; // Retrieves wind source
                double angleSub = boatHeading - windHeadingorg;
                /*
                 *     if wind is coming from 90 and we want windHeading to be normalized to north
                 *     boatHeading - windHeadingorg works.
                 *     
                 *     Ex. 
                 *     boatHeading = 90;
                 *     windHeading = 120;
                 *     boatHeading - windHeading = -30;
                 *     angleSub = -30; -> 330
                 *     angleSub represents the angle relevant to the windHeading when normalized to north
                 */

                if (angleSub < 0) {
                    angleSub += 360;// if given -30 - transforms into -> 330
                }

                if (angleSub > 0 && angleSub < 180) {
                    angle = angleSub * .5; // Formula to be adjusted. 
                    angle = -angle;
                } else if (angleSub >= 180) {
                    angleSub %= 179;
                    angle = angleSub * .5;
                }
                if (angle == 0) {
                    angle = 30;
                }

                msg = sailUtils.send(ref simAPI, "sailAngle" + (Double)(angle));


            } catch (Exception e) {
                Console.WriteLine(e);
            }

        }
    }

}
