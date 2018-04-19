using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;

namespace TesteMensagemPinPad
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnConfirmacaoPinPad;
		private System.Windows.Forms.Button btnConfigura;
		private System.Windows.Forms.Button btnAbre;
		private System.Windows.Forms.Button btnFecha;
		private System.Windows.Forms.Button btnLeCartao;
		private System.Windows.Forms.TextBox textBox1;
		private Button btnVenda;
		private GroupBox grbxTipoVenda;
		private Label lblParcelas;
		private TrackBar trackBarParcelas;
		private ComboBox cboTipoCredito;
		private Label label1;
		private RadioButton rdTipoVendaCredito;
		private RadioButton rdTipoVendaDebito;
		private GroupBox grbxOpcoesCredito;
        private GroupBox grbxOutros;
		private TextBox txtLog;
        private Button button1;
        private TextBox txtCodigoSeguranca;
        private Label label2;
        private GroupBox grbxOpcoesDebito;
        private RadioButton rdTipoVendaDebitoPreDatado;
        private RadioButton rdTipoVendaDebitoVista;
        private DateTimePicker dtPickerPreDatado;
        private Label label3;
        private ComboBox cboTipoCartao;

		private CliSitefAPI clisitef;

		public Form1()
		{
			clisitef = new CliSitefAPI();

			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnConfigura = new System.Windows.Forms.Button();
            this.btnAbre = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnConfirmacaoPinPad = new System.Windows.Forms.Button();
            this.btnLeCartao = new System.Windows.Forms.Button();
            this.btnVenda = new System.Windows.Forms.Button();
            this.grbxTipoVenda = new System.Windows.Forms.GroupBox();
            this.grbxOpcoesDebito = new System.Windows.Forms.GroupBox();
            this.rdTipoVendaDebitoPreDatado = new System.Windows.Forms.RadioButton();
            this.rdTipoVendaDebitoVista = new System.Windows.Forms.RadioButton();
            this.dtPickerPreDatado = new System.Windows.Forms.DateTimePicker();
            this.grbxOpcoesCredito = new System.Windows.Forms.GroupBox();
            this.txtCodigoSeguranca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblParcelas = new System.Windows.Forms.Label();
            this.cboTipoCredito = new System.Windows.Forms.ComboBox();
            this.trackBarParcelas = new System.Windows.Forms.TrackBar();
            this.rdTipoVendaCredito = new System.Windows.Forms.RadioButton();
            this.rdTipoVendaDebito = new System.Windows.Forms.RadioButton();
            this.grbxOutros = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoCartao = new System.Windows.Forms.ComboBox();
            this.grbxTipoVenda.SuspendLayout();
            this.grbxOpcoesDebito.SuspendLayout();
            this.grbxOpcoesCredito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarParcelas)).BeginInit();
            this.grbxOutros.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfigura
            // 
            this.btnConfigura.Location = new System.Drawing.Point(16, 16);
            this.btnConfigura.Name = "btnConfigura";
            this.btnConfigura.Size = new System.Drawing.Size(219, 24);
            this.btnConfigura.TabIndex = 0;
            this.btnConfigura.Text = "1 - Configura";
            this.btnConfigura.Click += new System.EventHandler(this.btnConfigura_Click);
            // 
            // btnAbre
            // 
            this.btnAbre.Location = new System.Drawing.Point(16, 48);
            this.btnAbre.Name = "btnAbre";
            this.btnAbre.Size = new System.Drawing.Size(219, 24);
            this.btnAbre.TabIndex = 2;
            this.btnAbre.Text = "2 - Abre PinPad";
            this.btnAbre.Click += new System.EventHandler(this.btnAbre_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.Location = new System.Drawing.Point(16, 411);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(212, 24);
            this.btnFecha.TabIndex = 3;
            this.btnFecha.Text = "4 - Fecha PinPad";
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Mensagem PinPad";
            // 
            // btnConfirmacaoPinPad
            // 
            this.btnConfirmacaoPinPad.Location = new System.Drawing.Point(11, 53);
            this.btnConfirmacaoPinPad.Name = "btnConfirmacaoPinPad";
            this.btnConfirmacaoPinPad.Size = new System.Drawing.Size(96, 24);
            this.btnConfirmacaoPinPad.TabIndex = 5;
            this.btnConfirmacaoPinPad.Text = "Sim/Nao PinPad";
            this.btnConfirmacaoPinPad.Click += new System.EventHandler(this.btnConfirmacaoPinPad_Click);
            // 
            // btnLeCartao
            // 
            this.btnLeCartao.Location = new System.Drawing.Point(117, 53);
            this.btnLeCartao.Name = "btnLeCartao";
            this.btnLeCartao.Size = new System.Drawing.Size(96, 24);
            this.btnLeCartao.TabIndex = 6;
            this.btnLeCartao.Text = "Le cartao";
            this.btnLeCartao.Click += new System.EventHandler(this.btnLeCartao_Click);
            // 
            // btnVenda
            // 
            this.btnVenda.Location = new System.Drawing.Point(7, 297);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(201, 24);
            this.btnVenda.TabIndex = 1;
            this.btnVenda.Text = "3 - Venda";
            this.btnVenda.Click += new System.EventHandler(this.btnVenda_Click);
            // 
            // grbxTipoVenda
            // 
            this.grbxTipoVenda.Controls.Add(this.grbxOpcoesDebito);
            this.grbxTipoVenda.Controls.Add(this.grbxOpcoesCredito);
            this.grbxTipoVenda.Controls.Add(this.rdTipoVendaCredito);
            this.grbxTipoVenda.Controls.Add(this.btnVenda);
            this.grbxTipoVenda.Controls.Add(this.rdTipoVendaDebito);
            this.grbxTipoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbxTipoVenda.Location = new System.Drawing.Point(16, 78);
            this.grbxTipoVenda.Name = "grbxTipoVenda";
            this.grbxTipoVenda.Size = new System.Drawing.Size(219, 327);
            this.grbxTipoVenda.TabIndex = 7;
            this.grbxTipoVenda.TabStop = false;
            this.grbxTipoVenda.Text = "Tipo de Venda";
            // 
            // grbxOpcoesDebito
            // 
            this.grbxOpcoesDebito.Controls.Add(this.rdTipoVendaDebitoPreDatado);
            this.grbxOpcoesDebito.Controls.Add(this.rdTipoVendaDebitoVista);
            this.grbxOpcoesDebito.Controls.Add(this.dtPickerPreDatado);
            this.grbxOpcoesDebito.Location = new System.Drawing.Point(7, 227);
            this.grbxOpcoesDebito.Name = "grbxOpcoesDebito";
            this.grbxOpcoesDebito.Size = new System.Drawing.Size(201, 62);
            this.grbxOpcoesDebito.TabIndex = 9;
            this.grbxOpcoesDebito.TabStop = false;
            this.grbxOpcoesDebito.Text = "Opcoes de Debito";
            // 
            // rdTipoVendaDebitoPreDatado
            // 
            this.rdTipoVendaDebitoPreDatado.AutoSize = true;
            this.rdTipoVendaDebitoPreDatado.Checked = true;
            this.rdTipoVendaDebitoPreDatado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTipoVendaDebitoPreDatado.Location = new System.Drawing.Point(110, 13);
            this.rdTipoVendaDebitoPreDatado.Name = "rdTipoVendaDebitoPreDatado";
            this.rdTipoVendaDebitoPreDatado.Size = new System.Drawing.Size(79, 17);
            this.rdTipoVendaDebitoPreDatado.TabIndex = 11;
            this.rdTipoVendaDebitoPreDatado.TabStop = true;
            this.rdTipoVendaDebitoPreDatado.Text = "Pre Datado";
            this.rdTipoVendaDebitoPreDatado.UseVisualStyleBackColor = true;
            this.rdTipoVendaDebitoPreDatado.CheckedChanged += new System.EventHandler(this.rdTipoVendaDebitoPreDatado_CheckedChanged);
            // 
            // rdTipoVendaDebitoVista
            // 
            this.rdTipoVendaDebitoVista.AutoSize = true;
            this.rdTipoVendaDebitoVista.Checked = true;
            this.rdTipoVendaDebitoVista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTipoVendaDebitoVista.Location = new System.Drawing.Point(9, 13);
            this.rdTipoVendaDebitoVista.Name = "rdTipoVendaDebitoVista";
            this.rdTipoVendaDebitoVista.Size = new System.Drawing.Size(58, 17);
            this.rdTipoVendaDebitoVista.TabIndex = 10;
            this.rdTipoVendaDebitoVista.TabStop = true;
            this.rdTipoVendaDebitoVista.Text = "A Vista";
            this.rdTipoVendaDebitoVista.UseVisualStyleBackColor = true;
            this.rdTipoVendaDebitoVista.CheckedChanged += new System.EventHandler(this.rdTipoVendaDebitoVista_CheckedChanged);
            // 
            // dtPickerPreDatado
            // 
            this.dtPickerPreDatado.Location = new System.Drawing.Point(6, 36);
            this.dtPickerPreDatado.Name = "dtPickerPreDatado";
            this.dtPickerPreDatado.Size = new System.Drawing.Size(188, 20);
            this.dtPickerPreDatado.TabIndex = 9;
            // 
            // grbxOpcoesCredito
            // 
            this.grbxOpcoesCredito.Controls.Add(this.label3);
            this.grbxOpcoesCredito.Controls.Add(this.cboTipoCartao);
            this.grbxOpcoesCredito.Controls.Add(this.txtCodigoSeguranca);
            this.grbxOpcoesCredito.Controls.Add(this.label2);
            this.grbxOpcoesCredito.Controls.Add(this.label1);
            this.grbxOpcoesCredito.Controls.Add(this.lblParcelas);
            this.grbxOpcoesCredito.Controls.Add(this.cboTipoCredito);
            this.grbxOpcoesCredito.Controls.Add(this.trackBarParcelas);
            this.grbxOpcoesCredito.Enabled = false;
            this.grbxOpcoesCredito.Location = new System.Drawing.Point(7, 42);
            this.grbxOpcoesCredito.Name = "grbxOpcoesCredito";
            this.grbxOpcoesCredito.Size = new System.Drawing.Size(203, 179);
            this.grbxOpcoesCredito.TabIndex = 6;
            this.grbxOpcoesCredito.TabStop = false;
            this.grbxOpcoesCredito.Text = "Opcoes de Credito";
            // 
            // txtCodigoSeguranca
            // 
            this.txtCodigoSeguranca.Location = new System.Drawing.Point(6, 123);
            this.txtCodigoSeguranca.Name = "txtCodigoSeguranca";
            this.txtCodigoSeguranca.Size = new System.Drawing.Size(184, 20);
            this.txtCodigoSeguranca.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Codigo Seguranca";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo de Credito";
            // 
            // lblParcelas
            // 
            this.lblParcelas.AutoSize = true;
            this.lblParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParcelas.Location = new System.Drawing.Point(6, 59);
            this.lblParcelas.Name = "lblParcelas";
            this.lblParcelas.Size = new System.Drawing.Size(121, 13);
            this.lblParcelas.TabIndex = 5;
            this.lblParcelas.Text = "Quantidade de Parcelas";
            // 
            // cboTipoCredito
            // 
            this.cboTipoCredito.FormattingEnabled = true;
            this.cboTipoCredito.Items.AddRange(new object[] {
            "A Vista",
            "Parcelado"});
            this.cboTipoCredito.Location = new System.Drawing.Point(9, 30);
            this.cboTipoCredito.Name = "cboTipoCredito";
            this.cboTipoCredito.Size = new System.Drawing.Size(184, 21);
            this.cboTipoCredito.TabIndex = 3;
            this.cboTipoCredito.SelectedIndexChanged += new System.EventHandler(this.cboTipoCredito_SelectedIndexChanged);
            // 
            // trackBarParcelas
            // 
            this.trackBarParcelas.Location = new System.Drawing.Point(6, 75);
            this.trackBarParcelas.Name = "trackBarParcelas";
            this.trackBarParcelas.Size = new System.Drawing.Size(184, 45);
            this.trackBarParcelas.TabIndex = 4;
            this.trackBarParcelas.Scroll += new System.EventHandler(this.trackBarParcelas_Scroll);
            // 
            // rdTipoVendaCredito
            // 
            this.rdTipoVendaCredito.AutoSize = true;
            this.rdTipoVendaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTipoVendaCredito.Location = new System.Drawing.Point(109, 19);
            this.rdTipoVendaCredito.Name = "rdTipoVendaCredito";
            this.rdTipoVendaCredito.Size = new System.Drawing.Size(58, 17);
            this.rdTipoVendaCredito.TabIndex = 1;
            this.rdTipoVendaCredito.Text = "Credito";
            this.rdTipoVendaCredito.UseVisualStyleBackColor = true;
            this.rdTipoVendaCredito.CheckedChanged += new System.EventHandler(this.rdTipoVendaCredito_CheckedChanged);
            // 
            // rdTipoVendaDebito
            // 
            this.rdTipoVendaDebito.AutoSize = true;
            this.rdTipoVendaDebito.Checked = true;
            this.rdTipoVendaDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTipoVendaDebito.Location = new System.Drawing.Point(7, 19);
            this.rdTipoVendaDebito.Name = "rdTipoVendaDebito";
            this.rdTipoVendaDebito.Size = new System.Drawing.Size(56, 17);
            this.rdTipoVendaDebito.TabIndex = 0;
            this.rdTipoVendaDebito.TabStop = true;
            this.rdTipoVendaDebito.Text = "Debito";
            this.rdTipoVendaDebito.UseVisualStyleBackColor = true;
            this.rdTipoVendaDebito.CheckedChanged += new System.EventHandler(this.rdTipoVendaDebito_CheckedChanged);
            // 
            // grbxOutros
            // 
            this.grbxOutros.Controls.Add(this.btnLeCartao);
            this.grbxOutros.Controls.Add(this.btnConfirmacaoPinPad);
            this.grbxOutros.Controls.Add(this.textBox1);
            this.grbxOutros.Enabled = false;
            this.grbxOutros.Location = new System.Drawing.Point(16, 438);
            this.grbxOutros.Name = "grbxOutros";
            this.grbxOutros.Size = new System.Drawing.Size(219, 89);
            this.grbxOutros.TabIndex = 8;
            this.grbxOutros.TabStop = false;
            this.grbxOutros.Text = "Outros Comandos";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(252, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(906, 481);
            this.txtLog.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 503);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "Limpar Log";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo de Cartao";
            // 
            // cboTipoCartao
            // 
            this.cboTipoCartao.FormattingEnabled = true;
            this.cboTipoCartao.Items.AddRange(new object[] {
            "Magnetico/Chip",
            "Digitado"});
            this.cboTipoCartao.Location = new System.Drawing.Point(9, 163);
            this.cboTipoCartao.Name = "cboTipoCartao";
            this.cboTipoCartao.Size = new System.Drawing.Size(184, 21);
            this.cboTipoCartao.TabIndex = 9;
            this.cboTipoCartao.SelectedIndexChanged += new System.EventHandler(this.cboTipoCartao_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1170, 532);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.grbxOutros);
            this.Controls.Add(this.grbxTipoVenda);
            this.Controls.Add(this.btnConfigura);
            this.Controls.Add(this.btnAbre);
            this.Controls.Add(this.btnFecha);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbxTipoVenda.ResumeLayout(false);
            this.grbxTipoVenda.PerformLayout();
            this.grbxOpcoesDebito.ResumeLayout(false);
            this.grbxOpcoesDebito.PerformLayout();
            this.grbxOpcoesCredito.ResumeLayout(false);
            this.grbxOpcoesCredito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarParcelas)).EndInit();
            this.grbxOutros.ResumeLayout(false);
            this.grbxOutros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//Inicializa Fluxo
			InicializaFluxoVenda();

		}

		#region FluxoVenda

		private void InicializaFluxoVenda()
		{
			btnConfigura.Enabled = true;
			btnAbre.Enabled = false;
			grbxTipoVenda.Enabled = false;
			btnFecha.Enabled = false;
			grbxTipoVenda.Enabled = false;

		}

		private void passoFluxoVenda(int passo)
		{

			switch (passo)
			{
				case 1:
					//Configuracao OK!
					btnConfigura.Enabled = false;
					btnAbre.Enabled = true;
					grbxTipoVenda.Enabled = false;
					btnFecha.Enabled = false;
					grbxTipoVenda.Enabled = false;
					break;
				case 2:
					//Abre PinPad OK!
					btnConfigura.Enabled = false;
					btnAbre.Enabled = false;
					grbxTipoVenda.Enabled = true;
					btnFecha.Enabled = true;
					grbxTipoVenda.Enabled = true;
					break;
				case 3:
					//Venda OK!
					btnConfigura.Enabled = false;
					btnAbre.Enabled = false;
					grbxTipoVenda.Enabled = true;
					btnFecha.Enabled = true;
					grbxTipoVenda.Enabled = true;
					break;
				case 4:
					//Fecha PinPad OK!
					btnConfigura.Enabled = true;
					btnAbre.Enabled = false;
					grbxTipoVenda.Enabled = false;
					btnFecha.Enabled = false;
					grbxTipoVenda.Enabled = false;
					break;
			}


		}

		#endregion



		private void btnConfirmacaoPinPad_Click(object sender, System.EventArgs e)
		{
			int retorno =  clisitef.LeConfirmacaoPinPad(textBox1.Text);

			//System.Windows.Forms.MessageBox.Show("Retorno Sim/Nao PinPad: [" + retorno.ToString() + "]", "Confirmacao PinPad");
			txtLog.Text += "Retorno Sin/Nao PinPad: [" + retorno.ToString() + "]" + Environment.NewLine;

		}

		private void btnConfigura_Click(object sender, System.EventArgs e)
		{
			int retorno = clisitef.Configura("127.0.0.1", "00000000", "SW000001");

			if (sender != null)
			{
				//System.Windows.Forms.MessageBox.Show("Retorno Configura: [" + retorno.ToString() + "]", "Configura CliSiTef");
				txtLog.Text += "Retorno Configura: [" + retorno.ToString() + "]" + Environment.NewLine;

				//trata o retorno
				if (retorno == 0)
				{
					passoFluxoVenda(1);
				}
				else
				{
					InicializaFluxoVenda();
				}

			}
		}

		private void btnAbre_Click(object sender, System.EventArgs e)
		{
			int retorno = clisitef.AbrirPinPad(ref txtLog);

			//System.Windows.Forms.MessageBox.Show("Retorno Abertura PinPad: [" + retorno.ToString() + "]", "Abre PinPad");            
			txtLog.Text += "Retorno Abertura PinPad: [" + retorno.ToString() + "]" + Environment.NewLine;

			//trata o retorno
			if (retorno == 0)
			{
				passoFluxoVenda(2);
			}
			else
			{
				InicializaFluxoVenda();
			}
		}

		private void btnFecha_Click(object sender, System.EventArgs e)
		{
			int retorno = clisitef.FecharPinPad();

			//System.Windows.Forms.MessageBox.Show("Retorno Fechamento PinPad: [" + retorno.ToString() + "]", "Fecha PinPad");
			txtLog.Text += "Retorno Fechamento PinPad: [" + retorno.ToString() + "]" + Environment.NewLine;

			//trata o retorno
			if (retorno == 0)
			{
				passoFluxoVenda(4);
			}
			else
			{
				InicializaFluxoVenda();
			}

		}

		private void btnLeCartao_Click(object sender, System.EventArgs e)
		{
			string trilha1;
			string trilha2;

			int retorno = clisitef.LeCartao(textBox1.Text, out trilha1, out trilha2);

			System.Windows.Forms.MessageBox.Show("Retorno LeCartao: [" + retorno.ToString() + "]", "LeCartao");

			if (retorno != -999)
			{
				//System.Windows.Forms.MessageBox.Show("Trilha1: [" + trilha1.ToString() + "]", "LeCartao");
				//System.Windows.Forms.MessageBox.Show("Trilha2: [" + trilha2.ToString() + "]", "LeCartao");

				txtLog.Text += "Trilha1: [" + trilha1.ToString() + "]" + Environment.NewLine;
				txtLog.Text += "Trilha2: [" + trilha2.ToString() + "]" + Environment.NewLine;
			}
		}

		private void btnVenda_Click(object sender, System.EventArgs e)
		{
			if (!clisitef.Configurado)
			{
				btnConfigura_Click(null, null);
			}

			btnVenda.Enabled = false;

			string valor = "100,00";
			string cupomFiscal = "12345";
			string dataFiscal = "20001231";
			string horario = "120000";
			string operador = "OPERADOR";
			string restricoes = "";

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // CONFIGURA A CLASSE CLISITEF PARA REALIAZR A VENDA
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			//Define o tipo de venda
			if (clisitef.tipoVenda <= 0)
			{
                //Debito
				clisitef.tipoVenda = 1;

                //Envia a data de PreDatado, mesmo que seja venda a vista
                clisitef.dataPreDatado = dtPickerPreDatado.Value.ToString("dMMyyyy");

			}

            if (clisitef.tipoVenda == 2)
            {
                if (txtCodigoSeguranca.Text == "")
                {
                    MessageBox.Show("Insira o Codigo de Seguranca !");
                    passoFluxoVenda(3);
                    btnVenda.Enabled = true;
                    return;
                }
                else
                {
                    // Envia o codigo de seguranca
                    clisitef.CodigoSeguranca = Convert.ToInt16(txtCodigoSeguranca.Text);
                }

                //Verifica o tipo de credito
                if (cboTipoCredito.SelectedIndex <= 0)
                {
                    clisitef.tipoFormaPagamento = 1;
                }
                else
                {
                    clisitef.tipoFormaPagamento = 2;

                }

                //Verifica o tipo do cartao
                if (cboTipoCartao.SelectedIndex <= 0)
                {
                    clisitef.tipoCartaoCredito = 1;
                }
                else
                {
                    clisitef.tipoCartaoCredito = 2;

                }

                //Quantidade de Parcelas
                clisitef.qtdeParcelas = trackBarParcelas.Value;

            }


			int retorno = clisitef.Venda(0, valor, cupomFiscal, dataFiscal, horario, operador, restricoes, ref txtLog);

			//System.Windows.Forms.MessageBox.Show("retorno: [" + retorno.ToString() + "]", "Venda CliSiTef");
			txtLog.Text += "retorno clisitef.Venda: [" + retorno.ToString() + "]" + Environment.NewLine;

			//trata o retorno
			if (retorno == 0)
			{
				passoFluxoVenda(3);
			}
			else
			{
				InicializaFluxoVenda();
			}

			btnVenda.Enabled = true;
		}

		private void rdTipoVendaDebito_CheckedChanged(object sender, EventArgs e)
		{

			if (rdTipoVendaDebito.Checked==true)
			{
				rdTipoVendaCredito.Checked = false;
                grbxOpcoesDebito.Enabled = true;
                grbxOpcoesCredito.Enabled = false;
				clisitef.tipoVenda = 1;                
			}
            else
            {
                grbxOpcoesDebito.Enabled = false;
                grbxOpcoesCredito.Enabled = true;
            }

		}

		private void rdTipoVendaCredito_CheckedChanged(object sender, EventArgs e)
		{
			
			if (rdTipoVendaCredito.Checked==true)
			{
				rdTipoVendaDebito.Checked = false;
				grbxOpcoesCredito.Enabled = true;
                grbxOpcoesDebito.Enabled = false;
				clisitef.tipoVenda = 2;
                cboTipoCredito.SelectedIndex = 0;
                cboTipoCartao.SelectedIndex = 0;
			}
			else
			{
				grbxOpcoesCredito.Enabled = false;
                grbxOpcoesDebito.Enabled = true;
			}
		}

		private void trackBarParcelas_Scroll(object sender, EventArgs e)
		{

			lblParcelas.Text = "Quantidade de Parcelas - " + trackBarParcelas.Value.ToString();


		}

        private void button1_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }

        private void rdTipoVendaDebitoVista_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTipoVendaDebitoVista.Checked == true)
            {
                rdTipoVendaDebitoPreDatado.Checked = false;
                clisitef.tipoFormaPagamento = 1;
            }
        }

        private void rdTipoVendaDebitoPreDatado_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTipoVendaDebitoPreDatado.Checked == true)
            {
                rdTipoVendaDebitoVista.Checked = false;
                clisitef.tipoFormaPagamento = 2;
            }
        }

        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTipoCartao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }







	}
}
