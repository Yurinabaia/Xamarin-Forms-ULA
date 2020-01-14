using System;
using System.Collections.Generic;
using System.Text;

namespace AppULA.Conversoes
{
    class Circuitos
    {
        public bool Somador(bool A, bool B, bool vem1, ref bool vai1)
        {
            _And and = new _And();
            _Not not = new _Not();
            _Or or = new _Or();
            _Xor xor = new _Xor();

            bool A_xor_B = xor.xor(A, B);
            bool A_and_B = and.and(A, B);
            bool Vem1_xor_A_xor_B = xor.xor(A_xor_B, vem1);
            bool Saida = Vem1_xor_A_xor_B;
            bool Vem1_and_A_xor_B = and.and(A_xor_B, vem1);
            bool Vem1_and_A_xor_B_or_A_and_B = or.or(Vem1_and_A_xor_B, A_and_B);
            vai1 = Vem1_and_A_xor_B_or_A_and_B;

            return Saida;
        }

        public bool Subtrador(bool A, bool B)
        {
            _And and = new _And();
            _Not not = new _Not();
            _Or or = new _Or();
            _Xor xor = new _Xor();

            bool A_xor_B = xor.xor(A, B);
            bool Saida = A_xor_B;

            return Saida;
        }
    }
}
