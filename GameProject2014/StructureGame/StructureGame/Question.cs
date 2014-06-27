using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructureGame
{
    public class Question
    {
        String statement;

        public String Statement
        {
            get { return statement; }
            set { statement = value; }
        }
        String _a;

        public String A
        {
            get { return _a; }
            set { _a = value; }
        }
        String _b;

        public String B
        {
            get { return _b; }
            set { _b = value; }
        }
        String _c;

        public String C
        {
            get { return _c; }
            set { _c = value; }
        }
        String _d;

        public String D
        {
            get { return _d; }
            set { _d = value; }
        }
        String answer;

        public String Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        public Question(String statement, String a, String b, String c, String d, String answer)
        {
            this.statement = statement;
            this._a = a;
            this._b = b;
            this._c = c;
            this._d = d;
            this.answer = answer;
        }
    }
}
