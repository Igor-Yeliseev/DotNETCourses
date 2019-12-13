using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    interface IPaperFigure
    {
        Сoloring Сolor { get; set; }
        void Paint(Сoloring color);
    }
}
