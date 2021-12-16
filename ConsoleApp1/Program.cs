using System;
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
            List<IValidator> validators = new List<IValidator>()
            {
                new RequiredValidator(),
                new MaxlengthValidator(12)
            };

            var member = new Member { Validators = validators };
            try
            {
                member.Name = "35435435435435464";
                Console.WriteLine(member.Name);
            }catch(Exception ex)
            {
                Console.WriteLine("Name錯誤, 原因: " + ex.Message);
            }
            

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
        public class MaxlengthValidator : IValidator
        {
            private readonly int maxlength;
            public MaxlengthValidator(int maxLength)
            {
                this.maxlength = maxLength;
            }
            public bool IsValid(string value)
            {
                if (string.IsNullOrEmpty(value)) return true;
                if (value.Length > maxlength)
                {
                    throw new Exception("長度不能超過" + maxlength);
                }

                return true;
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
                    foreach(IValidator validator in Validators)
                    {
                        if (validator.IsValid(value) == false) throw new Exception("沒通過驗證");
                    }
                    name = value;
                }

            }
        }
    }
}
