using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Puzzle.Util
{
    public class Genesis
    {
        public UInt32 row;
        public UInt32 col;
        
        public Genesis(){ }
        
        public Genesis(JObject obj)
        {
                
        }
    }
}

