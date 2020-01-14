using System;
using System.Collections.Generic;
using System.Text;

namespace AppULA.Conversoes
{
    class ALUs
    {
    }
    public class Adder
    {
        And P0 = new And();
        And P1 = new And();
        Or P2 = new Or();
        Xor P3 = new Xor();
        Xor P4 = new Xor();
        public bool Ativa(bool A, bool B, bool Vem1, out bool Vai1)
        {

            bool M0, M1, M2, SOMA;
            M0 = P0.Ativa(A, B);
            M1 = P3.Ativa(A, B);
            M2 = P1.Ativa(M1, Vem1);
            Vai1 = P2.Ativa(M0, M2);
            SOMA = P4.Ativa(M1, Vem1);
            return (SOMA);
        }
    }

    public class ALU_1bit
    {

        And P0 = new And();
        Or P1 = new Or();
        Xor P1a = new Xor();
        Not P2 = new Not();
        Not P2a = new Not();
        And P3 = new And();
        And P4 = new And();
        And P4a = new And();
        And P5 = new And();
        And P6 = new And();
        Or8 P7 = new Or8();
        Not P8 = new Not();
        And P9 = new And();
        Decoder3_8 Dec0 = new Decoder3_8();
        Adder FA = new Adder();


        public bool Ativa(bool A, bool B, bool[] F, bool Vem1, out bool Vai1)
        {
            bool D0, D1, D2, D3, M0, M1, M2, M3, M4, M5, M6, M7, Soma, S;
            bool D4, D5, D6, D7, M1a, M2a, M4a, M5a;
            M0 = P0.Ativa(A, B);
            M1 = P1.Ativa(A, B);
            M1a = P1a.Ativa(A, B);
            M2a = P2a.Ativa(A);
            M2 = P2.Ativa(B);
            Soma = FA.Ativa(A, B, Vem1, out Vai1);
            Dec0.Ativa(F[2], F[1], F[0], out D0, out D1, out D2, out D3, out D4, out D5, out D6, out D7);
            M3 = P3.Ativa(M0, D0);
            M4 = P4.Ativa(M1, D1);
            M4a = P4a.Ativa(M1a, D2);
            M5a = P5.Ativa(M2a, D3);
            M5 = P5.Ativa(M2, D4);
            M6 = P6.Ativa(Soma, D5);
            M7 = P9.Ativa(P2.Ativa(M1a), D7);
            S = P7.Ativa(M3, M4, M4a, M5, M5a, M6, false, M7);
            return S;
        }

    }

    public class ALU_24bits
    {
        ALU_1bit ALU0 = new ALU_1bit();
        ALU_1bit ALU1 = new ALU_1bit();
        ALU_1bit ALU2 = new ALU_1bit();
        ALU_1bit ALU3 = new ALU_1bit();
        ALU_1bit ALU4 = new ALU_1bit();
        ALU_1bit ALU5 = new ALU_1bit();
        ALU_1bit ALU6 = new ALU_1bit();
        ALU_1bit ALU7 = new ALU_1bit();
        ALU_1bit ALU8 = new ALU_1bit();
        ALU_1bit ALU9 = new ALU_1bit();
        ALU_1bit ALU10 = new ALU_1bit();
        ALU_1bit ALU11 = new ALU_1bit();
        ALU_1bit ALU12 = new ALU_1bit();
        ALU_1bit ALU13 = new ALU_1bit();
        ALU_1bit ALU14 = new ALU_1bit();
        ALU_1bit ALU15 = new ALU_1bit();
        ALU_1bit ALU16 = new ALU_1bit();
        ALU_1bit ALU17 = new ALU_1bit();
        ALU_1bit ALU18 = new ALU_1bit();
        ALU_1bit ALU19 = new ALU_1bit();
        ALU_1bit ALU20 = new ALU_1bit();
        ALU_1bit ALU21 = new ALU_1bit();
        ALU_1bit ALU22 = new ALU_1bit();
        ALU_1bit ALU23 = new ALU_1bit();

        public bool Ativa(bool[] A, bool[] B, bool[] F, bool[] S)
        {
            bool Vai1, Vem1, V1 = false;
            S[23] = ALU23.Ativa(A[23], B[23], F, V1, out Vai1);
            Vem1 = Vai1;
            S[22] = ALU22.Ativa(A[22], B[22], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[21] = ALU21.Ativa(A[21], B[21], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[20] = ALU20.Ativa(A[20], B[20], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[19] = ALU19.Ativa(A[19], B[19], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[18] = ALU18.Ativa(A[18], B[18], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[17] = ALU17.Ativa(A[17], B[17], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[16] = ALU16.Ativa(A[16], B[16], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[15] = ALU15.Ativa(A[15], B[15], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[14] = ALU14.Ativa(A[14], B[14], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[13] = ALU13.Ativa(A[13], B[13], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[12] = ALU12.Ativa(A[12], B[12], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[11] = ALU11.Ativa(A[11], B[11], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[10] = ALU10.Ativa(A[10], B[10], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[9] = ALU9.Ativa(A[9], B[9], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[8] = ALU8.Ativa(A[8], B[8], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[7] = ALU7.Ativa(A[7], B[7], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[6] = ALU6.Ativa(A[6], B[6], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[5] = ALU5.Ativa(A[5], B[5], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[4] = ALU4.Ativa(A[4], B[4], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[3] = ALU3.Ativa(A[3], B[3], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[2] = ALU2.Ativa(A[2], B[2], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[1] = ALU1.Ativa(A[1], B[1], F, Vem1, out Vai1);
            Vem1 = Vai1;
            S[0] = ALU0.Ativa(A[0], B[0], F, Vem1, out Vai1);
            return Vai1;
        }
    }

    public class ALU_Total
    {
        bool saida, andS;
        bool[] um = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true };
        And24 Compara24 = new And24();
        ALU_24bits ALU24 = new ALU_24bits();
        public bool Ativa(bool[] A, bool[] B, bool[] F, bool[] S)
        {

            if (F[2] & F[1] & F[0])
            {
                saida = ALU24.Ativa(A, B, F, S);
                andS = S[23] & S[22] & S[21] & S[20] & S[19] & S[18] & S[17] & S[16] &
                    S[15] & S[14] & S[13] & S[12] & S[11] & S[10] & S[9] & S[8] & S[7] & S[6] & S[5] & S[4] & S[3] & S[2] & S[1] & S[0];
                andS = Compara24.Ativa(S[23], S[22], S[21], S[20], S[19], S[18], S[17], S[16],
                    S[15], S[14], S[13], S[12], S[11], S[10], S[9], S[8], S[7], S[6], S[5], S[4], S[3], S[2], S[1], S[0]);
                return andS;
            }
            else if (F[2] & F[1] & !F[0])
            {


                F[2] = true; F[1] = false; F[0] = false;
                saida = ALU24.Ativa(A, B, F, S);
                F[2] = true; F[1] = false; F[0] = true;
                saida = ALU24.Ativa(A, S, F, S);
                F[2] = true; F[1] = false; F[0] = true;
                saida = ALU24.Ativa(S, um, F, S);
                return saida;
            }
            else
            {
                saida = ALU24.Ativa(A, B, F, S);
                return saida;
            }
        }

    }

}
