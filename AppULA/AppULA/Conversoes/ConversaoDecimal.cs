using System;
using System.Collections.Generic;
using System.Text;

namespace AppULA.Conversoes
{
    class ConversaoDecimal
    {
        public string ExpoenteResposta;

        //Atritutos do primeiro numero!
        public int _casasAndou;
        public double numero;
        public double numeroReal;
        public string Sinal;
        public string Expoente;
        public string Mantissa;
        public string numeroHexadecimal;
        public bool[] numeroVetorBoleano = new bool[24];

        //Atritutos do segundo numero!
        public int _casasAndou2;
        public double numero2;
        public double numero2Real;
        public string Sinal2;
        public string Expoente2;
        public string Mantissa2;
        public string numeroHexadecimal2;
        public bool[] numero2VetorBoleano = new bool[24];


        //Atributo pra maior numero de casa!
        public int maior;

        /// <summary>
        /// Construto para pegar os numeros
        /// </summary>
        /// <param name="a">numero um</param>
        /// <param name="b">numero dois</param>
        public ConversaoDecimal(double a, double b)
        {
            numeroReal = a;
            numero = Math.Abs(a);
            _casasAndou = 0;
            numero2Real = b;
            numero2 = Math.Abs(b);
            _casasAndou2 = 0;
            maior = 0;
            Sinal = "";
            Expoente = "";
            Mantissa = "";
            Sinal2 = "";
            Expoente2 = "";
            Mantissa2 = "";
        }
        public ConversaoDecimal(double soma)
        {
            numeroReal = soma;
            numero = Math.Abs(soma);
            _casasAndou = 0;
            maior = 0;
            Sinal = "";
            Expoente = "";
            Mantissa = "";
        }

        public void TransformarEmIEEE()
        {
            int numeroExpoente;

            TransformarNumeroComCasas();
            IgualarCasas();

            Sinal = ConversaoSinal(numeroReal);
            Sinal2 = ConversaoSinal(numero2Real);

            numeroExpoente = _casasAndou + 127;
            Expoente = ConversaoExpoente(numeroExpoente);
            Expoente2 = ConversaoExpoente(numeroExpoente);
            numeroExpoente = maior + 127;
            ExpoenteResposta = ConversaoExpoente(numeroExpoente);

            Mantissa = ConversaoMantissa(numero);
            string PassarBoleano = Mantissa;
            Mantissa2 = ConversaoMantissa(numero2);
            string PassarBoleano2 = Mantissa2;
            TransformarEmBoleanoMantissa(PassarBoleano, PassarBoleano2);

            numeroHexadecimal = TranformarEmHexadecimal(Sinal, Expoente, Mantissa);
            numeroHexadecimal2 = TranformarEmHexadecimal(Sinal2, Expoente2, Mantissa2);
        }
        public void TransformarEmIEEESemIgualarCasas()
        {
            int numeroExpoente;

            TransformarNumeroComCasas();


            Sinal = ConversaoSinal(numeroReal);
            Sinal2 = ConversaoSinal(numero2Real);

            numeroExpoente = _casasAndou + 127;
            Expoente = ConversaoExpoente(numeroExpoente);
            numeroExpoente = _casasAndou2 + 127;
            Expoente2 = ConversaoExpoente(numeroExpoente);
            numeroExpoente = maior + 127;
            ExpoenteResposta = ConversaoExpoente(numeroExpoente);

            Mantissa = ConversaoMantissa(numero);
            string PassarBoleano = Mantissa;
            Mantissa2 = ConversaoMantissa(numero2);
            string PassarBoleano2 = Mantissa2;
            TransformarEmBoleanoMantissa(PassarBoleano, PassarBoleano2);

            numeroHexadecimal = TranformarEmHexadecimal(Sinal, Expoente, Mantissa);
            numeroHexadecimal2 = TranformarEmHexadecimal(Sinal2, Expoente2, Mantissa2);
        }

        private void TransformarNumeroComCasas()
        {
            if (numero >= 2)
            {
                while (numero >= 2)
                {
                    numero = numero / 2;
                    _casasAndou++;
                }

            }
            else if (numero < 1)
            {
                while (numero < 1)
                {
                    numero = numero * 2;
                    _casasAndou--;
                }
            }
            if (numero2 >= 2 && numero2 != 0)
            {
                while (numero2 >= 2)
                {
                    numero2 = numero2 / 2;
                    _casasAndou2++;
                }
            }
            else if (numero2 < 1 && numero2 != 0)
            {
                while (numero2 < 1)
                {
                    numero2 = numero2 * 2;
                    _casasAndou2--;
                }
            }

        }
        private void IgualarCasas()
        {
            if (_casasAndou > _casasAndou2)
            {
                maior = _casasAndou;
                while (_casasAndou != _casasAndou2)
                {
                    numero2 = numero2 / 10;
                    _casasAndou2++;
                }


            }
            else if (_casasAndou < _casasAndou2)
            {
                maior = _casasAndou2;
                while (_casasAndou != _casasAndou2)
                {
                    numero = numero / 10;
                    _casasAndou++;
                }


            }
            else
            {
                maior = _casasAndou + 1;
            }


        }

        private string ConversaoExpoente(int a)
        {
            string _numeroConvertidoBinario = "";
            int x = a;
            int binario;
            if (x == 0)
            {
                _numeroConvertidoBinario = "0";
            }
            else if (x == 1)
            {
                _numeroConvertidoBinario = "1";
            }
            else
            {
                while (x > 1)
                {
                    if (x < 5)
                    {
                        binario = x % 2;

                        if (binario == 0)
                        {
                            if (x == 4)
                            {
                                x = x / 4;
                                _numeroConvertidoBinario = x + "0" + "0" + _numeroConvertidoBinario;
                            }
                            if (x == 2)
                            {
                                x = x / 2;
                                _numeroConvertidoBinario = x + "0" + _numeroConvertidoBinario;
                            }

                        }
                        if (binario == 1)
                        {
                            x = x / 2;
                            _numeroConvertidoBinario = x + "1" + _numeroConvertidoBinario;
                        }
                    }
                    else
                    {
                        binario = x % 2;
                        x = x / 2;
                        _numeroConvertidoBinario = binario + _numeroConvertidoBinario;

                    }
                }
            }
            if (_numeroConvertidoBinario.Length == 7)
            {
                _numeroConvertidoBinario = "0" + _numeroConvertidoBinario;
            }
            return _numeroConvertidoBinario;
        }
        private string ConversaoMantissa(double a)
        {
            string _numeroConvertidoBinario = "";
            double x2 = a;
            int contador = 0;
            do
            {
                if (x2 >= 1)
                {
                    _numeroConvertidoBinario = _numeroConvertidoBinario + "1";
                    contador++;
                    x2 = x2 - 1;
                    x2 = 2 * x2;
                }
                else
                {
                    x2 = 2 * x2;
                    _numeroConvertidoBinario = _numeroConvertidoBinario + "0";
                    contador++;
                }
            } while (contador == 1 || contador == 2 || contador == 3 || contador == 4 || contador == 5 || contador == 6 || contador == 7 ||
                contador == 8 || contador == 9 || contador == 10 || contador == 11 || contador == 12 || contador == 13 || contador == 14 ||
                contador == 15 || contador == 16 || contador == 17 || contador == 18 || contador == 19 || contador == 20 || contador == 21 ||
                contador == 22 || contador == 23);

            StringBuilder _tirarOPrimeiroDaString = new StringBuilder(_numeroConvertidoBinario);

            _tirarOPrimeiroDaString.Remove(0, 1);

            _numeroConvertidoBinario = _tirarOPrimeiroDaString.ToString();

            return _numeroConvertidoBinario;
        }
        private string ConversaoSinal(double a)
        {
            string _numeroConvertidoBinario = "";
            if (a >= 0)
            {
                _numeroConvertidoBinario = "0";
            }
            else
            {
                _numeroConvertidoBinario = "1";
            }
            return _numeroConvertidoBinario;
        }
        private string TranformarEmHexadecimal(string a, string b, string c)
        {
            string _numeroConvertidoHexadecimal = a + b + c;
            string _numeroConvertidoIEEE754EmHexadecimal = "0x";
            for (int i = 0; i < 32; i = i + 4)
            {
                if (_numeroConvertidoHexadecimal[i] == '0' && _numeroConvertidoHexadecimal[i + 1] == '0' &&
                    _numeroConvertidoHexadecimal[i + 2] == '0' && _numeroConvertidoHexadecimal[i + 3] == '0')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "0";
                }
                else if (_numeroConvertidoHexadecimal[i] == '0' && _numeroConvertidoHexadecimal[i + 1] == '0' &&
                    _numeroConvertidoHexadecimal[i + 2] == '0' && _numeroConvertidoHexadecimal[i + 3] == '1')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "1";
                }
                else if (_numeroConvertidoHexadecimal[i] == '0' && _numeroConvertidoHexadecimal[i + 1] == '0' &&
                    _numeroConvertidoHexadecimal[i + 2] == '1' && _numeroConvertidoHexadecimal[i + 3] == '0')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "2";
                }
                else if (_numeroConvertidoHexadecimal[i] == '0' && _numeroConvertidoHexadecimal[i + 1] == '0' &&
                    _numeroConvertidoHexadecimal[i + 2] == '1' && _numeroConvertidoHexadecimal[i + 3] == '1')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "3";
                }
                else if (_numeroConvertidoHexadecimal[i] == '0' && _numeroConvertidoHexadecimal[i + 1] == '1' &&
                    _numeroConvertidoHexadecimal[i + 2] == '0' && _numeroConvertidoHexadecimal[i + 3] == '0')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "4";
                }
                else if (_numeroConvertidoHexadecimal[i] == '0' && _numeroConvertidoHexadecimal[i + 1] == '1' &&
                    _numeroConvertidoHexadecimal[i + 2] == '0' && _numeroConvertidoHexadecimal[i + 3] == '0')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "5";
                }
                else if (_numeroConvertidoHexadecimal[i] == '0' && _numeroConvertidoHexadecimal[i + 1] == '1' &&
                    _numeroConvertidoHexadecimal[i + 2] == '1' && _numeroConvertidoHexadecimal[i + 3] == '0')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "6";
                }
                else if (_numeroConvertidoHexadecimal[i] == '0' && _numeroConvertidoHexadecimal[i + 1] == '1' &&
                    _numeroConvertidoHexadecimal[i + 2] == '1' && _numeroConvertidoHexadecimal[i + 3] == '1')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "7";
                }
                else if (_numeroConvertidoHexadecimal[i] == '1' && _numeroConvertidoHexadecimal[i + 1] == '0' &&
                    _numeroConvertidoHexadecimal[i + 2] == '0' && _numeroConvertidoHexadecimal[i + 3] == '0')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "8";
                }
                else if (_numeroConvertidoHexadecimal[i] == '1' && _numeroConvertidoHexadecimal[i + 1] == '0' &&
                    _numeroConvertidoHexadecimal[i + 2] == '0' && _numeroConvertidoHexadecimal[i + 3] == '1')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "9";
                }
                else if (_numeroConvertidoHexadecimal[i] == '1' && _numeroConvertidoHexadecimal[i + 1] == '0' &&
                    _numeroConvertidoHexadecimal[i + 2] == '1' && _numeroConvertidoHexadecimal[i + 3] == '0')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "A";
                }
                else if (_numeroConvertidoHexadecimal[i] == '1' && _numeroConvertidoHexadecimal[i + 1] == '0' &&
                    _numeroConvertidoHexadecimal[i + 2] == '1' && _numeroConvertidoHexadecimal[i + 3] == '1')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "B";
                }
                else if (_numeroConvertidoHexadecimal[i] == '1' && _numeroConvertidoHexadecimal[i + 1] == '1' &&
                    _numeroConvertidoHexadecimal[i + 2] == '0' && _numeroConvertidoHexadecimal[i + 3] == '0')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "C";
                }
                else if (_numeroConvertidoHexadecimal[i] == '1' && _numeroConvertidoHexadecimal[i + 1] == '1' &&
                    _numeroConvertidoHexadecimal[i + 2] == '0' && _numeroConvertidoHexadecimal[i + 3] == '1')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "D";
                }
                else if (_numeroConvertidoHexadecimal[i] == '1' && _numeroConvertidoHexadecimal[i + 1] == '1' &&
                    _numeroConvertidoHexadecimal[i + 2] == '1' && _numeroConvertidoHexadecimal[i + 3] == '0')
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "E";
                }
                else
                {
                    _numeroConvertidoIEEE754EmHexadecimal = _numeroConvertidoIEEE754EmHexadecimal + "F";
                }
            }
            return _numeroConvertidoIEEE754EmHexadecimal;
        }
        private void TransformarEmBoleanoMantissa(string a, string b)
        {
            for (int i = 0; i < 23; i++)
            {
                if (a[i] == '1')
                {
                    numeroVetorBoleano[i] = true;
                }
                else
                {
                    numeroVetorBoleano[i] = false;
                }
            }
            for (int i = 0; i < 23; i++)
            {
                if (b[i] == '1')
                {
                    numero2VetorBoleano[i] = true;
                }
                else
                {
                    numero2VetorBoleano[i] = false;
                }
            }
        }
        public string SomaBynario()
        {
            //Tabela Verdade;
            bool vai1 = false;

            bool[] resultado = new bool[24];
            //string valor = "";
            Circuitos Somador = new Circuitos();
            resultado[23] = Somador.Somador(numeroVetorBoleano[23], numero2VetorBoleano[23], false, ref vai1);
            resultado[22] = Somador.Somador(numeroVetorBoleano[22], numero2VetorBoleano[22], vai1, ref vai1);
            resultado[21] = Somador.Somador(numeroVetorBoleano[21], numero2VetorBoleano[21], vai1, ref vai1);
            resultado[20] = Somador.Somador(numeroVetorBoleano[20], numero2VetorBoleano[20], vai1, ref vai1);
            resultado[19] = Somador.Somador(numeroVetorBoleano[19], numero2VetorBoleano[19], vai1, ref vai1);
            resultado[18] = Somador.Somador(numeroVetorBoleano[18], numero2VetorBoleano[18], vai1, ref vai1);
            resultado[17] = Somador.Somador(numeroVetorBoleano[17], numero2VetorBoleano[17], vai1, ref vai1);
            resultado[16] = Somador.Somador(numeroVetorBoleano[16], numero2VetorBoleano[16], vai1, ref vai1);
            resultado[15] = Somador.Somador(numeroVetorBoleano[15], numero2VetorBoleano[15], vai1, ref vai1);
            resultado[14] = Somador.Somador(numeroVetorBoleano[14], numero2VetorBoleano[14], vai1, ref vai1);
            resultado[13] = Somador.Somador(numeroVetorBoleano[13], numero2VetorBoleano[13], vai1, ref vai1);
            resultado[12] = Somador.Somador(numeroVetorBoleano[12], numero2VetorBoleano[12], vai1, ref vai1);
            resultado[11] = Somador.Somador(numeroVetorBoleano[11], numero2VetorBoleano[11], vai1, ref vai1);
            resultado[10] = Somador.Somador(numeroVetorBoleano[10], numero2VetorBoleano[10], vai1, ref vai1);
            resultado[09] = Somador.Somador(numeroVetorBoleano[09], numero2VetorBoleano[09], vai1, ref vai1);
            resultado[08] = Somador.Somador(numeroVetorBoleano[08], numero2VetorBoleano[08], vai1, ref vai1);
            resultado[07] = Somador.Somador(numeroVetorBoleano[07], numero2VetorBoleano[07], vai1, ref vai1);
            resultado[06] = Somador.Somador(numeroVetorBoleano[06], numero2VetorBoleano[06], vai1, ref vai1);
            resultado[05] = Somador.Somador(numeroVetorBoleano[05], numero2VetorBoleano[05], vai1, ref vai1);
            resultado[04] = Somador.Somador(numeroVetorBoleano[04], numero2VetorBoleano[04], vai1, ref vai1);
            resultado[03] = Somador.Somador(numeroVetorBoleano[03], numero2VetorBoleano[03], vai1, ref vai1);
            resultado[02] = Somador.Somador(numeroVetorBoleano[02], numero2VetorBoleano[02], vai1, ref vai1);
            resultado[01] = Somador.Somador(numeroVetorBoleano[01], numero2VetorBoleano[01], vai1, ref vai1);
            resultado[00] = Somador.Somador(numeroVetorBoleano[00], numero2VetorBoleano[00], vai1, ref vai1);

            char[] binarioChar = new char[resultado.Length];

            for (int i = 0; i < resultado.Length; i++)
            {
                if (resultado[i] == true)
                {
                    binarioChar[i] = '1';
                }
                else
                {
                    binarioChar[i] = '0';
                }
            }

            string invertida = new String(binarioChar);
            return invertida;
        }

        public string SubtrairBynario()
        {
            bool[] resultado = new bool[24];

            Circuitos sub = new Circuitos();
            resultado[23] = sub.Subtrador(numeroVetorBoleano[23], numero2VetorBoleano[23]);
            resultado[22] = sub.Subtrador(numeroVetorBoleano[22], numero2VetorBoleano[22]);
            resultado[21] = sub.Subtrador(numeroVetorBoleano[21], numero2VetorBoleano[21]);
            resultado[20] = sub.Subtrador(numeroVetorBoleano[20], numero2VetorBoleano[20]);
            resultado[19] = sub.Subtrador(numeroVetorBoleano[19], numero2VetorBoleano[19]);
            resultado[18] = sub.Subtrador(numeroVetorBoleano[18], numero2VetorBoleano[18]);
            resultado[17] = sub.Subtrador(numeroVetorBoleano[17], numero2VetorBoleano[17]);
            resultado[16] = sub.Subtrador(numeroVetorBoleano[16], numero2VetorBoleano[16]);
            resultado[15] = sub.Subtrador(numeroVetorBoleano[15], numero2VetorBoleano[15]);
            resultado[14] = sub.Subtrador(numeroVetorBoleano[14], numero2VetorBoleano[14]);
            resultado[13] = sub.Subtrador(numeroVetorBoleano[13], numero2VetorBoleano[13]);
            resultado[12] = sub.Subtrador(numeroVetorBoleano[12], numero2VetorBoleano[12]);
            resultado[11] = sub.Subtrador(numeroVetorBoleano[11], numero2VetorBoleano[11]);
            resultado[10] = sub.Subtrador(numeroVetorBoleano[10], numero2VetorBoleano[10]);
            resultado[09] = sub.Subtrador(numeroVetorBoleano[09], numero2VetorBoleano[09]);
            resultado[08] = sub.Subtrador(numeroVetorBoleano[08], numero2VetorBoleano[08]);
            resultado[07] = sub.Subtrador(numeroVetorBoleano[07], numero2VetorBoleano[07]);
            resultado[06] = sub.Subtrador(numeroVetorBoleano[06], numero2VetorBoleano[06]);
            resultado[05] = sub.Subtrador(numeroVetorBoleano[05], numero2VetorBoleano[05]);
            resultado[04] = sub.Subtrador(numeroVetorBoleano[04], numero2VetorBoleano[04]);
            resultado[03] = sub.Subtrador(numeroVetorBoleano[03], numero2VetorBoleano[03]);
            resultado[02] = sub.Subtrador(numeroVetorBoleano[02], numero2VetorBoleano[02]);
            resultado[01] = sub.Subtrador(numeroVetorBoleano[01], numero2VetorBoleano[01]);
            resultado[00] = sub.Subtrador(numeroVetorBoleano[00], numero2VetorBoleano[00]);

            char[] binarioChar = new char[resultado.Length];

            for (int i = 0; i < resultado.Length; i++)
            {
                if (resultado[i] == true)
                {
                    binarioChar[i] = '1';
                }
                else
                {
                    binarioChar[i] = '0';
                }
            }

            string invertida = new String(binarioChar);
            return invertida;
        }
        public string MultiplicacaoByte(float n)

        {
            string valor = "";

            if (n < 0) { n *= -1; }


            int dividendo = Convert.ToInt32(n);

            if (dividendo == 0 || dividendo == 1)
            {

                return Convert.ToString(dividendo);

            }

            else
            {

                while (dividendo > 0)
                {

                    valor += Convert.ToString(dividendo % 2);

                    dividendo = dividendo / 2;

                }

                return InverterString(valor);
            }
        }
        public string DivisaoByte(float n)

        {
            string valor = "";

            if (n < 0) { n *= -1; }

            int dividendo = Convert.ToInt32(n);

            if (dividendo == 0 || dividendo == 1)
            {

                return Convert.ToString(dividendo);

            }

            else
            {
                while (dividendo > 0)
                {

                    valor += Convert.ToString(dividendo % 2);

                    dividendo = dividendo / 2;

                }
                return InverterString(valor);
            }
        }
        public static string InverterString(string str)
        {
            int tamanho = str.Length;

            string caracteres = "";

            for (int i = 0; i < tamanho; i++)
            {
                caracteres += str[tamanho - 1 - i];
            }

            while (caracteres.Length < 8)
            {
                caracteres = "0" + caracteres.ToString();
            }
            return (caracteres);
        }
    }
}
