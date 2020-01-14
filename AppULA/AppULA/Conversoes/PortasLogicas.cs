using System;
using System.Collections.Generic;
using System.Text;

namespace AppULA.Conversoes
{
    class PortasLogicas
    {

    }

    public class _Not
    {
        public bool not(bool A)
        {
            return (!A);
        }
    }

    public class _And
    {
        public bool and(bool A, bool B)
        {
            return (A & B);
        }
    }

    public class _Or
    {
        public bool or(bool A, bool B)
        {
            return (A | B);
        }
    }

    public class _Xor
    {
        public bool xor(bool A, bool B)
        {
            _And and = new _And();
            _Not not = new _Not();
            _Or or = new _Or();

            bool A_or_B = or.or(A, B);
            bool A_and_B_negado = not.not(and.and(A, B));
            bool saida = and.and(A_or_B, A_and_B_negado);

            return saida;
        }
    }
}
