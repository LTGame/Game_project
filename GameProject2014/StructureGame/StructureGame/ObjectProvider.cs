using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureGame
{
    public class ObjectProvider
    {
        Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();

        public void Add(string id,GameObject obj)
        {
            dict.Add(id, obj);
        }

        public GameObject getObject(String id)
        {
            if (dict.ContainsKey(id))
            {
                return dict[id];
            }
            return null;
        }
        public List<String> getKeys()
        {
            return dict.Keys.ToList();
        }
    }
}
