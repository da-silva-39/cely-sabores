using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    /// <summary>
    /// Desenha o recibo. A mesma rotina e usada na pre-visualizacao e na
    /// impressao, para o que se ve e o que sai na impressora serem iguais.
    /// </summary>
    public sealed class ReciboImpressao
    {
        public const string NomeRestaurante = "Cely Sabores";

        /// <summary>Largura do papel do recibo, em pixels, a 96 dpi.</summary>
        public const int Largura = 420;

        private const int Margem = 14;
        private const int ColunaQtd = 14;
        private const int ColunaDescricao = 46;
        private const int AlturaLinha = 20;
        private const int AlturaObservacao = 16;

        /// <summary>Espaco reservado para a ultima linha (rodape).</summary>
        private const int AlturaRodape = 22;

        private const int EspacamentoMinimoValor = 62;
        private const int EspacamentoMinimoDescricao = 120;

        private static readonly Color CorTexto = Color.FromArgb(40, 34, 28);
        private static readonly Color CorSuave = Color.FromArgb(120, 110, 100);
        private static readonly Color CorLaranja = Color.FromArgb(230, 119, 0);
        private static readonly Color CorDivisa = Color.FromArgb(235, 228, 220);

        private readonly Recibo _recibo;

        /// <summary>Coordenada vertical da ultima linha desenhada.</summary>
        private int _ultimoY;

        /// <summary>
        /// Altura exacta do recibo, medida com o proprio desenho. Derivar a
        /// altura da mesma rotina evita que o papel e o conteudo fiquem
        /// desalinhados quando o numero de itens muda.
        /// </summary>
        public int Altura { get; private set; }

        public ReciboImpressao(Recibo recibo)
        {
            _recibo = recibo;
            Altura = MedirAltura();
        }

        /// <summary>
        /// Cor de fundo do papel. branco para a pre-visualizacao e a impressao,
        /// que e o que o cliente leva.
        /// </summary>
        public static Color CorPapel { get { return Color.White; } }

        public void Desenhar(Graphics g)
        {
            if (g == null)
            {
                return;
            }

            int largura = Largura;
            int y = 0;

            // ---------- cabecalho ----------
            g.DrawString(NomeRestaurante, new Font("Segoe UI", 17F, FontStyle.Bold),
                new SolidBrush(CorLaranja), Margem, y + 8);
            y += 34;

            var fontePequena = new Font("Segoe UI", 9F);
            var pincelSuave = new SolidBrush(CorSuave);
            g.DrawString("Restaurante", fontePequena, pincelSuave, Margem, y);
            g.DrawString("Maputo, Moçambique", fontePequena, pincelSuave, Margem, y + 14);
            y += 40;

            DesenharDivisa(g, largura, ref y);
            y += 12;

            // ---------- dados ----------
            y = Linha(g, "Recibo nº", "#" + _recibo.NumeroPedido, y, largura);
            y = Linha(g, "Data", _recibo.DataHora.ToString("dd/MM/yyyy HH:mm"), y, largura);
            y = Linha(g, "Mesa", _recibo.NumeroMesa.ToString(), y, largura);
            y = Linha(g, "Cliente",
                string.IsNullOrEmpty(_recibo.NomeCliente) ? "Balcão" : _recibo.NomeCliente, y, largura);
            y = Linha(g, "Atendente", _recibo.FuncionarioNome, y, largura);

            if (_recibo.ReimpressoEm.HasValue)
            {
                y = Linha(g, "Reimpressão",
                    _recibo.ReimpressoEm.Value.ToString("dd/MM/yyyy HH:mm"), y, largura);
            }

            y += 6;
            DesenharDivisa(g, largura, ref y);
            y += 10;

            // ---------- colunas dos itens ----------
            // as colunas dos valores medem o que realmente precisao, para nunca
            // invadirem a descricao do prato, qualquer que seja o preco
            var fonteItem = new Font("Segoe UI", 9.5F);
            int espacoPreco = Math.Max(EspacamentoMinimoValor, MedirMaiorValor(g, fonteItem, false, _recibo.Itens));
            int espacoSubtotal = Math.Max(EspacamentoMinimoValor, MedirMaiorValor(g, fonteItem, true, _recibo.Itens));

            int fimPreco = largura - Margem - espacoSubtotal - 12;
            int limiteDescricao = fimPreco - 8;

            var fonteColuna = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            var pincelColuna = new SolidBrush(CorSuave);
            g.DrawString("Qtd", fonteColuna, pincelColuna, ColunaQtd, y);
            g.DrawString("Descrição", fonteColuna, pincelColuna, ColunaDescricao, y);
            DesenharDireita(g, "P. Unit.", fonteColuna, pincelColuna, y,
                fimPreco - espacoPreco, fimPreco);
            DesenharDireita(g, "Subtotal", fonteColuna, pincelColuna, y,
                largura - Margem - espacoSubtotal, largura - Margem);
            y += 16;

            // ---------- itens ----------
            var fonteObs = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            var pincelTexto = new SolidBrush(CorTexto);
            int espacoDescricao = limiteDescricao - ColunaDescricao;

            foreach (var item in _recibo.Itens)
            {
                g.DrawString(item.Quantidade.ToString(), fonteItem, pincelTexto, ColunaQtd, y);
                g.DrawString(Ajustar(g, item.Prato, fonteItem, espacoDescricao),
                    fonteItem, pincelTexto, ColunaDescricao, y);
                DesenharDireita(g, Tema.Moeda(item.PrecoUnitario), fonteItem, pincelTexto, y,
                    fimPreco - espacoPreco, fimPreco);
                DesenharDireita(g, Tema.Moeda(item.Subtotal), fonteItem, pincelTexto, y,
                    largura - Margem - espacoSubtotal, largura - Margem);
                y += AlturaLinha;

                if (!string.IsNullOrEmpty(item.Observacao))
                {
                    g.DrawString(
                        Ajustar(g, "obs: " + item.Observacao, fonteObs, espacoDescricao),
                        fonteObs, pincelSuave, ColunaDescricao, y);
                    y += AlturaObservacao;
                }
            }

            y += 4;
            DesenharDivisa(g, largura, ref y);
            y += 12;

            // ---------- totais ----------
            var fonteTotal = new Font("Segoe UI", 12F, FontStyle.Bold);
            var fonteLinha = new Font("Segoe UI", 10F);

            y = Linha(g, "Total", Tema.Moeda(_recibo.Total), y, largura, fonteTotal, true);
            y = Linha(g, "Valor recebido", Tema.Moeda(_recibo.ValorRecebido), y, largura, fonteLinha, false);
            y = Linha(g, "Troco", Tema.Moeda(_recibo.Troco), y, largura, fonteLinha, false);

            y += 14;

            g.DrawString("Obrigado pela sua visita!", new Font("Segoe UI", 9.5F, FontStyle.Italic),
                pincelSuave, Margem, y);

            _ultimoY = y;
        }

        /// <summary>
        /// Mede a altura correndo o proprio desenho numa superficie minima. Nao
        /// ha formulas de altura para manter em sintonia com o desenho.
        /// </summary>
        private int MedirAltura()
        {
            using (var probe = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(probe))
            {
                Desenhar(g);
                return _ultimoY + AlturaRodape;
            }
        }

        private static void DesenharDivisa(Graphics g, int largura, ref int y)
        {
            using (var pen = new Pen(CorDivisa))
            {
                g.DrawLine(pen, Margem, y, largura - Margem, y);
            }
        }

        private static void DesenharDireita(Graphics g, string texto, Font fonte, Brush pincel,
            int y, int inicio, int fim)
        {
            var tamanho = g.MeasureString(texto, fonte);
            g.DrawString(texto, fonte, pincel, fim - tamanho.Width, y);
        }

        private static int Linha(Graphics g, string etiqueta, string valor, int y, int largura)
        {
            return Linha(g, etiqueta, valor, y, largura, new Font("Segoe UI", 9.5F), false);
        }

        private static int Linha(Graphics g, string etiqueta, string valor, int y, int largura,
            Font fonte, bool negrito)
        {
            var pincelRotulo = negrito ? new SolidBrush(CorTexto) : new SolidBrush(CorSuave);
            g.DrawString(etiqueta, new Font(fonte, FontStyle.Regular), pincelRotulo, Margem, y);

            var tamanho = g.MeasureString(valor, fonte);
            g.DrawString(valor, fonte, new SolidBrush(CorTexto), largura - Margem - tamanho.Width, y);

            return y + fonte.Height + 2;
        }

        /// <summary>Corta o texto com reticencias para caber na largura disponivel.</summary>
        private static string Ajustar(Graphics g, string texto, Font fonte, int larguraMaxima)
        {
            if (string.IsNullOrEmpty(texto) || larguraMaxima <= 0)
            {
                return string.Empty;
            }

            if (g.MeasureString(texto, fonte).Width <= larguraMaxima)
            {
                return texto;
            }

            string corte = texto;
            while (corte.Length > 1 && g.MeasureString(corte + "...", fonte).Width > larguraMaxima)
            {
                corte = corte.Substring(0, corte.Length - 1);
            }

            return corte + "...";
        }

        /// <summary>Espaco necessario para o maior valor a mostrar, com folga.</summary>
        private static int MedirMaiorValor(Graphics g, Font fonte, bool subtotal, IList<ReciboItem> itens)
        {
            double maior = 0;
            foreach (var item in itens)
            {
                var texto = Tema.Moeda(subtotal ? item.Subtotal : item.PrecoUnitario);
                double tamanho = g.MeasureString(texto, fonte).Width;
                if (tamanho > maior)
                {
                    maior = tamanho;
                }
            }

            return (int)Math.Ceiling(maior) + 6;
        }

        /// <summary>
        /// Centra o recibo dentro da area util da pagina. E o que a impressao
        /// usa, por isso o que se ve na pre-visualizacao e o que sai impresso
        /// ficam iguais.
        /// </summary>
        public void DesenharNaPagina(Graphics g, Rectangle area)
        {
            int x = (area.Width - Largura) / 2;
            int y = Math.Max(10, (area.Height - Altura) / 4);

            var estado = g.Save();
            g.TranslateTransform(x, y);
            Desenhar(g);
            g.Restore(estado);
        }

        /// <summary>Documento pronto a imprimir, com o recibo centrado na pagina.</summary>
        public PrintDocument CriarDocumento()
        {
            var documento = new PrintDocument();
            var recibo = this;

            documento.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);
            documento.DocumentName = "Recibo " + _recibo.NumeroPedido;
            documento.OriginAtMargins = false;

            documento.PrintPage += delegate(object sender, PrintPageEventArgs e)
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                recibo.DesenharNaPagina(g, e.MarginBounds);
            };

            return documento;
        }
    }
}
