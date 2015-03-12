using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII.Test
{
    public class DynDictTest : Test
    {
        public override string Id
        {
            get { return "dydict"; }
        }

        public override void Prepare()
        {
            AddAction(InvokeDynamic);
            AddAction(InvokeDictionary);
            AddAction(InvokeKVP);
        }

        public void InvokeDynamic()
        {
            var e = CallDynamic3(new { Value = 0L });
            long v = e.Value;
        }

        public void InvokeDictionary()
        {
            var dict = new Dictionary<string, long>();
            dict["Value"] = 0L;
            dict = CallDictionary3(dict);
            long v = dict["Value"];
        }

        public void InvokeKVP() 
        {
            var kvp = new KeyValuePair<string, long>("Value", 0L);
            kvp = CallKVP(kvp);
            long v = kvp.Value;
        }

        private dynamic CallDynamic1(dynamic test)
        {
            int v = test.Value;
            v++;
            return new { Value = v };
        }

        private Dictionary<string, object> CallDictionary1(
            Dictionary<string, object> test)
        {
            int v = (int)test["Value"];
            v++;
            var dict = new Dictionary<string, object>();
            dict["Value"] = v;
            return dict;
        }

        private dynamic CallDynamic2(dynamic test)
        {
            int v1 = test.Value1;
            long v2 = test.Value2;
            float v3 = test.Value3;
            double v4 = test.Value4;
            string v5 = test.Value5;
            v1++;
            v2++;
            v3++;
            v4++;
            v5 += "test";
            return new { Value1 = v1, Value2 = v2, Value3 = v3, Value4 = v4, Value5 = v5 };
        }

        private Dictionary<string, object> CallDictionary2(
            Dictionary<string, object> test)
        {
            int v1 = (int)test["Value1"];
            long v2 = (long)test["Value2"];
            float v3 = (float)test["Value3"];
            double v4 = (double)test["Value4"];
            string v5 = (string)test["Value5"];
            v1++;
            v2++;
            v3++;
            v4++;
            v5 += "test";
            var dict = new Dictionary<string, object>();
            dict["Value1"] = v1;
            dict["Value2"] = v2;
            dict["Value3"] = v3;
            dict["Value4"] = v4;
            dict["Value5"] = v5;
            return dict;
        }

        private dynamic CallDynamic3(dynamic test)
        {
            long v = test.Value;
            v++;
            return new { Value = v };
        }

        private Dictionary<string, long> CallDictionary3(
            Dictionary<string, long> test)
        {
            long v = test["Value"];
            v++;
            var dict = new Dictionary<string, long>();
            dict["Value"] = v;
            return dict;
        }

        private KeyValuePair<string, long> CallKVP(
            KeyValuePair<string, long> test)
        {
            return new KeyValuePair<string, long>(test.Key, test.Value + 1);
        }
    }
}
