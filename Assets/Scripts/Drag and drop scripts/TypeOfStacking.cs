using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TypeOfStacking
{
    ASC, // Ascending: A,2,3,4,5,6,7,8,9,10,J,Q,K - same color
    DSC, // Descending: K,Q,J,10,9,8,7,6,5,4,3,2,1,A - alternating colors
    NONE
}
