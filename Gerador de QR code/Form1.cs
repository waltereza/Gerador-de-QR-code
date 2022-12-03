namespace Gerador_de_QR_code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGerarQR_Click(object sender, EventArgs e)
        {
            if (txtLink.Text == string.Empty)
            {
                MessageBox.Show("Insira um link");
                txtLink.Focus();
                return;
            }
            try
            {
                int largura = Convert.ToInt32(300);
                int altura = Convert.ToInt32(300);
                picQRCode.Image = GerarQRCode(largura, altura, txtLink.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Bitmap GerarQRCode(int width, int height, string text)
        {
            try
            {
                var bw = new ZXing.Windows.Compatibility.BarcodeWriter();
                var encOpt = new ZXing.Common.EncodingOptions() {
                    Margin = 1,
                    Width = width, 
                    Height = height
                };
                bw.Options = encOpt;
                bw.Format = ZXing.BarcodeFormat.QR_CODE;
                var resultado = new Bitmap(bw.Write(text));
                return resultado;
            }
            catch
            {
                throw;
            }
        }
    }
}