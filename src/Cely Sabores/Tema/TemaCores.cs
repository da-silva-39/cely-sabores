using System.Drawing;

namespace Cely_Sabores.Tema
{
    internal static class TemaCores
    {
        public static readonly Color Primaria = Color.FromArgb(255, 145, 0);
        public static readonly Color PrimariaEscura = Color.FromArgb(230, 115, 0);
        public static readonly Color PrimariaClara = Color.FromArgb(255, 224, 178);
        public static readonly Color Fundo = Color.FromArgb(247, 244, 240);
        public static readonly Color Lateral = Color.FromArgb(253, 250, 246);
        public static readonly Color Bordas = Color.FromArgb(227, 221, 213);
        public static readonly Color Texto = Color.FromArgb(52, 49, 44);
        public static readonly Color TextoSuave = Color.FromArgb(150, 146, 140);
        public static readonly Color Branco = Color.White;
        public static readonly Color Aviso = Color.FromArgb(211, 47, 47{

        public static Font Titulo()
        {
            return new Font("Segoe UI", 20F, FontStyle.Bold);
        }

        public static Font Subtitulo()
        {
            return new Font("Segoe UI", 10F, FontStyle.Regular);
        }

        public static Font Normal()
        {
            return new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        public static Font Negrito()
        {
            return new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        public static Font CardValor()
        {
            return new Font("Segoe UI", 15F, FontStyle.Bold);
        }

        public static Color CorMesa(int estado)
        {
            switch (estado)
            {
                case 1: return Livre;
                case 2: return Ocupada;
                case 3: return Reservada;
                case 4: return Atendimento;
                case 5: return AguardandoPagamento;
                default: return Livre;
            }
        }
    }
}
