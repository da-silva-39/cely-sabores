using System;
using System.Drawing;
using System.Windows.Forms;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    /// <summary>
    /// Pre-visualizacao do recibo, com opcao de imprimir. O desenho e feito
    /// com a mesma rotina da impressao, para o resultado ser identico.
    /// O layout esta em FormularioRecibo.Designer.cs.
    /// </summary>
    public sealed partial class FormularioRecibo : Form
    {
        private readonly Recibo _recibo;
        private readonly ReciboImpressao _desenho;

        // Construtor usado pelo designer: nao desenha o recibo.
        public FormularioRecibo()
        {
            InitializeComponent();

            btnImprimir.Click += (s, ev) => Executar(Imprimir);
            btnFechar.Click += (s, ev) => Close();
        }

        public FormularioRecibo(Recibo recibo)
            : this()
        {
            _recibo = recibo;
            _desenho = new ReciboImpressao(recibo);

            Carregar();
        }

        // Titulo e pre-visualizacao dependem do recibo recebido, por isso
        // ficam fora do construtor parameterless.
        private void Carregar()
        {
            Text = "Recibo do pedido " + _recibo.NumeroPedido
                + (_recibo.ReimpressoEm.HasValue ? " (reimpressão)" : "");

            GerarPrevia();
        }

        private void GerarPrevia()
        {
            int largura = ReciboImpressao.Largura;
            int altura = _desenho.Altura;

            using (var bitmap = new Bitmap(largura, altura))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.Clear(ReciboImpressao.CorPapel);
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    _desenho.Desenhar(g);
                }

                previa.Image = new Bitmap(bitmap);
            }

            previa.Height = altura;
        }

        private void Executar(Action acao)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                acao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível imprimir o recibo: " + ex.Message,
                    "Cely Sabores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void Imprimir()
        {
            using (var documento = _desenho.CriarDocumento())
            using (var dialogo = new PrintDialog
            {
                Document = documento,
                AllowSelection = true,
                AllowSomePages = false,
                UseEXDialog = true
            })
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                documento.Print();
            }

            MessageBox.Show("Recibo enviado para a impressora.", "Cely Sabores",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && previa.Image != null)
            {
                var imagem = previa.Image;
                previa.Image = null;
                imagem.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
