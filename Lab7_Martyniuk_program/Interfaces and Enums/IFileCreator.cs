using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Martyniuk_program
{
    public interface IMyFileCreator
    {
        MyFile CreateRandomly();

        MyFile CreateFromStringRandomly();
    }
}
