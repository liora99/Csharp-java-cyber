using System;
using System.Text;
using Intel.Dal;


namespace project_fHost
{
    public delegate void del(string password);
    public delegate Data del1(string a);
    public delegate void del2(string a , string b, string c);
    public delegate void del3();
    public delegate void del4(string pass);


    public class Program
    {
        private static string DATA = "";
        private static bool FLAG_LOGIN = false;
        public del4 getPrivateMethods4 { get { return new del4(set); } }
        private static void set(string password)
        {
            Jhi.DisableDllValidation = true;

            Jhi jhi = Jhi.Instance;
            JhiSession session;

            // This is the UUID of this Trusted Application (TA).
            //The UUID is the same value as the applet.id field in the Intel(R) DAL Trusted Application manifest.
            string appletID = "305a5eb1-30ff-4a2c-9bb2-b3a5453e6916";
            // This is the path to the Intel Intel(R) DAL Trusted Application .dalp file that was created by the Intel(R) DAL Eclipse plug-in.
            string appletPath = "C:\\Workdal\\project_f\\bin\\project_f.dalp";

            // Install the Trusted Application
            Console.WriteLine("Installing the applet.");
            jhi.Install(appletID, appletPath);

            // Start a session with the Trusted Application
            byte[] initBuffer = new byte[] { }; // Data to send to the applet onInit function
            Console.WriteLine("Opening a session.");
            jhi.CreateSession(appletID, JHI_SESSION_FLAGS.None, initBuffer, out session);

            byte[] sendBuff = UTF32Encoding.UTF8.GetBytes("Hello"); // A message to send to the TA
            byte[] recvBuff = new byte[2000]; // A buffer to hold the output data from the TA
            int responseCode; // The return value that the TA provides using the IntelApplet.setResponseCode method
            //Console.WriteLine("Enter a password please: ");
            string p = password;
            sendBuff = UTF32Encoding.UTF8.GetBytes(p);
            jhi.SendAndRecv2(session, 0, sendBuff, ref recvBuff, out responseCode);



        }
        public del3 getPrivateMethods3 { get { return new del3(logout); } }
        private static void logout()
        {
            Jhi.DisableDllValidation = true;

            Jhi jhi = Jhi.Instance;
            JhiSession session;

            // This is the UUID of this Trusted Application (TA).
            //The UUID is the same value as the applet.id field in the Intel(R) DAL Trusted Application manifest.
            string appletID = "305a5eb1-30ff-4a2c-9bb2-b3a5453e6916";
            // This is the path to the Intel Intel(R) DAL Trusted Application .dalp file that was created by the Intel(R) DAL Eclipse plug-in.
            string appletPath = "C:\\Workdal\\project_f\\bin\\project_f.dalp";

            // Install the Trusted Application
            Console.WriteLine("Installing the applet.");
            jhi.Install(appletID, appletPath);

            // Start a session with the Trusted Application
            byte[] initBuffer = new byte[] { }; // Data to send to the applet onInit function
            Console.WriteLine("Opening a session.");
            jhi.CreateSession(appletID, JHI_SESSION_FLAGS.None, initBuffer, out session);

            byte[] sendBuff = UTF32Encoding.UTF8.GetBytes("Hello"); // A message to send to the TA
            byte[] recvBuff = new byte[2000]; // A buffer to hold the output data from the TA
            int responseCode; // The return value that the TA provides using the IntelApplet.setResponseCode method
            jhi.SendAndRecv2(session, 4, sendBuff, ref recvBuff, out responseCode);
            int resultlogout = BitConverter.ToInt32(recvBuff, 0);
            if (resultlogout == 1)
            {
                Program.FLAG_LOGIN = false;
            }
        }

        public del getPrivateMethods { get { return new del(login); } }
        //public static JhiSession session;
        //public static Jhi jhi;

  

        private static void login( string password)
        {
            Jhi.DisableDllValidation = true;

            Jhi jhi = Jhi.Instance;
            JhiSession session;

            // This is the UUID of this Trusted Application (TA).
            //The UUID is the same value as the applet.id field in the Intel(R) DAL Trusted Application manifest.
            string appletID = "305a5eb1-30ff-4a2c-9bb2-b3a5453e6916";
            // This is the path to the Intel Intel(R) DAL Trusted Application .dalp file that was created by the Intel(R) DAL Eclipse plug-in.
            string appletPath = "C:\\Workdal\\project_f\\bin\\project_f.dalp";

            // Install the Trusted Application
            Console.WriteLine("Installing the applet.");
            jhi.Install(appletID, appletPath);

            // Start a session with the Trusted Application
            byte[] initBuffer = new byte[] { }; // Data to send to the applet onInit function
            Console.WriteLine("Opening a session.");
            jhi.CreateSession(appletID, JHI_SESSION_FLAGS.None, initBuffer, out session);
            byte[] sendBuff = UTF32Encoding.UTF8.GetBytes("Hello"); // A message to send to the TA
            byte[] recvBuff = new byte[2000]; // A buffer to hold the output data from the TA
            int responseCode; // The return value that the TA provides using the IntelApplet.setResponseCode method
                              // Console.WriteLine("please enter the password the login: ");
                              //string logingp = Console.ReadLine();
            string logingp = password;
            sendBuff = UTF32Encoding.UTF8.GetBytes(logingp);
            jhi.SendAndRecv2(session, 1, sendBuff, ref recvBuff, out responseCode);
            int resultlog = BitConverter.ToInt32(recvBuff, 0);
            if (resultlog > 0)
            {
                Console.WriteLine("login succeful" + "\n" + "opening session...");
                Program.FLAG_LOGIN = true;
            }
            else
                Console.WriteLine("error, wrong password!" + "\n" + "try again..");

        
        }
        public del1 getPrivateMethods1 { get { return new del1(getdata); } }
        private static Data getdata(string address)       //quand on appelle getdata on doit prendre l'adresse qu'on a tape dans la fenetre d'avant google
        {
            Jhi.DisableDllValidation = true;

            Jhi jhi = Jhi.Instance;
            JhiSession session;

            // This is the UUID of this Trusted Application (TA).
            //The UUID is the same value as the applet.id field in the Intel(R) DAL Trusted Application manifest.
            string appletID = "305a5eb1-30ff-4a2c-9bb2-b3a5453e6916";
            // This is the path to the Intel Intel(R) DAL Trusted Application .dalp file that was created by the Intel(R) DAL Eclipse plug-in.
            string appletPath = "C:\\Workdal\\project_f\\bin\\project_f.dalp";

            // Install the Trusted Application
            Console.WriteLine("Installing the applet.");
            jhi.Install(appletID, appletPath);

            // Start a session with the Trusted Application
            byte[] initBuffer = new byte[] { }; // Data to send to the applet onInit function
            Console.WriteLine("Opening a session.");
            jhi.CreateSession(appletID, JHI_SESSION_FLAGS.None, initBuffer, out session);
            byte[] sendBuff = UTF32Encoding.UTF8.GetBytes("Hello"); // A message to send to the TA
            byte[] recvBuff = new byte[2000]; // A buffer to hold the output data from the TA
            int responseCode; // The return value that the TA provides using the IntelApplet.setResponseCode method

            // Console.WriteLine("Enter the address please: ");
            //string a = Console.ReadLine();
            string a = address;
            sendBuff = UTF32Encoding.UTF8.GetBytes(a);
            jhi.SendAndRecv2(session, 6, sendBuff, ref recvBuff, out responseCode);
            string resultdata = UTF32Encoding.UTF8.GetString(recvBuff);
            int k = 0;
            string p = "";
            string n = "";
            bool f = false;
            resultdata = Program.DATA;


            if (Program.DATA != "")
            {
                for (int i = 0; i < resultdata.Length; i++)
                {
                    if (resultdata[i] == '#')
                    {
                        i++;
                        while (k < a.Length && resultdata[i] == a[k])
                        {
                            i++;
                            k++;

                        }
                        if (resultdata[i] == '$')
                        {
                            i++;
                            Console.WriteLine("password: ");
                            while (resultdata[i] != '%')
                            {

                                p = p + resultdata[i];
                                i++;

                            }


                            Console.WriteLine("name: ");
                            i++;
                            while (i < resultdata.Length && resultdata[i] != '#')
                            {
                                n = n + resultdata[i];
                                i++;
                            }

                            Console.WriteLine("");
                            f = true;
                            Data d = new Data(a, n, p);
                            return d;   

                        }
                       
                    }
                    if (f)
                    {
                        Data d = new Data(a, n, p);
                        return d;
                    }
                }
              

                //rajouter une liste de data qui contient dedans chaque p et chaque n 
                if (!f)
                {
                    Console.WriteLine("the url don't exist!");
                    return null;
                }
                else
                {
                    Data d = new Data(a, n, p);
                    return d;
                }
            }

            else
            {
                Console.WriteLine("the url don't exist!");
                return null;
            }

        }

        public del2 getPrivateMethods2 { get { return new del2(setaddress); } }

        private static void setaddress(string a , string b , string c)
        {
            Jhi.DisableDllValidation = true;

            Jhi jhi = Jhi.Instance;
            JhiSession session;

            // This is the UUID of this Trusted Application (TA).
            //The UUID is the same value as the applet.id field in the Intel(R) DAL Trusted Application manifest.
            string appletID = "305a5eb1-30ff-4a2c-9bb2-b3a5453e6916";
            // This is the path to the Intel Intel(R) DAL Trusted Application .dalp file that was created by the Intel(R) DAL Eclipse plug-in.
            string appletPath = "C:\\Workdal\\project_f\\bin\\project_f.dalp";

            // Install the Trusted Application
            Console.WriteLine("Installing the applet.");
            jhi.Install(appletID, appletPath);

            // Start a session with the Trusted Application
            byte[] initBuffer = new byte[] { }; // Data to send to the applet onInit function
            Console.WriteLine("Opening a session.");
            jhi.CreateSession(appletID, JHI_SESSION_FLAGS.None, initBuffer, out session);
            byte[] sendBuff = UTF32Encoding.UTF8.GetBytes("Hello"); // A message to send to the TA
            byte[] recvBuff = new byte[2000]; // A buffer to hold the output data from the TA
            int responseCode; // The return value that the TA provides using the IntelApplet.setResponseCode method
            if (Program.FLAG_LOGIN)
            {
 
                string data = '#' + a + '$' + b + '%' + c;
                Program.DATA = Program.DATA + data;

                sendBuff = UTF32Encoding.UTF8.GetBytes(data);
                jhi.SendAndRecv2(session, 5, sendBuff, ref recvBuff, out responseCode);

                Console.WriteLine(Program.DATA);
               

            }
            else
                Console.WriteLine("you need to login");
           

           
        }
  
        static void Main(string[] args)
        {
#if AMULET
            // When compiled for Amulet the Jhi.DisableDllValidation flag is set to true 
			// in order to load the JHI.dll without DLL verification.
            // This is done because the JHI.dll is not in the regular JHI installation folder, 
			// and therefore will not be found by the JhiSharp.dll.
            // After disabling the .dll validation, the JHI.dll will be loaded using the Windows search path
			// and not by the JhiSharp.dll (see http://msdn.microsoft.com/en-us/library/7d83bc18(v=vs.100).aspx for 
			// details on the search path that is used by Windows to locate a DLL) 
            // In this case the JHI.dll will be loaded from the $(OutDir) folder (bin\Amulet by default),
			// which is the directory where the executable module for the current process is located.
            // The JHI.dll was placed in the bin\Amulet folder during project build.
            Jhi.DisableDllValidation = true;
#endif

            Jhi jhi = Jhi.Instance;
            JhiSession session;

            // This is the UUID of this Trusted Application (TA).
            //The UUID is the same value as the applet.id field in the Intel(R) DAL Trusted Application manifest.
            string appletID = "305a5eb1-30ff-4a2c-9bb2-b3a5453e6916";
            // This is the path to the Intel Intel(R) DAL Trusted Application .dalp file that was created by the Intel(R) DAL Eclipse plug-in.
            string appletPath = "C:\\Workdal\\project_f\\bin\\project_f.dalp";

            // Install the Trusted Application
            Console.WriteLine("Installing the applet.");
            jhi.Install(appletID, appletPath);

            // Start a session with the Trusted Application
            byte[] initBuffer = new byte[] { }; // Data to send to the applet onInit function
            Console.WriteLine("Opening a session.");
            jhi.CreateSession(appletID, JHI_SESSION_FLAGS.None, initBuffer, out session);

            // Send and Receive data to/from the Trusted Application
             // The ID of the command to be performed by the TA

      /*      while (cmdId < 6)
            {
                switch (cmdId)
                {
                    case 0:
                        Program.set(cmdId, session, jhi);
                        break;
                    case 1:
                        Program.login(cmdId, session, jhi);
                        break;
                    case 2:
                        Program.res(cmdId, session, jhi);
                        break;
                    case 3:
                        Program.get(cmdId, session, jhi);
                        break;
                    case 4:
                        Program.logout(cmdId, session, jhi);
                        break;
                    case 5:
                        Program.setaddress(cmdId, session, jhi);
                        break;

                    default:

                        break;
                }
                
                Console.WriteLine(" 1-loging \n 2-rest \n 3- get account \n 4-log out \n 5-address \n else- exit");
                cmdId = int.Parse(Console.ReadLine());
            }
            */
            Console.WriteLine("bye bye!");


            // Close the session
            Console.WriteLine("Closing the session.");
            jhi.CloseSession(session);

            //Uninstall the Trusted Application
            Console.WriteLine("Uninstalling the applet.");
            jhi.Uninstall(appletID);

            Console.WriteLine("Press Enter to finish.");
            Console.Read();
        }
    }
}
