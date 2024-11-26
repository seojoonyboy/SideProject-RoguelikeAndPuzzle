using Newtonsoft.Json.Linq;

namespace Artistar.Puzzle.Core
{
    public class Base : System.Object
    {
        public virtual void CopyTo(Base b) 
        {
            throw new System.NotImplementedException();
        }

        // 데이터를 문자열로 만든다.
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        public virtual JObject ToJObject()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FromJObject(JObject obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
