using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace AppULA.Conversoes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class PaginaInicial : ContentPage
    {

        bool[] vetorA = new bool[24];
        bool[] vetorB = new bool[24];
        bool[] vetorS = new bool[24];
        bool[] F = new bool[3];


        ALU_Total AT = new ALU_Total();

        ConversaoDecimal[] conversao;
        ConversaoDecimal[] conversao2;
        int contContas;
        float soma, subtracao, multiplicacao, divisoa;
        public PaginaInicial()
        {
            conversao = new ConversaoDecimal[1000];
            conversao2 = new ConversaoDecimal[1000];
            contContas = 0;
            InitializeComponent();
        }
        private void BotaoCalcular(object sender, EventArgs args) 
        {
            contContas++;

            float num1 = 0, num2 = 0;
            try
            {
                int array = TexNum1.Text.Length;
                int array2 = TexNum2.Text.Length;
                if (array != 0 && array2 != 0)
                {
                    num1 = float.Parse(TexNum1.Text);
                    num2 = float.Parse(TexNum2.Text);
                }
                if (array != 0 && array2 != 0 && num1 != 0 && num2 != 0)
                {
                    var stream = GetStreamFromFile("Intro.mp3");
                    var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    audio.Load(stream);
                    audio.Play();
                    soma = num2 + num1;
                    subtracao = num2 - num1;
                    multiplicacao = num2 * num1;
                    divisoa = num2 / num1;
                    conversao[contContas] = new ConversaoDecimal(num1, num2);
                    conversao[contContas].TransformarEmIEEESemIgualarCasas();
                    NUM.Text = num1.ToString();
                    MANTISSA.Text = conversao[contContas].Mantissa.ToString();
                    EXPOENTE.Text = conversao[contContas].Expoente.ToString();
                    SINAL.Text = conversao[contContas].Sinal.ToString();
                    DECIMAL.Text = conversao[contContas].numeroHexadecimal.ToString();
                    NUM2.Text = num2.ToString();
                    MANTISSA2.Text = conversao[contContas].Mantissa.ToString();
                    EXPOENTE2.Text = conversao[contContas].Expoente.ToString();
                    SINAL2.Text = conversao[contContas].Sinal.ToString();
                    DECIMAL2.Text = conversao[contContas].numeroHexadecimal2;
                }
                else
                {
                    DisplayAlert("Erro", "Digite algum número cario", "TALKEY");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Digite apenas número cario", "TALKEY");
            }
        }
        private void SOMBOT(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs
        {
            try
            {
                if (soma != 0)
                {
                    var stream = GetStreamFromFile("Soma.mp3");
                    var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    audio.Load(stream);
                    audio.Play();
                    conversao[contContas] = new ConversaoDecimal(soma);
                    conversao[contContas].TransformarEmIEEESemIgualarCasas();
                    NUMRESUL.Text = soma.ToString();
                    MANTISSARESUL.Text = conversao[contContas].Mantissa.ToString();
                    EXPOENTERESUL.Text = conversao[contContas].Expoente.ToString();
                    SINALRESUL.Text = conversao[contContas].Sinal.ToString();
                    DECIMALRESUL.Text = conversao[contContas].numeroHexadecimal.ToString();
                }
                else
                {
                    DisplayAlert("Erro", "A soma deu 0", "TALKEY");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Digite um número", "TALKEY");
            }
        }
        private void SUBBOT(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs
        {
            try
            {
                if (soma != 0)
                {
                    var stream = GetStreamFromFile("Sub.mp3");
                    var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    audio.Load(stream);
                    audio.Play();
                    conversao[contContas] = new ConversaoDecimal(subtracao);
                    conversao[contContas].TransformarEmIEEESemIgualarCasas();
                    NUMRESUL.Text = subtracao.ToString();
                    MANTISSARESUL.Text = conversao[contContas].Mantissa.ToString();
                    EXPOENTERESUL.Text = conversao[contContas].Expoente.ToString();
                    SINALRESUL.Text = conversao[contContas].Sinal.ToString();
                    DECIMALRESUL.Text = conversao[contContas].numeroHexadecimal.ToString();
                }
                else
                {
                    DisplayAlert("Erro", "A soma deu 0", "TALKEY");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Digite um número", "TALKEY");
            }
        }
        private void MULTBOT(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs
        {
            try
            {
                if (soma != 0)
                {
                    var stream = GetStreamFromFile("Mult.mp3");
                    var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    audio.Load(stream);
                    audio.Play();
                    conversao[contContas] = new ConversaoDecimal(multiplicacao);
                    conversao[contContas].TransformarEmIEEESemIgualarCasas();
                    NUMRESUL.Text = multiplicacao.ToString();
                    MANTISSARESUL.Text = conversao[contContas].Mantissa.ToString();
                    EXPOENTERESUL.Text = conversao[contContas].Expoente.ToString();
                    SINALRESUL.Text = conversao[contContas].Sinal.ToString();
                    DECIMALRESUL.Text = conversao[contContas].numeroHexadecimal.ToString();
                }
                else
                {
                    DisplayAlert("Erro", "A soma deu 0", "TALKEY");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Digite um número", "TALKEY");
            }
        }
        private void DIVBOT(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs
        {
            try
            {
                if (soma != 0)
                {
                    var stream = GetStreamFromFile("Div.mp3");
                    var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                    audio.Load(stream);
                    audio.Play();
                    conversao[contContas] = new ConversaoDecimal(divisoa);
                    conversao[contContas].TransformarEmIEEESemIgualarCasas();
                    NUMRESUL.Text = divisoa.ToString();
                    MANTISSARESUL.Text = conversao[contContas].Mantissa.ToString();
                    EXPOENTERESUL.Text = conversao[contContas].Expoente.ToString();
                    SINALRESUL.Text = conversao[contContas].Sinal.ToString();
                    DECIMALRESUL.Text = conversao[contContas].numeroHexadecimal.ToString();
                }
                else
                {
                    DisplayAlert("Erro", "A soma deu 0", "TALKEY");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Digite um número", "TALKEY");
            }
        }
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("AppULA." + filename);

            return stream;
        }
    }
}