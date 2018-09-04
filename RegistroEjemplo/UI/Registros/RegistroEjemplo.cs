using RegistroEjemplo.BLL;
using RegistroEjemplo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEjemplo
{
    public partial class RegistroEjemplo : Form
    {
        public RegistroEjemplo()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            FechaNacimientodateTimePicker.Value = DateTime.Now;
           // SuperErrorProvider.Clear();
        }

        private void RegistroEjemplo_Load(object sender, EventArgs e)
        {
           
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Personas persona = PersonaBLL.Buscar((int)IDnumericUpDown.Value);
            return (persona != null);
        }

        private Personas Llenaclase()
        {
            Personas persona = new Personas();
            persona.PersonaID = Convert.ToInt32(IDnumericUpDown.Value);
            persona.Nombre = NombretextBox.Text;
            persona.Cedula = CedulamaskedTextBox.Text;
            persona.Telefono = TelefonomaskedTextBox.Text;
            persona.Direccion = DirecciontextBox.Text;
            persona.FechaNacimiento = FechaNacimientodateTimePicker.Value;
            return persona;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Personas persona;
            bool paso = false;

            /* if (!Validar())
             return;*/

            persona = Llenaclase();

            if(IDnumericUpDown.Value == 0)
              paso = PersonaBLL.Guardar(persona);
            else
            {
                if(!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }paso = PersonaBLL.Modificar(persona);

            }Limpiar();

            if(paso)
           
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                MessageBox.Show("No se puedo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void LlenaCampo(Personas persona)
        {
            int personaID = new Personas().PersonaID;
            IDnumericUpDown.Value = personaID;
            NombretextBox.Text = new Personas().Nombre;
            TelefonomaskedTextBox.Text = new Personas().Telefono;
            CedulamaskedTextBox.Text = new Personas().Telefono;
            DirecciontextBox.Text = new Personas().Direccion;
            FechaNacimientodateTimePicker.Value = new Personas().FechaNacimiento;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(IDnumericUpDown.Text, out id);

            persona = PersonaBLL.Buscar(id);

            if(persona != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            if (PersonaBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                ErrorProvider.Equals(IDnumericUpDown, "No se puede eliminar una persona que no existe");
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
