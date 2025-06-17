using System;
using System.Windows.Forms;

namespace Trabajo3POO
{
    public partial class PokemonForm : Form
    {
        public Pokemon Pokemon { get; private set; }

        public PokemonForm(Pokemon p = null)
        {
            InitializeComponent();

            if (p != null)
            {
                Pokemon = new Pokemon
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Altura = p.Altura,
                    Peso = p.Peso,
                    Experiencia = p.Experiencia,
                    TipoPrincipal = p.TipoPrincipal
                };

                txtNombre.Text = Pokemon.Nombre;
                txtAltura.Text = Pokemon.Altura.ToString();
                txtPeso.Text = Pokemon.Peso.ToString();
                txtExperiencia.Text = Pokemon.Experiencia.ToString();
                txtTipo.Text = Pokemon.TipoPrincipal;
            }
            else
            {
                Pokemon = new Pokemon();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtAltura.Text, out int altura) || altura <= 0)
            {
                MessageBox.Show("Altura debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!float.TryParse(txtPeso.Text, out float peso) || peso <= 0)
            {
                MessageBox.Show("Peso debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtExperiencia.Text, out int exp) || exp < 0)
            {
                MessageBox.Show("Experiencia debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                MessageBox.Show("El tipo principal es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Pokemon.Nombre = txtNombre.Text.Trim();
            Pokemon.Altura = altura;
            Pokemon.Peso = peso;
            Pokemon.Experiencia = exp;
            Pokemon.TipoPrincipal = txtTipo.Text.Trim();

            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
