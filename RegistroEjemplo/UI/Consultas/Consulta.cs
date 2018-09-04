using RegistroEjemplo.Entidades;
using RegistroEjemplo.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEjemplo.UI.Consultas
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {

        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            var Listado = new List<Personas>();
            PersonaBLL persona = new PersonaBLL();

            if(CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        Listado= PersonaBLL.GetList(p => true);
                        break;
                    case 1:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        Listado = PersonaBLL.GetList(p => p.PersonaID == id);
                        break;
                    case 2:
                        Listado = PersonaBLL.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                        break;
                    case 3:
                        Listado = PersonaBLL.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                        break;
                    case 4:
                        Listado = PersonaBLL.GetList(p => p.Telefono.Contains(CriteriotextBox.Text));
                        break;
                    case 5:
                        Listado = PersonaBLL.GetList(p => p.Direccion.Contains(CriteriotextBox.Text));
                        break;
                }
                Listado = Listado.Where(c => c.FechaNacimiento.Date >= DesdedateTimePicker.Value.Date && c.FechaNacimiento <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                Listado = PersonaBLL.GetList(p=> true);
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = Listado;
        }
    }
}
