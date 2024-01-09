using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Codebase_application.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Task()
        {
            var reverse = ReverseStringProgram();
            ViewBag.ReverseString = reverse;

            var secondNumber = SecondLargestNumberProgram();
            ViewBag.SecondLageNumber = secondNumber;

            var naturalNumber = FindNaturalNumbers();
            ViewBag.NaturalNumber = naturalNumber;

            return View();
        }

        public static int FindNaturalNumbers()
        {
            int inputValue, sum = 0;
            for (inputValue = 1; inputValue <= 10; inputValue++)
            {
                sum = sum + inputValue;
            }
            return sum;
        }

        public static int SecondLargestNumberProgram()
        {
            int[] inputValue = new int[] { 20, 30, 12, 45, 9 };
            int value1 = int.MinValue;
            int value2 = int.MinValue;
            foreach (int i in inputValue)
            {
                if (i > value1)
                {
                    value2 = value1;
                    value1 = i;
                }
                else if (i > value2)
                    value2 = i;
            }
            return value2;
        }

        public static string ReverseStringProgram()
        {
            string inputValue = "Hello World";
            char[] charArray = inputValue.ToCharArray();
            for (int i = 0, j = inputValue.Length - 1; i < j; i++, j--)
            {
                charArray[i] = inputValue[j];
                charArray[j] = inputValue[i];
            }
            string outputValue = new string(charArray);
            return outputValue;
        }
    }
}