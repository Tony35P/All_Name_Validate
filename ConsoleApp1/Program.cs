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

        }
        public interface IValidator
        {
            bool IsValid(string value);
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
