using StorageMaster.Core;
using System;

namespace StorageMaster
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            Core.StorageMaster storageMaster = new Core.StorageMaster();
            var engine = new Engine(storageMaster);
            engine.Run();
      
        }
    }
}
