using System;
using System.ComponentModel;
using System.Windows.Forms;
using CelySabores.Business.Services;
using CelySabores.Models.Dtos;

namespace Cely_Sabores
{
    // O layout está em PainelRelatorios.Designer.cs, para se poder ajustar tudo
    // no designer do Visual Studio. Aqui fica apenas a lógica.
    public sealed partial class PainelRelatorios : PainelBase
    {
        private readonly RelatorioService _relatorioService;

        private RelatorioCompleto _relatorio;

        // Construtor usado pelo designer: não toca na base de dados.
        public PainelRelatorios()
            : base("Relatórios", "Carregando...")
        {
            InitializeComponent();
        }

        public PainelRelatorios(RelatorioService relatorioService)
            : this()
        {
            _relatorioService = relatorioService;

            // o intervalo por omissão depende do dia de hoje: os campos ficam
            // no Designer, mas os valores só se podem pôr aqui
            dtpDe.Value = DateTime.Today.AddDays(-6);
            dtpAte.Value = DateTime.Today;

            dtpDe.ValueChanged += (s, ev) => Executar(Recarregar);
            dtpAte.ValueChanged += (s, ev) => Executar(Recarregar);

            AdicionarAcao("Actualizar", false, Recarregar);
            AdicionarAcao("Exportar CSV", false, ExportarCsv);

            // no designer não se toca na base de dados
            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                Recarregar();
            }
        }

        public override void Recarregar()
        {
            _relatorio = _relatorioService.Gerar(dtpDe.Value, dtpAte.Value);

            DesenharCartoes();
            DesenharDia();
            DesenharFuncionario();
            DesenharPrato();
            DesenharReservas();
            DesenharMesas();
            DesenharEstoque();

            DefinirStatus("De " + _relatorio.De.ToString("dd/MM/yyyy")
                + " até " + _relatorio.Ate.ToString("dd/MM/yyyy")
                + "  ·  " + _relatorio.Vendas.PedidosFechados + " pedido(s) fechado(s)"
                + "  ·  " + _relatorio.Reservas.Total + " reserva(s)"
                + "  ·  " + _relatorio.Estoque.IngredientesBaixo + " ingrediente(s) baixo(s)");
        }

        private void DesenharCartoes()
        {
            var v = _relatorio.Vendas;
            var m = _relatorio.Mesas;
            var e = _relatorio.Estoque;

            pnlCartoes.Controls.Clear();

            pnlCartoes.Controls.Add(Tema.Cartao("Faturamento", Tema.Moeda(v.Faturamento), Tema.LaranjaEscura));
            pnlCartoes.Controls.Add(Tema.Cartao("Pedidos fechados",
                v.PedidosFechados.ToString(), Tema.Texto));
            pnlCartoes.Controls.Add(Tema.Cartao("Ticket médio",
                Tema.Moeda(v.TicketMedio), Tema.Verde));
            pnlCartoes.Controls.Add(Tema.Cartao("Itens vendidos",
                v.ItensVendidos.ToString(), Tema.Texto));
            pnlCartoes.Controls.Add(Tema.Cartao("Reservas",
                _relatorio.Reservas.Total.ToString(), Tema.Texto));
            pnlCartoes.Controls.Add(Tema.Cartao("Ocupação de mesas",
                m.PercentagemOcupacao.ToString("0.#") + " %", Tema.Texto));
            pnlCartoes.Controls.Add(Tema.Cartao("Ingredientes baixos",
                e.IngredientesBaixo.ToString(),
                e.IngredientesBaixo > 0 ? Tema.Perigo : Tema.Texto));
            pnlCartoes.Controls.Add(Tema.Cartao("Custo de reposição",
                Tema.Moeda(e.ValorReposicao), Tema.Texto));
        }

        private void DesenharDia()
        {
            var v = _relatorio.Vendas;
            cabDia.Text = "Vendas por dia  ·  " + v.PedidosFechados + " pedido(s), "
                + Tema.Moeda(v.Faturamento) + ", ticket médio " + Tema.Moeda(v.TicketMedio);

            dgvDia.Rows.Clear();

            foreach (var linha in v.PorDia)
            {
                dgvDia.Rows.Add(
                    linha.Dia.ToString("dd/MM/yyyy"),
                    linha.PedidosFechados.ToString(),
                    Tema.Moeda(linha.Faturamento),
                    Tema.Moeda(linha.TicketMedio));
            }

            if (v.PorDia.Count == 0)
            {
                dgvDia.Rows.Add("(sem vendas no intervalo)");
            }
        }

        private void DesenharFuncionario()
        {
            var v = _relatorio.Vendas;
            cabFuncionario.Text = "Vendas por funcionário  ·  recebido "
                + Tema.Moeda(v.TotalRecebido) + "  ·  troco " + Tema.Moeda(v.TotalTroco);

            dgvFuncionario.Rows.Clear();

            foreach (var linha in v.PorFuncionario)
            {
                dgvFuncionario.Rows.Add(
                    linha.Nome,
                    linha.PedidosFechados.ToString(),
                    Tema.Moeda(linha.Faturamento),
                    Tema.Moeda(linha.TotalRecebido),
                    Tema.Moeda(linha.TotalTroco));
            }

            if (v.PorFuncionario.Count == 0)
            {
                dgvFuncionario.Rows.Add("(sem vendas no intervalo)");
            }
        }

        private void DesenharPrato()
        {
            var v = _relatorio.Vendas;
            cabPrato.Text = "Vendas por prato  ·  " + v.ItensVendidos + " item(ns), valor médio "
                + Tema.Moeda(v.ValorMedioPrato);

            dgvPrato.Rows.Clear();

            foreach (var linha in v.PorPrato)
            {
                dgvPrato.Rows.Add(
                    linha.Nome,
                    linha.Quantidade.ToString(),
                    Tema.Moeda(linha.Faturamento));
            }

            if (v.PorPrato.Count == 0)
            {
                dgvPrato.Rows.Add("(sem vendas no intervalo)");
            }
        }

        private void DesenharReservas()
        {
            var r = _relatorio.Reservas;

            cabReservaDia.Text = "Reservas por dia  ·  " + r.Total + " reserva(s) para "
                + r.PessoasPrevistas + " pessoa(s)  ·  confirmadas " + r.Confirmadas
                + "  ·  canceladas " + r.Canceladas;

            dgvReservaDia.Rows.Clear();

            foreach (var linha in r.PorDia)
            {
                dgvReservaDia.Rows.Add(
                    linha.Dia.ToString("dd/MM/yyyy"),
                    linha.Reservas.ToString(),
                    linha.Pessoas.ToString(),
                    linha.Confirmadas.ToString(),
                    linha.Compareceram.ToString(),
                    linha.Canceladas.ToString());
            }

            if (r.PorDia.Count == 0)
            {
                dgvReservaDia.Rows.Add("(sem reservas no intervalo)");
            }

            cabReservaEstado.Text = "Reservas por estado  ·  compareceram " + r.Compareceram
                + "  ·  " + r.PessoasPerdidas + " pessoa(s) perdidas por cancelamento";

            dgvReservaEstado.Rows.Clear();

            foreach (var linha in r.PorEstado)
            {
                dgvReservaEstado.Rows.Add(
                    linha.Estado,
                    linha.Reservas.ToString(),
                    linha.Pessoas.ToString());
            }

            if (r.PorEstado.Count == 0)
            {
                dgvReservaEstado.Rows.Add("(sem reservas no intervalo)");
            }
        }

        private void DesenharMesas()
        {
            var m = _relatorio.Mesas;

            cabMesa.Text = "Mesas utilizadas  ·  " + m.MesasUtilizadas + " de " + m.MesasAtivas
                + " mesa(s) ativas (" + m.PercentagemOcupacao.ToString("0.#") + " %)  ·  "
                + m.MesasOcupadasAgora + " ocupada(s) neste momento  ·  " + Tema.Moeda(m.Faturamento);

            dgvMesa.Rows.Clear();

            foreach (var linha in m.PorMesa)
            {
                dgvMesa.Rows.Add(
                    linha.Numero.ToString(),
                    linha.Capacidade.ToString(),
                    linha.Pedidos.ToString(),
                    Tema.Moeda(linha.Faturamento),
                    Tema.Moeda(linha.TicketMedio));
            }

            if (m.PorMesa.Count == 0)
            {
                dgvMesa.Rows.Add("(sem pedidos fechados no intervalo)");
            }
        }

        private void DesenharEstoque()
        {
            var e = _relatorio.Estoque;

            cabEstoque.Text = e.IngredientesBaixo == 0
                ? "Estoque baixo  ·  nenhum ingrediente abaixo do mínimo (" + e.IngredientesActivos + " activo(s))"
                : "Estoque baixo  ·  " + e.IngredientesBaixo + " de " + e.IngredientesActivos
                    + " activo(s) abaixo do mínimo  ·  reposição estimada " + Tema.Moeda(e.ValorReposicao);
            cabEstoque.ForeColor = e.IngredientesBaixo > 0 ? Tema.Perigo : Tema.Texto;

            dgvEstoque.Rows.Clear();

            foreach (var linha in e.Baixo)
            {
                var falta = linha.QuantidadeMinima - linha.QuantidadeDisponivel;

                dgvEstoque.Rows.Add(
                    linha.Nome,
                    linha.Unidade,
                    Qtd(linha.QuantidadeDisponivel),
                    Qtd(linha.QuantidadeMinima),
                    Qtd(falta),
                    Tema.Moeda(Math.Round(falta * linha.PrecoCusto, 2)));
            }

            if (e.Baixo.Count == 0)
            {
                dgvEstoque.Rows.Add("(nenhum ingrediente abaixo do mínimo)");
            }
        }

        private void ExportarCsv()
        {
            if (_relatorio == null || SemDados())
            {
                Aviso("Não há dados para exportar no intervalo escolhido.", MessageBoxIcon.Information);
                return;
            }

            var v = _relatorio.Vendas;
            var r = _relatorio.Reservas;
            var m = _relatorio.Mesas;
            var e = _relatorio.Estoque;

            using (var dialogo = new SaveFileDialog
            {
                Filter = "CSV (*.csv)|*.csv|Texto (*.txt)|*.txt",
                FileName = "relatorio_" + _relatorio.De.ToString("yyyyMMdd") + "_"
                    + _relatorio.Ate.ToString("yyyyMMdd") + ".csv"
            })
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (var w = new System.IO.StreamWriter(
                        dialogo.FileName, false, System.Text.Encoding.UTF8))
                    {
                        w.WriteLine("Relatório Cely Sabores");
                        w.WriteLine("Gerado em;{0:dd/MM/yyyy HH:mm}", _relatorio.GeradoEm);
                        w.WriteLine("De;{0:dd/MM/yyyy}", _relatorio.De);
                        w.WriteLine("Até;{0:dd/MM/yyyy}", _relatorio.Ate);
                        w.WriteLine();

                        w.WriteLine("VENDAS");
                        w.WriteLine("Pedidos fechados;" + v.PedidosFechados);
                        w.WriteLine("Pedidos cancelados;" + v.PedidosCancelados);
                        w.WriteLine("Itens vendidos;" + v.ItensVendidos);
                        w.WriteLine("Faturamento;" + v.Faturamento.ToString("F2"));
                        w.WriteLine("Ticket medio;" + v.TicketMedio.ToString("F2"));
                        w.WriteLine("Valor medio por prato;" + v.ValorMedioPrato.ToString("F2"));
                        w.WriteLine("Total recebido;" + v.TotalRecebido.ToString("F2"));
                        w.WriteLine("Troco;" + v.TotalTroco.ToString("F2"));
                        w.WriteLine();
                        w.WriteLine("Por dia");
                        w.WriteLine("Dia;Pedidos;Faturamento;Ticket medio");

                        foreach (var l in v.PorDia)
                        {
                            w.WriteLine("{0:dd/MM/yyyy};{1};{2};{3}",
                                l.Dia, l.PedidosFechados, l.Faturamento.ToString("F2"),
                                l.TicketMedio.ToString("F2"));
                        }

                        w.WriteLine();
                        w.WriteLine("Por funcionario");
                        w.WriteLine("Funcionario;Pedidos;Faturamento;Recebido;Troco");

                        foreach (var l in v.PorFuncionario)
                        {
                            w.WriteLine("{0};{1};{2};{3};{4}", l.Nome, l.PedidosFechados,
                                l.Faturamento.ToString("F2"), l.TotalRecebido.ToString("F2"),
                                l.TotalTroco.ToString("F2"));
                        }

                        w.WriteLine();
                        w.WriteLine("Por prato");
                        w.WriteLine("Prato;Quantidade;Faturamento");

                        foreach (var l in v.PorPrato)
                        {
                            w.WriteLine("{0};{1};{2}", l.Nome, l.Quantidade, l.Faturamento.ToString("F2"));
                        }

                        w.WriteLine();
                        w.WriteLine("RESERVAS");
                        w.WriteLine("Total;" + r.Total);
                        w.WriteLine("Confirmadas;" + r.Confirmadas);
                        w.WriteLine("Compareceram;" + r.Compareceram);
                        w.WriteLine("Canceladas;" + r.Canceladas);
                        w.WriteLine("Pessoas previstas;" + r.PessoasPrevistas);
                        w.WriteLine("Pessoas perdidas;" + r.PessoasPerdidas);
                        w.WriteLine();
                        w.WriteLine("Reservas por dia");
                        w.WriteLine("Dia;Reservas;Pessoas;Confirmadas;Compareceram;Canceladas");

                        foreach (var l in r.PorDia)
                        {
                            w.WriteLine("{0:dd/MM/yyyy};{1};{2};{3};{4};{5}",
                                l.Dia, l.Reservas, l.Pessoas, l.Confirmadas, l.Compareceram, l.Canceladas);
                        }

                        w.WriteLine();
                        w.WriteLine("Reservas por estado");
                        w.WriteLine("Estado;Reservas;Pessoas");

                        foreach (var l in r.PorEstado)
                        {
                            w.WriteLine("{0};{1};{2}", l.Estado, l.Reservas, l.Pessoas);
                        }

                        w.WriteLine();
                        w.WriteLine("MESAS UTILIZADAS");
                        w.WriteLine("Mesas ativas;" + m.MesasAtivas);
                        w.WriteLine("Mesas utilizadas;" + m.MesasUtilizadas);
                        w.WriteLine("Mesas ocupadas agora;" + m.MesasOcupadasAgora);
                        w.WriteLine("Percentagem ocupacao;" + m.PercentagemOcupacao.ToString("F1"));
                        w.WriteLine("Faturamento;" + m.Faturamento.ToString("F2"));
                        w.WriteLine("Ticket medio;" + m.TicketMedio.ToString("F2"));
                        w.WriteLine();
                        w.WriteLine("Mesa;Lugares;Pedidos;Faturamento;Ticket medio");

                        foreach (var l in m.PorMesa)
                        {
                            w.WriteLine("{0};{1};{2};{3};{4}", l.Numero, l.Capacidade, l.Pedidos,
                                l.Faturamento.ToString("F2"), l.TicketMedio.ToString("F2"));
                        }

                        w.WriteLine();
                        w.WriteLine("ESTOQUE BAIXO (fotografia de {0:dd/MM/yyyy HH:mm})", _relatorio.GeradoEm);
                        w.WriteLine("Ingredientes activos;" + e.IngredientesActivos);
                        w.WriteLine("Ingredientes abaixo do minimo;" + e.IngredientesBaixo);
                        w.WriteLine("Custo de reposicao;" + e.ValorReposicao.ToString("F2"));
                        w.WriteLine();
                        w.WriteLine("Ingrediente;Unidade;Disponivel;Minimo;Falta;Custo reposicao");

                        foreach (var l in e.Baixo)
                        {
                            var falta = l.QuantidadeMinima - l.QuantidadeDisponivel;
                            w.WriteLine("{0};{1};{2};{3};{4};{5}", l.Nome, l.Unidade,
                                l.QuantidadeDisponivel.ToString("0.###"),
                                l.QuantidadeMinima.ToString("0.###"),
                                falta.ToString("0.###"),
                                Math.Round(falta * l.PrecoCusto, 2).ToString("F2"));
                        }
                    }

                    Aviso("Relatório guardado em:\n" + dialogo.FileName, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Aviso("Não foi possível gravar o ficheiro:\n" + ex.Message, MessageBoxIcon.Error);
                }
            }
        }

        private bool SemDados()
        {
            return _relatorio.Vendas.PedidosFechados == 0
                && _relatorio.Reservas.Total == 0
                && _relatorio.Mesas.MesasUtilizadas == 0
                && _relatorio.Estoque.IngredientesBaixo == 0;
        }

        private static string Qtd(decimal valor)
        {
            return valor.ToString("0.###");
        }
    }
}
