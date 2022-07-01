using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using linkedlist;
using TPP.Laboratory.Exam.Test.List;

namespace TPP.Laboratory.Exam.Test.Student
{
    [TestClass]
    public class StudentTest : TestList
    {

        public override dynamic GetList<T>()
        {
            LinkedList<T> list = new LinkedList<T>();

            return list;
        }
    }
}
