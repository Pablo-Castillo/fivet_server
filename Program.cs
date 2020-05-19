using System;


namespace Fivet.ZeroIce
{
    class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                using(Ice.Communicator communicator = Ice.Util.initialize(ref args))
                {
                    var adapter =
                        communicator.createObjectAdapterWithEndpoints("TheSystemAdapter", "default -h localhost -p 10000");
                    adapter.add(new TheSystemImpl(), Ice.Util.stringToIdentity("cl.ucn.disc.pdis.fivet.zeroice.model.TheSystem"));
                    adapter.activate();
                    communicator.waitForShutdown();
                }
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e); 
                return 1;               
            } 
            return 0;           
        }
    }

    class TheSystemImpl : model.TheSystemDisp_
    {
        public override long getDelay(long clientTime, Ice.Current current = null){
            return DateTime.Now.Ticks - clientTime;
        }
    }
}
