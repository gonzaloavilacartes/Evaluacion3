using System;
using System.Windows.Forms;

namespace Trabajo3POO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos(string filtro = "")
        {
            var lista = PokemonDAL.ObtenerPokemones(filtro);
            dataGridViewPokemones.DataSource = lista;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDatos(txtFiltro.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new PokemonForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                PokemonDAL.InsertarPokemon(form.Pokemon);
                CargarDatos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPokemones.CurrentRow?.DataBoundItem is Pokemon poke)
            {
                var form = new PokemonForm(poke);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    PokemonDAL.ActualizarPokemon(form.Pokemon);
                    CargarDatos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPokemones.CurrentRow?.DataBoundItem is Pokemon poke)
            {
                if (MessageBox.Show($"¿Eliminar a {poke.Nombre}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    PokemonDAL.EliminarPokemon(poke.Id);
                    CargarDatos();
                }
            }
        }
    }
}
