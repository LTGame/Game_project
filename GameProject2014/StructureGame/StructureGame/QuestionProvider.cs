using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace StructureGame
{
    public class QuestionProvider
    {
        List<Question> list = new List<Question>();
        Random rd = new Random();

        public void Load(String filename)
        {
            
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            XmlNode root = doc.ChildNodes[0];
            foreach (XmlNode node in root.ChildNodes)
            {
                string a = "", b = "", c = "", d = "";
                string statement = node.Attributes["statement"].Value;
                string answer = node.Attributes["answer"].Value;
                foreach (XmlNode snode in node.ChildNodes)
                {
                    if (snode.Name.Equals("A"))
                    {
                        a = snode.InnerText;
                    }
                    else if (snode.Name.Equals("B"))
                    {
                        b = snode.InnerText;
                    }
                    else if (snode.Name.Equals("C"))
                    {
                        c = snode.InnerText;
                    }
                    else
                    {
                        d = snode.InnerText;
                    }
                }
                list.Add(new Question(statement,a,b,c,d,answer));
            }
        }

        public Question getQuestion()
        {
            int i = rd.Next(list.Count);
            return list[i];
        }
    }
}
