/*
* Tencent is pleased to support the open source community by making Puerts available.
* Copyright (C) 2020 THL A29 Limited, a Tencent company.  All rights reserved.
* Puerts is licensed under the BSD 3-Clause License, except for the third-party components listed in the file 'LICENSE' which may be subject to their corresponding license terms. 
* This file is subject to the terms and conditions defined in file 'LICENSE', which is part of this source code package.
*/

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Puerts.UnitTest
{
    public struct S
    {
        int age;
        string name;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public S(int i, string j) : this()
        {
            Age = i;
            Name = j;
        }
        public string TestParamObj(DerivedClass obj)
        {
            obj.baseIntField = 111;
            return obj.TestVirt(Age, Name);
        }
    }
    public class BaseClass
    {
        public int baseIntField = 10;
        public static string baseStringField = " base-static-field ";
        public virtual string TestVirt(int a, string str)
        {
            return str + a;
        }
        public virtual string TestBaseVirt()
        {
            return "base print" + baseStringField;
        }
    }

    public class DerivedClass : BaseClass
    {
        public int Id(int x)
        {
            return x;
        }
        public override string TestVirt(int a, string str)
        {
            return str + a * 10 + " " + baseIntField;
        }

        public override string TestBaseVirt()
        {
            baseStringField = " fixed-base-static-field ";
            return base.TestBaseVirt();
        }

        public class Inner
        {
            public int A = 100;

            public int Add(int a, int b)
            {
                return a + b;
            }
            public static void Sub(int a, int b, out int c)
            {
                c = a - b;
            }
        }

        public bool IsStringNull(string str)
        {
            return str == null;
        }

        public long Long(long l)
        {
            return l;
        }
        public string PrintStruct(S s)
        {
            s.Age = 20;
            return ("name : " + s.Name + " , age : " + s.Age);
        }

        public string PrintStructRef(ref S s)
        {
            s.Age = 20;
            return ("name : " + s.Name + " , age : " + s.Age);
        }


        public int Adds(int a, int b)
        {
            return (a + b);
        }
        public string Adds(string a, string b)
        {
            return (a + b);
        }

        public int TestList(List<int> list)
        {
            int sum = 0;
            foreach (var i in list)
            {
                sum += i;
            }
            return sum;
        }

        public string TryCatchFinally(bool bThrow, ref bool t, ref bool c, ref bool f, ref bool e)
        {
            string s = "";
            try
            {
                if (bThrow)
                {
                    throw new Exception();
                }
                s += "t";
                t = true;
            }
            catch
            {
                s += "c";
                c = true;
            }
            finally
            {
                s += "f";
                f = true;
            }
            s += "e";
            e = true;
            return s;
        }

        public string CatchByNextLevel(out bool f1, out bool f2, out bool f3)
        {
            string res = "";
            f1 = f2 = f3 = false;
            try
            {
                res += "try";
                try
                {
                    res += "-try";
                    throw new Exception();
                }
                finally
                {
                    res += "-finally";
                    f1 = true;
                }
            }
            catch
            {
                res += "-catch";
                f2 = true;
            }
            finally
            {
                res += "-finally";
                f3 = true;
            }
            return res;
        }

        public int TestListRange(List<int> l, int i)
        {
            return l[i];
        }

        public string TestDefaultParam(int i = 1, string s = "str")
        {
            return i + s;
        }
    }

    public delegate string MyCallBack(string str);

    public class EventTest
    {
        public MyCallBack myCallBack;
        public event MyCallBack myEvent;
        public static event MyCallBack myStaticEvent;

        public string Trigger()
        {
            string res = "start ";
            if (myCallBack != null)
            {
                res += myCallBack(" delegate ");
            }
            if (myEvent != null)
            {
                res += myCallBack(" event ");
            }
            if (myStaticEvent != null)
            {
                res += myCallBack(" static-event ");
            }
            res += " end";
            return res;
        }
    }

    public class JsObjectTest
    {
        public GenericDelegate Getter;

        public GenericDelegate Setter;

        public void SetSomeData()
        {
            Setter.Action("a", 1);
            Setter.Action("b.a", "aabbcc");
        }

        public void GetSomeData()
        {
            Assert.AreEqual(1, Getter.Func<string, int>("a"));
            Assert.AreEqual("aabbcc", Getter.Func<string, string>("b.a"));
        }
    }

    public class ArrayTest
    {
        public int[] a0 = new int[] { 7, 8, 9 };

        public float[] a1 = new float[] { 7, 8, 9 };

        public double[] a2 = new double[] { 7, 8, 9 };

        public long[] a3 = new long[] { 7, 8, 9 };

        public ulong[] a4 = new ulong[] { 7, 8, 9 };

        public sbyte[] a5 = new sbyte[] { 7, 8, 9 };

        public short[] a6 = new short[] { 7, 8, 9 };

        public ushort[] a7 = new ushort[] { 7, 8, 9 };

        public char[] a8 = new char[] { (char)7, (char)8, (char)9 };

        public uint[] a9 = new uint[] { 7, 8, 9 };

        public bool[] ab = new bool[] { true, false, true, false };

        public string[] astr = new string[] { "hello", "john" };
    }

    public abstract class Abs
    {
        public int age = 23;
        public abstract void TestRef(ref string name, out string res);
    }

    public class C : Abs
    {
        public override void TestRef(ref string name, out string res)
        {
            res = name + age;
            name = "anna";
        }
    }

    interface IA
    {
        bool running { get; }

        string TestObj(BaseClass obj, int a, string b);

        string TestArr(char[] arr);
    }


    public class ISubA : IA
    {

        public char[] a8 = new char[] { (char)(7 + '0'), (char)(8 + '0'), (char)(9 + '0') };
        public bool running
        {
            get
            {
                return true;
            }
        }

        public string TestObj(BaseClass obj, int a, string b)
        {
            return obj.TestVirt(a, b);
        }

        public string TestArr(char[] arr)
        {
            string sum = "";
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

    }
}