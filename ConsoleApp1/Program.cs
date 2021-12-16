﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        public interface IValidator
        {
            bool IsValid(string value);
        }
        public class RequiredValidator : IValidator
        {
            public bool IsValid(string value)
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new Exception("必填");
                }
                else
                {
                    return true;
                }
            }
        }
        public class Member
        {
            // Name 的所有驗證規則
            public List<IValidator> Validators { get; set; }
            private string name;
            public string Name
            {
                get { return name; }
                set
                {
                    //todo驗證Name的正確性

                }

            }
        }
    }
}
