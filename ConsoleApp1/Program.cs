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
            };

            var member = new Member { Validators = validators };
            member.Name = null;
            Console.WriteLine(member.Name);

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
