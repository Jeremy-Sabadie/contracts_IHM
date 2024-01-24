using domain.DTO.DTOrequests;

namespace AMIO_2
{
    public partial class Form1 : Form
    {
        private static readonly MaterielApi materielApi = new();
        MaterielApi _api = materielApi;
        ReadTokenValues _extractRole = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TLPformConnection_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void BTvalid_Click(object sender, EventArgs e)
        {
        }

        private async void BTvalid_Click_1(object sender, EventArgs e)
        {   //Création d'un DTOConnectRequest pour envoyer les valeurs
            DTOconnectionRequest UserConnectionValues = new()
            {
                name = textBox1.Text,
                password = TXTpassword.Text
            };
            //Apel de l'api pour la connection:
            string JWToken = await _api.UserConnectFromForm(UserConnectionValues);
            //Extraction du role du user:
            string userRole = _extractRole.GetRoleFromToken(JWToken);

            Form2 form2 = new Form2();
            form2._UseRole = userRole;
            form2.Show();
            this.Hide(); // Cache la Form1
            form2.FormClosed += (s, args) => this.Close(); // Ferme la Form1 lorsque Form2 se ferme.
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}