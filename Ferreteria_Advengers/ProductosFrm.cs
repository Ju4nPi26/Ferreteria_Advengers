using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ferreteria_Advengers.Models;

namespace Ferreteria_Advengers
{
    public partial class ProductosFrm : Form
    {
        int id = 0;
        public ProductosFrm()
        {
            InitializeComponent();
        }

        private void ProductosFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Producto.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id_producto"].Visible = false;

            }

            cbCategorias.DataSource = Categoria.Obtener();
            cbCategorias.DisplayMember = "nombre";
            cbCategorias.ValueMember = "id_categoria";

            cbMarcas.DataSource = Marca.Obtener();
            cbMarcas.DisplayMember = "nombre";
            cbMarcas.ValueMember = "id_marca";
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = dataGridView1.CurrentRow.Cells["codigo_barras"].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            txtDescrip.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
            txtColor.Text = dataGridView1.CurrentRow.Cells["color"].Value.ToString();
            txtUnidad.Text = dataGridView1.CurrentRow.Cells["unidad_medida"].Value.ToString();
            txtStock_Actual.Text = dataGridView1.CurrentRow.Cells["stock_actual"].Value.ToString();
            txtStock_Mini.Text = dataGridView1.CurrentRow.Cells["stock_minimo"].Value.ToString();
            txtCosto.Text = dataGridView1.CurrentRow.Cells["costo_actual"].Value.ToString();
            txtPrecio_Mini.Text = dataGridView1.CurrentRow.Cells["precio_minorista"].Value.ToString();
            txtPrecio_Mayo.Text = dataGridView1.CurrentRow.Cells["precio_mayorista"].Value.ToString();
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_producto"].Value);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            bool resultado = Producto.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Producto eliminado correctamente.");
            }
            dataGridView1.DataSource = Producto.Obtener();
            limpiar();

        }
        private void limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescrip.Clear();
            txtColor.Clear();
            txtUnidad.Clear();
            txtStock_Actual.Clear();
            txtStock_Mini.Clear();
            txtCosto.Clear();
            txtPrecio_Mini.Clear();
            txtPrecio_Mayo.Clear();
            txtCodigo.Focus();
        }

        private void Guardarbtn_Click(object sender, EventArgs e)
        {
            int codigo_barras = Convert.ToInt32(txtCodigo.Text);
            string nombre = txtNombre.Text;
            string descripcion = txtDescrip.Text;
            string color = txtColor.Text;
            string unidad_medida = txtUnidad.Text;
            decimal stock_actual = Convert.ToDecimal(txtStock_Actual.Text);
            decimal stock_minimo = Convert.ToDecimal(txtStock_Mini.Text);
            decimal costo_actual = Convert.ToDecimal(txtCosto.Text);
            decimal precio_minorista = Convert.ToDecimal(txtPrecio_Mini.Text);
            decimal precio_mayorista = Convert.ToDecimal(txtPrecio_Mayo.Text);
            int id_categoria = Convert.ToInt32(cbCategorias.SelectedValue);
            int id_marca = Convert.ToInt32(cbMarcas.SelectedValue);
            bool resultado=false;
            if (id == 0)
            {
                resultado = Producto.Guardar(codigo_barras, nombre, descripcion, color, unidad_medida, stock_actual, stock_minimo,
                costo_actual, precio_minorista, precio_mayorista, id_categoria, id_marca);
                if (resultado)
                {
                    MessageBox.Show("Producto guardado correctamente.");
                }
                dataGridView1.DataSource = Producto.Obtener();
            }
            else
            {
                resultado = Producto.Editar(id, codigo_barras, nombre, descripcion, color, unidad_medida, stock_actual, stock_minimo,
                costo_actual, precio_minorista, precio_mayorista, id_categoria, id_marca);
                if (resultado)
                {
                    MessageBox.Show("Producto actualizado correctamente.");
                }
                dataGridView1.DataSource = Producto.Obtener();
            }
        }
    }
}
