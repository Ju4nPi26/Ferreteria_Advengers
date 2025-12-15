using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria_Advengers.Models
{
    internal class Compras
    {
        public static DataTable Obtener()
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "select c.*,p.razon_social from compras c inner join proveedores p on c.id_proveedor = p.id_proveedor order by id_compra desc";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                return null;
            }
            finally
            {
                ccn.Desconectar();
            }

        }
        public static bool Guardar(string numero_factura, string fecha_compra, string total,  string estado, int id_proveedor)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "INSERT INTO compras (numero_factura, fecha_compra, total, estado,id_proveedor) VALUES (@numero_factura, @fecha_compra, @total, @estado, @id_proveedor)";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@numero_factura", numero_factura);
                comando.Parameters.AddWithValue("@fecha_compra", fecha_compra);
                comando.Parameters.AddWithValue("@total", total);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@id_proveedor",id_proveedor);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                return false;
            }
            finally
            {
                ccn.Desconectar();
            }
        }
        public static bool Editar(int id, string numero_factura, string fecha_compra, string total, string estado, int id_proveedor)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "UPDATE compras SET numero_factura=@numero_factura, fecha_compra=@fecha_compra, total=@total, estado=@estado, id_proveedor=@id_proveedor WHERE id_compra = @id";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@numero_factura", numero_factura);
                comando.Parameters.AddWithValue("@fecha_compra", fecha_compra);
                comando.Parameters.AddWithValue("@total", total);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                return false;
            }
            finally
            {
                ccn.Desconectar();
            }
        }
        public static bool Eliminar(int id)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "DELETE FROM compras WHERE id_compra = @id";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                return false;
            }
            finally
            {
                ccn.Desconectar();
            }
        }
    }
}
