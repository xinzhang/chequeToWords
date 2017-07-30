using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeConverter
{
    public interface IConverter
    {
        string NumberToWords(decimal number);
    }
}
