using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingDomino
{
    public class MyComparer : IComparer
    {
        int IComparer.Compare(Object xx, Object yy)
        {
            Domino x = (Domino)xx;
            Domino y = (Domino)yy;
            return x.tile1.tileNumber.CompareTo(y.tile1.tileNumber);
        }
    }
}
