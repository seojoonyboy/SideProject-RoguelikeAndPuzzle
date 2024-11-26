using System.Collections;
using System.Collections.Generic;

namespace Common.Util.DataLoader
{
    public abstract class DataLoader
    {
        public abstract void Load();
    }

    public class JsonLoader : DataLoader
    {
        public override void Load()
        {
        
        }
    }
}