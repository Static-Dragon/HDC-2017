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
            triangles();
            aikappa();
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
        private void aikappa() {
            String[] msg;
            try {
                double windHeading, boatHeading, goalAngle;
                msg = sailUtils.send(ref simAPI, "windHeading");
                /*
                simAPI.send("windHeading");
                msg = simAPI.receive();
                */
                Console.WriteLine(msg[1]);
                windHeading = Double.Parse(msg[1]);
                /*
                simAPI.send("boatHeading");
                msg = simAPI.receive();*/
                msg = sailUtils.send(ref simAPI, "boatHeading");
                Console.WriteLine(msg[1]);
                boatHeading = Double.Parse(msg[1]);
                double angle = 0;

                //double windHeadingNew = Math.Abs(windHeading + 540) % 360;
                goalAngle = boatHeading - Math.Abs(windHeading + 540) % 360;

                if (goalAngle < 0) {
                    goalAngle += 360;
                }

                /*angle = goalAngle > 0 && goalAngle < 180 ? angle = -(goalAngle * .5) :
                    goalAngle >= 180 ? (goalAngle %= 179) * .5 : 0.0; I wanted to try something w/ ternary, never doing this again */
                if (goalAngle > 0 && goalAngle < 180) {
                    angle = goalAngle * .5;
                    angle = -angle;
                } else if (goalAngle >= 180) {
                    goalAngle %= 179;
                    angle = goalAngle * .5;
                }
                if (goalAngle <= 30 && goalAngle >= 0) {
                    angle = 80;
                }
                if (goalAngle >= -30 && goalAngle < 0) {
                    angle = -80;
                }

                Console.WriteLine("\n\n%s", angle);
                simAPI.send("sailAngle " + (Double)angle);
                msg = simAPI.receive();
                simAPI.send("anchor False");

            } catch (Exception e) {
                Console.WriteLine("Exception in aikappa() \n" + e);
            }

        }


        private void triangles() {
            String[] boat;
            String[] goal;
            String[] msg;
            //String bx, by, gx, gy;
            Double TWOPI = 6.2831853071795865;
            Double RAD2DEG = 57.2957795130823209;
            try {
                boat = sailUtils.send(ref simAPI, "boatPosition");
                /*simAPI.send("boatPosition");
                boat = simAPI.receive();*/
                Console.WriteLine("\n\n%s = boat", boat[1]);
                String[] parts = boat[1].Split(' ');
                /*
                bx = parts[0];
                by = parts[1];
                */
                Console.WriteLine("\n\n%s = boat x", parts[0]);
                Console.WriteLine("\n\n%s = boat y", parts[1]);
                Double x1 = Double.Parse(parts[0]);
                Double y1 = Double.Parse(parts[1]);
                /*
                simAPI.send("goalPosition");
                goal = simAPI.receive();
                */
                goal = sailUtils.send(ref simAPI, "goalPosition");
                Console.WriteLine("\n\n%s = goal", goal[1]);
                String[] parts1 = goal[1].Split(' ');
                /*
                gx = parts1[0];
                gy = parts1[1];*/
                Console.WriteLine("\n\n%s = goal x", parts1[0]);
                Console.WriteLine("\n\n%s = goal y", parts1[1]);
                Double x2 = Double.Parse(parts1[0]);
                Double y2 = Double.Parse(parts1[1]);

                double theta = Math.Atan2((x2 - x1), (y2 - y1));
                if (theta < 0.0) theta += TWOPI;
                theta = RAD2DEG * theta;
                Console.WriteLine("\n\n%s = theta", theta);
                msg = sailUtils.send(ref simAPI, "boatHeading");
                /*simAPI.send("boatHeading");
                msg = simAPI.receive();*/
                Console.WriteLine("\n\n%s = boatheading", msg[1]);
                sailUtils.send(ref simAPI, "boatHeading", theta.ToString());
                /*simAPI.send("boatHeading", theta.ToString() );
                simAPI.receive();*/
                
            } catch (Exception e) {
                Console.WriteLine("Exception in triangles() \n" + e);
            }
        }
    }

}
