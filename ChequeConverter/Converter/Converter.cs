using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ChequeConverter
{
    public class ChequeConverter : IConverter
    {
        public string NumberToWords(decimal number)
        {
            if (number > 999000000000 )
            {
                throw new ArgumentException("The number can not exceed 999 billion.");
            }

            StringBuilder sb = new StringBuilder();
            decimal currentNumber = number;
            for (int i = 3; i >= 0; i--) {

                string ret = ThousandsToWords(currentNumber, i);
                if (sb.ToString() != "")
                {
                    sb.Append(" And ");
                }
                sb.Append(ret);

                if (i > 0)
                {
                    currentNumber = (int)number % (int)Math.Pow(1000, i);
                }
            }

            if (sb.ToString() != "") {
                sb.Append(" Dollar");
            }

            string cents = DecimalToWords(number);
            if (cents != "")
            {
                sb.Append(" And ");
                sb.Append(cents);
            }        

            return sb.ToString();
        }

        public string ThousandsToWords(decimal number, int mi)
        {
            if (mi == 0)
            {
                return HundredsToWords((int)number % 1000);
            }

            var word = "";
            int divider = 0;
            switch (mi)
            {
                case 1 :
                    word = "Thousand";
                    divider = 1000;
                    break;
                case 2:
                    word = "Million";
                    divider = 1000000;
                    break;
                case 3:
                    word = "Billion";
                    divider = 1000000000;
                    break;                
            }

            StringBuilder sb = new StringBuilder();

            int n = (int)(number / divider);
            if (n > 0)
            {                
                sb.Append(HundredsToWords(n) + " " + word);
            }

            return sb.ToString();
        }

        public string HundredsToWords(int n)
        {
            //n has to be less than 1000
            if (n>=1000 || n<0)
            {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sb = new StringBuilder();

            int hundred = (n / 100);
            if (hundred == 0 && (n  % 100) == 0)
            {
                return sb.ToString();
            }
            if (hundred > 0)
            {
                sb.Append(DigitToWords(hundred) + " Hundred");
            }

            int tens = (n % 100 ) / 10;
            if (tens == 0 && (n % 10) == 0)
            {
                return sb.ToString();
            }

            if (sb.ToString() != "")
            {
                sb.Append(" And ");
            }

            //consider 11-20
            if (tens == 1) 
            {
                sb.Append(DigitToWords((int)n % 20));
                return sb.ToString();
            }

            //get it from twenty
            if (tens > 1)
            {
                sb.Append(TensToWords(tens));
            }
            int digit = (n % 10);
            if (digit == 0)
            {
                return sb.ToString();
            }
            if (tens > 0)
            {
                sb.Append("-");
            }
            sb.Append(DigitToWords(digit));

            return sb.ToString();
        }

        public string DecimalToWords(decimal n)
        {
            string roundValue = n.ToString("n2");
            if (roundValue.LastIndexOf(".00") > -1)
                return "";

            int val = Convert.ToInt16(roundValue.Substring(roundValue.LastIndexOf('.') + 1));
            if (val > 0 && val<20)
            {
                return DigitToWords(val) + " Cents";
            }

            int ten = (val / 10);
            int digit = (val % 10);

            return TensToWords(ten) + (digit==0 ? "" : "-" + DigitToWords(digit)) + " Cents";
        }

        private string DigitToWords(int i)
        {
            switch (i)
            {
                case 0:
                    return "";
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";
                case 11:
                    return "Eleven";
                case 12:
                    return "Twelve";
                case 13:
                    return "Thirteen";
                case 14:
                    return "Fourteen";
                case 15:
                    return "Fifteen";
                case 16:
                    return "Sixteen";
                case 17:
                    return "Seventeen";
                case 18:
                    return "Eighteen";
                case 19:
                    return "Nighteen";
            }
            return "";
        }

        private string TensToWords(int i)
        {
            switch (i)
            {
                case 2:
                    return "Twenty";
                case 3:
                    return "Thirty";
                case 4:
                    return "Fourty";
                case 5:
                    return "Fifty";
                case 6:
                    return "Sixty";
                case 7:
                    return "Seventy";
                case 8:
                    return "Eighty";
                case 90:
                    return "Ninety";
            }
            return "";
        }
    }
}