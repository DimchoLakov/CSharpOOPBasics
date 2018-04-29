using System;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main()
        {
            var storageMaster = new Core.StorageMaster();
            var engine = new Engine(storageMaster);
            engine.Run();
        }
    }
}
