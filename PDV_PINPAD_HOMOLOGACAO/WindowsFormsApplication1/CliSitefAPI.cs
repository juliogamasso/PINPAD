using System;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

namespace TesteMensagemPinPad
{
    public class CliSitefAPI
    {

        #region Private Properties

        private static int nVezes = 0;
        private static int _tamanhoRecebido = 0;
        private static bool _configurado = false;
        private static byte[] _recebido = new byte[20000];
        private int intSequenciaVenda = 0;

        #endregion

        #region Public Properties


        /// <summary>
        /// Valores permitidos - 0- TipoCartao, 1 -Debito, 2 - Credito, 3 - Refeicao
        /// </summary>
        public int tipoVenda { get; set; }

        /// <summary>
        /// Valores permitidos - 1- A Vista, 2 - Pre Datado/Parcelado
        /// </summary>
        public int tipoFormaPagamento { get; set; }

        /// <summary>
        /// Valores Permitidos - 1 - Magnetico/Chip, 2 - Digitado
        /// </summary>
        public int tipoCartaoCredito { get; set; }

        /// <summary>
        /// Quantidade de Parcelas
        /// </summary>
        public int qtdeParcelas { get; set; }

        /// <summary>
        /// Valores Permitidos - DDMMAAAA
        /// </summary>
        public string dataPreDatado { get; set; }

        /// <summary>
        /// Codigo de Seguranca do Cartao de Credito
        /// </summary>
        public int CodigoSeguranca { get; set; }

        /// <summary>
        /// Retorna se foi configurado
        /// </summary>
        public bool Configurado
        {
            get {return _configurado;}
        }

        public int TamanhoRecebido
        {
            get {return _tamanhoRecebido;}
        }

        public byte[] Recebido
        {
            get {return _recebido;}
        }



        #endregion

        #region Configura [REALIZA CONFIGURACAO DO PINPAD - IMPORTANTE SE NAO CONFIGURAR NAO RODA ]

        /// <summary>
        /// Configura o PINPAD
        /// </summary>
        /// <param name="endereco">Endereco da Loja</param>
        /// <param name="loja">Nome da Loja</param>
        /// <param name="terminal">Numeracao do terminal</param>
        /// <returns>0 - sucesso</returns>
        public int Configura(string endereco, string loja, string terminal)
        {	
            byte[] _endereco	= Encoding.ASCII.GetBytes(endereco + "\0");
            byte[] _loja		= Encoding.ASCII.GetBytes(loja + "\0");
            byte[] _terminal	= Encoding.ASCII.GetBytes(terminal + "\0");

            try
            {
                int result = CliSitefAPI.ConfiguraIntSiTefInterativo(_endereco, _loja, _terminal, 0);				

                _configurado = (result == 0);

                return result;
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Erro");
            }

            return -999;			
        }

        #endregion

        #region Rotina Resultado [INFORMACOES DIVERSAS - CUPOM / COMPROVANTE]
        private int RotinaResultado(int tipoCampo, byte[] buffer, ref TextBox mTextBox)
        {
            string mensagem = Encoding.UTF8.GetString(buffer);

            mensagem = mensagem.Substring(0, mensagem.IndexOf('\x0'));

            switch (tipoCampo)
            {
                case 1:
                    System.Windows.Forms.MessageBox.Show("Finalizacao: [" + mensagem.ToString() + "]", "RotinaResultado");
                    mTextBox.Text += "Finalizacao: [" + mensagem.ToString() + "]" + Environment.NewLine;
                    break;

                case 121:
                    System.Windows.Forms.MessageBox.Show("Comprovante Cliente: \n" + mensagem.ToString(), "RotinaResultado");
                    mTextBox.Text += "Comprovante Cliente: \n" + mensagem.ToString() + Environment.NewLine;
                    break;

                case 122:
                    System.Windows.Forms.MessageBox.Show("Comprovante Estabelecimento: \n" + mensagem.ToString(), "RotinaResultado");
                    mTextBox.Text += "Comprovante Estabelecimento: \n" + mensagem.ToString() + Environment.NewLine;
                    break;

                case 131:
                    System.Windows.Forms.MessageBox.Show("Rede Destino: [" + mensagem.ToString() + "]", "RotinaResultado");
                    mTextBox.Text += "Rede Destino: [" + mensagem.ToString() + "]" + Environment.NewLine;
                    break;

                case 132:
                    System.Windows.Forms.MessageBox.Show("Tipo Cartao: [" + mensagem.ToString() + "]", "RotinaResultado");
                    mTextBox.Text += "Tipo Cartao: [" + mensagem.ToString() + "]" + Environment.NewLine;
                    break;

                default:
                    System.Windows.Forms.MessageBox.Show("nTipoCampo: [" + tipoCampo.ToString() + "]\nConteudo: [" + mensagem.ToString() + "]", "RotinaResultado");
                    mTextBox.Text += "nTipoCampo: [" + tipoCampo.ToString() + "]\nConteudo: [" + mensagem.ToString() + "]" + Environment.NewLine;
                    break;
            }

            return 0;
        }

        #endregion

        #region TrataMenu [ENVIA VALORES DE MENU, COMO TIPO DO CARTAO, FORMA DE PAGAMENTO]
        private int TrataMenu(byte[] pOpcoes, ref byte[] pEscolha, ref TextBox mTextBox)
        {
            //Analisa a solicitacao para poder retornar a resposta correta
            string sOpcoes = Encoding.UTF8.GetString(pOpcoes);
            string sEscolha = Encoding.UTF8.GetString(pEscolha);
            sOpcoes = sOpcoes.Substring(0, sOpcoes.IndexOf('\x0'));
            sEscolha = sEscolha.Substring(0, sEscolha.IndexOf('\x0'));

            ////////////////////////////////////////////////////////
            //Verifica qual a sequencia de venda
            ////////////////////////////////////////////////////////
            // 1 - Indica a forma de pagamento (Debito/Credito)
            // 2 - Indica o tipo do Cartao
            // 3 - Indica qual forma de pagamento (a vista, parcelado, pre-datado...)
            // 4 - Indica o tipo do cartao de credito (1:Magnetico/Chip;2:Digitado;)

            mTextBox.Text += "Trata Menu: [" + sEscolha.ToString() + "]" + " Opcoes: [" + sOpcoes.ToString() + "]" + " TipoVenda: [" + tipoVenda.ToString() + "]" + Environment.NewLine;

            // 1 - Indica a forma de pagamento (Debito/Credito)
            if (intSequenciaVenda == 1)
            {
                //Credito
                if (tipoVenda == 2)
                {
                    if (sEscolha.IndexOf("Credito") > 0)
                    {
                        string retorno = tipoVenda + String.Join("\0", new string[2001 - tipoVenda.ToString().Length]);
                        pEscolha = Encoding.ASCII.GetBytes(retorno);
                        return tipoVenda;
                    }
                    else
                    {
                        return 0;
                    }
                }
                    //Debito
                else if (tipoVenda == 1)
                {
                    string retorno = tipoVenda + String.Join("\0", new string[2001 - tipoVenda.ToString().Length]);
                    pEscolha = Encoding.ASCII.GetBytes(retorno);
                    return tipoVenda;

                }
                else
                {
                    return 0;
                }

            }

            // 2 - Indica o tipo do Cartao
            if (intSequenciaVenda == 2)
            {
                if (tipoVenda == 2)
                {
                    // Ira retornar 1, pois 'e credito
                    string retorno = 1 + String.Join("\0", new string[1999]);
                    pEscolha = Encoding.ASCII.GetBytes(retorno);
                    return tipoVenda;
                }
                else
                {
                    // Ira retornar 1, pois 'e debito
                    string retorno = tipoVenda + String.Join("\0", new string[2001 - tipoVenda.ToString().Length]);
                    pEscolha = Encoding.ASCII.GetBytes(retorno);
                    return tipoVenda;
                }

            }

            // 3 - Indica qual forma de pagamento (a vista, parcelado, pre-datado...)
            if (intSequenciaVenda == 3)
            {
                if (tipoVenda == 2)
                {
                    //"1:A Vista;2:Financ. Loja;3:Financ. Adm.;" -->>> ENVIANDO 2 PARA PARCELADO
                    string retorno = tipoFormaPagamento + String.Join("\0", new string[2001 - tipoFormaPagamento.ToString().Length]);
                    pEscolha = Encoding.ASCII.GetBytes(retorno);
                    return tipoVenda;
                }
                else
                {
                    //"1:A Vista;2:Pre-Datado;3:Consulta parcelas CDC;4:CDC;"
                    string retorno = tipoFormaPagamento + String.Join("\0", new string[2001 - tipoFormaPagamento.ToString().Length]);
                    pEscolha = Encoding.ASCII.GetBytes(retorno);
                    return tipoVenda;
                }
            }

            // 4 - Indica o tipo do cartao de credito (1:Magnetico/Chip;2:Digitado;)
            if (intSequenciaVenda == 4)
            {
                if (tipoVenda == 2)
                {
                    //1:Magnetico/Chip;2:Digitado;
                    string retorno = tipoCartaoCredito + String.Join("\0", new string[2001 - tipoCartaoCredito.ToString().Length]);
                    pEscolha = Encoding.ASCII.GetBytes(retorno);
                    return tipoVenda;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

            
        }

        #endregion

        #region TrataSequenciVenda [TRATA A SEQUENCIA DE VENDA PARA O ENVIO CORRETO DAS INFORMACOES PARA O PINPAD]

        public void TrataSequenciaVenda(string mensagem)
        {

            if (mensagem.ToUpper() == "SELECIONE A FORMA DE PAGAMENTO")
            {
                if (intSequenciaVenda == 0)
                {
                    //Inicio
                    //Seleciona se e Debito ou Credito
                    intSequenciaVenda = 1;
                }
                else
                {
                    //Qual forma de pagamento ? Avista ? Parcelado ? Pre Datado ?
                    intSequenciaVenda = 3;
                }


            }

            if (mensagem.ToUpper() == "SELECIONE O TIPO DO CARTAO DE DEBITO")
            {
                //Seleciona o tipo do cartao de debito
                intSequenciaVenda = 2;

            }

            if (mensagem.ToUpper() == "SELECIONE O TIPO DO CARTAO DE CREDITO")
            {
                if (intSequenciaVenda == 2)
                {
                    //Seleciona o tipo do cartao de credito 2
                    intSequenciaVenda = 4;
                }
                else
                {
                    //Seleciona o tipo do cartao de credito
                    intSequenciaVenda = 2;
                }

            }
            

        }

        #endregion

        #region RotinaColeta [ENVIA VALORES COMO DATA, CODIGO, ETC.]
        private int RotinaColeta(int comando, int tipoCampo, ref short pTamanhoMinimo, ref short pTamanhoMaximo, byte[] pDadosComando, ref byte[] pCampo, ref TextBox mTextBox)
        {
            char c;
            string mensagem = Encoding.UTF8.GetString(pDadosComando);
            
            mensagem = mensagem.Substring(0, mensagem.IndexOf('\x0'));
           
            if (comando != 23)
            {
                nVezes = 0;
            }

            switch (comando)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    System.Windows.Forms.MessageBox.Show("Mensagem Visor: [" + mensagem.ToString() + "]", "RotinaColeta");
                    mTextBox.Text += "Mensagem Visor: [" + mensagem.ToString() + "]" + Environment.NewLine;

                    TrataSequenciaVenda(mensagem.ToString());

                    return 0;

                case 11:
                case 12:
                case 13:
                case 14:
                    System.Windows.Forms.MessageBox.Show("Apaga Visor: [" + comando.ToString() + "]", "RotinaColeta");
                    mTextBox.Text += "Apaga Visor: [" + comando.ToString() + "]" + Environment.NewLine;
                    return 0;

                case 37:
                    System.Windows.Forms.MessageBox.Show("Coleta confirmacao no PinPad: [" + mensagem.ToString() + "]", "RotinaColeta", System.Windows.Forms.MessageBoxButtons.YesNo);
                    mTextBox.Text += "Coleta confirmacao no PinPad: [" + mensagem.ToString() + "]" + Environment.NewLine;
                    return 0;
                
                case 20:
                    System.Windows.Forms.MessageBox.Show("Coleta Sim/Nao: [" + mensagem.ToString() + "]", "RotinaColeta", System.Windows.Forms.MessageBoxButtons.YesNo);
                    mTextBox.Text += "Coleta Sim/Nao: [" + mensagem.ToString() + "]" + Environment.NewLine;
                    return 0;

                case 21:
                    System.Windows.Forms.MessageBox.Show("Menu: [" + mensagem.ToString() + "]", "RotinaColeta");
                    mTextBox.Text += "Menu: [" + mensagem.ToString() + "]" + Environment.NewLine;
                    return this.TrataMenu(pDadosComando, ref pCampo, ref mTextBox);

                case 22:
                    System.Windows.Forms.MessageBox.Show("Obtem qualquer tecla: [" + mensagem.ToString() + "]", "RotinaColeta");
                    mTextBox.Text += "Obtem qualquer tecla: [" + mensagem.ToString() + "]" + Environment.NewLine;
                    return 0;

                case 23:
                    System.Threading.Thread.Sleep(1000);

                    if (nVezes++ > 30)
                    {
                        return -1;
                    }

                    return 0;

                case 30:
                    if (tipoCampo == 514)
                    {
                        System.Windows.Forms.MessageBox.Show("Codigo de Seguranca: [" + CodigoSeguranca + "]", "RotinaColeta");
                        mTextBox.Text += "Codigo de Seguranca: [" + CodigoSeguranca + "]" + Environment.NewLine;
                        pDadosComando = Encoding.ASCII.GetBytes(CodigoSeguranca + "\0");
                        return CodigoSeguranca;
                    }

                    if (tipoCampo == 506)
                    {
                        //Forneca a data do Pre-datado. Enter assume 12/04/2018 (DDMMAAAA)"
                        System.Windows.Forms.MessageBox.Show("Data do Pre-Datado: [" + comando.ToString() + "]", "RotinaColeta");
                        mTextBox.Text += "Data do Pre-Datado: [" + comando.ToString() + "]" + Environment.NewLine;
                        mTextBox.Text += "Data do Pre-Datado: [" + mensagem.ToString() + "]" + Environment.NewLine;
                        string retorno = dataPreDatado + String.Join("\0", new string[2001 - dataPreDatado.ToString().Length]);
                        pDadosComando = Encoding.ASCII.GetBytes(retorno);
                        pCampo = Encoding.ASCII.GetBytes(retorno);
                        return 0;
                    }

                    if (tipoCampo == 505)
                    {
                        //Forneca o numero de parcelas
                        System.Windows.Forms.MessageBox.Show("Forneca o numero de parcelas: [" + comando.ToString() + "]", "RotinaColeta");
                        mTextBox.Text += "Forneca o numero de parcelas: [" + comando.ToString() + "]" + Environment.NewLine;
                        mTextBox.Text += "Forneca o numero de parcelas: [" + mensagem.ToString() + "]" + Environment.NewLine;
                        string retorno = qtdeParcelas + String.Join("\0", new string[2001 - qtdeParcelas.ToString().Length]);
                        pDadosComando = Encoding.ASCII.GetBytes(retorno);
                        pCampo = Encoding.ASCII.GetBytes(retorno);
                        return 0;
                    }

                    break;

                case 31:
                case 32:
                case 33:
                case 34:
                case 35:
                case 38:
                    System.Windows.Forms.MessageBox.Show("nComando: [" + comando.ToString() + "]\nTipoCampo: [" + tipoCampo.ToString() + "]", "RotinaColeta");
                    mTextBox.Text += "nComando: [" + comando.ToString() + "]\nTipoCampo: [" + tipoCampo.ToString() + "]" + Environment.NewLine;
                    return LeCampo(pTamanhoMinimo, pTamanhoMaximo, pDadosComando, pCampo);

                default:
                    System.Windows.Forms.MessageBox.Show("Default: MENSAGEM[" + mensagem.ToString() + "] COMANDO[" + comando.ToString() + "]", "RotinaColeta", System.Windows.Forms.MessageBoxButtons.YesNo);
                    mTextBox.Text += "Default(RotinaColeta): MENSAGEM[" + mensagem.ToString() + "] COMANDO[" + comando.ToString() + "]" + Environment.NewLine;
                    return 0;
            }

            return -1;
        }

        #endregion

        #region Venda [ROTINA DE VENDA]

        public int Venda(int funcao, string valor, string cupomFiscal, string dataFiscal, string horario, string operador, string restricoes, ref TextBox mTextBox)
        {
            int comando = 0;
            int continua = 0;
            int tipoCampo = 0;
            short tamanhoMinimo = 0;
            short tamanhoMaximo = 0;

            byte[] _valor = Encoding.ASCII.GetBytes(valor + "\0");
            byte[] _cupomFiscal = Encoding.ASCII.GetBytes(cupomFiscal + "\0");
            byte[] _dataFiscal = Encoding.ASCII.GetBytes(dataFiscal + "\0");
            byte[] _horario = Encoding.ASCII.GetBytes(horario + "\0");
            byte[] _operador = Encoding.ASCII.GetBytes(operador + "\0");
            byte[] _restricoes = Encoding.ASCII.GetBytes(restricoes + "\0");

            byte[] buffer = new byte[20000];

            //Inicializa a sequencia de venda
            intSequenciaVenda = 0;

            int retorno = CliSitefAPI.IniciaFuncaoSiTefInterativo(funcao, _valor, _cupomFiscal, _dataFiscal, _horario, _operador, _restricoes);
            
            while (retorno == 10000)
            {
                retorno = CliSitefAPI.ContinuaFuncaoSiTefInterativo(ref comando, ref tipoCampo, ref tamanhoMinimo, ref tamanhoMaximo, buffer, buffer.Length, 0);

                if (comando == 0)
                {
                    continua = this.RotinaResultado(tipoCampo, buffer, ref mTextBox);
                }
                else
                {
                    continua = this.RotinaColeta(comando, tipoCampo, ref tamanhoMinimo, ref tamanhoMaximo, buffer, ref buffer, ref mTextBox);
                }
            }

            return retorno;
        }

        #endregion

        #region Le Confirmacao PinPad
        public int LeConfirmacaoPinPad(string mensagem)
        {	
            try
            {
                byte[] _pcampo = new byte[2000];
                byte[] _mensagem	= Encoding.ASCII.GetBytes(mensagem + "\0");

                int retorno = CliSitefAPI.LeSimNaoPinPad(_mensagem);

                return retorno;
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Erro");
            }

            return -999;
        }

        #endregion

        # region Abetura PINPAD
        public int AbrirPinPad(ref TextBox mTextBox)
        {
            try
            {
                int retorno = CliSitefAPI.AbrePinPad();
                
                mTextBox.Text += "Retorno Abertura PinPad: [" + retorno.ToString() + "]" + Environment.NewLine;

                return retorno;
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Erro");
            }

            return -999;
        }

        #endregion

        #region Fechamento PINPAD
        public int FecharPinPad()
        {
            try
            {
                int retorno = CliSitefAPI.FechaPinPad();

                return retorno;
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Erro");
            }

            return -999;
        }

        #endregion

        #region Leitura Cartao PINPAD

        public int LeCartao(string mensagem, out string trilha1, out string trilha2)
        {		
            try
            {				
                byte[] _mensagem = Encoding.ASCII.GetBytes(mensagem + "\0");
                byte[] _trilha1 = new byte[2000];
                byte[] _trilha2 = new byte[2000];

                CliSitefAPI.LeCartaoDireto(_mensagem, _trilha1, _trilha2);

                trilha1 = System.Text.Encoding.UTF8.GetString(_trilha1);
                trilha1 = trilha1.Substring(0, trilha1.IndexOf('\x0'));

                trilha2 = System.Text.Encoding.UTF8.GetString(_trilha2);
                trilha2 = trilha2.Substring(0, trilha2.IndexOf('\x0'));

                return 0;
            }
            catch(System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Erro");
            }

            trilha1 = null;
            trilha2 = null;

            return -999;
        }

        #endregion

        private int LeCampo(short tamanhoMinimo, short tamanhoMaximo, byte[] pMensagem, byte[] pCampo)
        {
            return 0;
        }


        #region CLISITEF32I imports

        [DllImport("CliSiTef64I.dll", EntryPoint="ConfiguraIntSiTefInterativo", CharSet=CharSet.Auto, SetLastError = true)]
        static extern int ConfiguraIntSiTefInterativo(byte[] pEnderecoIP, byte[] pCodigoLoja, byte[] pNumeroTerminal, short ConfiguraResultado);

        [DllImport("CliSiTef64I.dll", EntryPoint = "IniciaFuncaoSiTefInterativo", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int IniciaFuncaoSiTefInterativo(int Funcao, byte[] pValor, byte[] pCupomFiscal, byte[] pDataFiscal, byte[] pHorario, byte[] pOperador, byte[] pRestricoes);

        [DllImport("CliSiTef64I.dll", EntryPoint = "ContinuaFuncaoSiTefInterativo", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int ContinuaFuncaoSiTefInterativo(ref int pComando, ref int pTipoCampo, ref short pTamMinimo, ref short pTamMaximo, byte[] pBuffer, int TamBuffer, int Continua);

        [DllImport("CliSiTef64I.dll", EntryPoint = "EnviaRecebeSiTefDireto", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int EnviaRecebeSiTefDireto(short RedeDestino, short FuncaoSiTef, short OffsetCartao, byte[] pDadosTx, short TamDadosTx, byte[] pDadosRx, short TamMaxDadosRx, short[] pCodigoResposta, short TempoEsperaRx, byte []pNumeroCupon, byte[] pDataFiscal, byte[] pHorario, byte[] pOperador, short TipoTransacao);

        [DllImport("CliSiTef64I.dll", EntryPoint = "LeSimNaoPinPad", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int LeSimNaoPinPad(byte[] pMsgDisplay);

        [DllImport("CliSiTef64I.dll", EntryPoint = "AbrePinPad", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int AbrePinPad();

        [DllImport("CliSiTef64I.dll", EntryPoint = "FechaPinPad", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int FechaPinPad();

        [DllImport("CliSiTef64I.dll", EntryPoint = "LeCartaoDireto", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int LeCartaoDireto(byte[] pMsgDisplay, byte[] trilha1, byte[] trilha2);

        #endregion
    }

   

}
