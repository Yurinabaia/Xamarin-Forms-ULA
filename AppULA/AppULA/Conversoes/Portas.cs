using System;
using System.Collections.Generic;
using System.Text;

namespace AppULA.Conversoes
{
    class Portas
    {
    }

    public class Not
    {
        public bool Ativa(bool A)
        {
            return (!A);
        }
    }

    public abstract class Porta2
    {
        public abstract bool Ativa(bool A, bool B);
    }

    public class And : Porta2
    {
        public override bool Ativa(bool A, bool B)
        {
            return (A & B);
        }
    }

    public class And3
    {
        And P0 = new And();
        And P1 = new And();

        public bool Ativa(bool A, bool B, bool C)
        {

            return (P1.Ativa(P0.Ativa(A, B), C));

        }
    }

    public class And4
    {
        bool M0, M1;
        And P0 = new And();
        And P1 = new And();
        And P2 = new And();
        public bool Ativa(bool A, bool B, bool C, bool D)
        {

            M0 = P0.Ativa(A, B);
            M1 = P1.Ativa(C, D);
            return (P2.Ativa(M0, M1));

        }
    }


    public class And8
    {
        bool M0, M1;
        And4 P0 = new And4();
        And4 P1 = new And4();
        And P2 = new And();
        public bool Ativa(bool A, bool B, bool C, bool D, bool E, bool F, bool G, bool H)
        {
            M0 = P0.Ativa(A, B, C, D);
            M1 = P1.Ativa(E, F, G, H);
            return (P2.Ativa(M0, M1));
        }
    }
    public class And24
    {
        bool M0, M1, M2;
        And8 P0 = new And8();
        And8 P1 = new And8();
        And8 P2 = new And8();
        And3 P3 = new And3();
        public bool Ativa(bool A, bool B, bool C, bool D, bool E, bool F, bool G, bool H, bool I, bool J, bool K, bool L, bool M, bool N, bool O, bool P, bool Q
            , bool R, bool S, bool T, bool U, bool V, bool W, bool Y)
        {
            M0 = P0.Ativa(A, B, C, D, E, F, G, H);
            M1 = P1.Ativa(I, J, K, L, M, N, O, P);
            M2 = P1.Ativa(Q, R, S, T, U, V, W, Y);
            return (P3.Ativa(M0, M1, M2));
        }
    }

    public class Or : Porta2
    {
        public override bool Ativa(bool A, bool B)
        {
            return (A | B);
        }
    }

    public class Or4
    {
        bool M0, M1;
        Or P0 = new Or();
        Or P1 = new Or();
        Or P2 = new Or();
        public bool Ativa(bool A, bool B, bool C, bool D)
        {

            M0 = P0.Ativa(A, B);
            M1 = P1.Ativa(C, D);
            return (P2.Ativa(M0, M1));
        }
    }


    public class Or8
    {
        bool M0, M1;
        Or4 P0 = new Or4();
        Or4 P1 = new Or4();
        Or P2 = new Or();
        public bool Ativa(bool A, bool B, bool C, bool D, bool E, bool F, bool G, bool H)
        {
            M0 = P0.Ativa(A, B, C, D);
            M1 = P1.Ativa(E, F, G, H);
            return (P2.Ativa(M0, M1));
        }
    }

    public class Xor : Porta2
    {

        And P0 = new And();
        And P1 = new And();
        Or P2 = new Or();
        Not P3 = new Not();
        Not P4 = new Not();

        public override bool Ativa(bool A, bool B)
        {
            bool M0, M1;
            M0 = P1.Ativa(P3.Ativa(A), B);
            M1 = P1.Ativa(A, P4.Ativa(B));
            return (P2.Ativa(M0, M1));
        }
    }

    public class Decoder2_4
    {
        And P0 = new And();
        And P1 = new And();
        And P2 = new And();
        And P3 = new And();
        Not P4 = new Not();
        Not P5 = new Not();

        public void Ativa(bool A, bool B, out bool D0, out bool D1, out bool D2, out bool D3)
        {
            D0 = P0.Ativa(P4.Ativa(A), P5.Ativa(B));
            D1 = P1.Ativa(P4.Ativa(A), B);
            D2 = P2.Ativa(A, P5.Ativa(B));
            D3 = P3.Ativa(A, B);

        }
    }


    public class Decoder3_8
    {

        And3 P0 = new And3();
        And3 P1 = new And3();
        And3 P2 = new And3();
        And3 P3 = new And3();
        Not P4 = new Not();
        Not P5 = new Not();
        Not P6 = new Not();
        And3 P7 = new And3();
        And3 P8 = new And3();
        And3 P9 = new And3();
        And3 P10 = new And3();

        public void Ativa(bool A, bool B, bool C, out bool D0, out bool D1, out bool D2, out bool D3, out bool D4, out bool D5, out bool D6, out bool D7)
        {
            D0 = P0.Ativa(P4.Ativa(A), P5.Ativa(B), P6.Ativa(C));
            D1 = P1.Ativa(P4.Ativa(A), P5.Ativa(B), C);
            D2 = P2.Ativa(P4.Ativa(A), B, P6.Ativa(C));
            D3 = P3.Ativa(P4.Ativa(A), B, C);
            D4 = P7.Ativa(A, P5.Ativa(B), P6.Ativa(C));
            D5 = P8.Ativa(A, P5.Ativa(B), C);
            D6 = P9.Ativa(A, B, P6.Ativa(C));
            D7 = P10.Ativa(A, B, C);
        }
    }

}
