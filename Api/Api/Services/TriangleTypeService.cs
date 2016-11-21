using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public class TriangleTypeService : ITriangleTypeService
    {
        public enum TrianlgeType
        {
            Equilateral,
            Isoscieles,
            Scalene,
            Unknown
        };

        public TrianlgeType CheckTriangleType(int a, int b, int c)
        {
            ValidateTriangle(a ,b, c);
            if (CheckEquilateral(a, b, c))
                return TrianlgeType.Equilateral;
            if (CheckIsoscieles(a, b, c))
                return TrianlgeType.Isoscieles;
            if (CheckScalene(a, b, c))
                return TrianlgeType.Scalene;
            return TrianlgeType.Unknown;
        }

        private void ValidateTriangle(int a, int b, int c)
        {
            bool isValidTrinangle =
            (a + b > c) && (b + c > a) && (a + c > b);
            
            if(!isValidTrinangle)
                throw new ArgumentException();
        }

        private bool CheckEquilateral(int a, int b, int c)
        {
            return (a == b && b == c && c == a);
        }

        private bool CheckIsoscieles(int a, int b, int c)
        {
            return (a == b || b == c || c == a);
        }

        private bool CheckScalene(int a, int b, int c)
        {
            return (a != b && b != c && c != a);
        }
    }

}
