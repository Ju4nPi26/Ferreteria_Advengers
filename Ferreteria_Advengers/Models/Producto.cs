using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Ferreteria_Advengers;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ferreteria_Advengers.Models;

namespace Ferreteria_Advengers.Models
{
    internal class Producto
    {
        public static DataTable Obtener()
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "select p.*,c.id_categoria,m.nombre from productos p inner join categoria c on p.id_categoria = c.id_categoria inner join marca m on p.id_marca = m.id_marca order by id_producto desc;";
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
        public static bool Guardar(int codigo_barras, string nombre, string descripcion, string color, string unidad_medida, decimal stock_actual, decimal stock_minimo,
            decimal costo_actual, decimal precio_minorista, decimal precio_mayorista, int id_categoria, int id_marca)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "INSERT INTO productos (codigo_barras, nombre, descripcion, color, unidad_medida, stock_actual, stock_minimo, costo_actual, precio_minorista, precio_mayorista, id_categoria, id_marca) VALUES" +
                " (@codigo_barras, @nombre, @descripcion, @color, @unidad_medida, @stock_actual, @stock_minimo, @costo_actual, @precio_minorista, @precio_mayorista, @id_categoria, @id_marca)";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@codigo_barras", codigo_barras);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@color", color);
                comando.Parameters.AddWithValue("@unidad_medida", unidad_medida);
                comando.Parameters.AddWithValue("@stock_actual", stock_actual);
                comando.Parameters.AddWithValue("@stock_minimo", stock_minimo);
                comando.Parameters.AddWithValue("@costo_actual", costo_actual);
                comando.Parameters.AddWithValue("@precio_minorista", precio_minorista);
                comando.Parameters.AddWithValue("@precio_mayorista", precio_mayorista);
                comando.Parameters.AddWithValue("@id_categoria", id_categoria);
                comando.Parameters.AddWithValue("@id_marca", id_marca);
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
        public static bool Editar(int id, int codigo_barras, string nombre, string descripcion, string color, string unidad_medida, decimal stock_actual, decimal stock_minimo,
            decimal costo_actual, decimal precio_minorista, decimal precio_mayorista, int id_categoria, int id_marca)
        {
            Conexion ccn = new Conexion();
            try
            {
                ccn.Conectar();
                string consulta = "UPDATE productos SET codigo_barras=@codigo_barras, nombre=@nombre, descripcion=@descripcion, color=@color, unidad_medida=@unidad_medida,stock_actual=@stock_actual, stock_minimo=@stock_minimo, costo_actual=@costo_actual, precio_minorista=@precio_minorista, precio_mayorista=@precio_mayorista, id_categoria=@id_categoria, id_marca=@id_marca WHERE id_producto=@id";
                SqlCommand comando = new SqlCommand(consulta, ccn.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@codigo_barras", codigo_barras);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@color", color);
                comando.Parameters.AddWithValue("@unidad_medida", unidad_medida);
                comando.Parameters.AddWithValue("@stock_actual", stock_actual);
                comando.Parameters.AddWithValue("@stock_minimo", stock_minimo);
                comando.Parameters.AddWithValue("@costo_actual", costo_actual);
                comando.Parameters.AddWithValue("@precio_minorista", precio_minorista);
                comando.Parameters.AddWithValue("@precio_mayorista", precio_mayorista);
                comando.Parameters.AddWithValue("@id_categoria", id_categoria);
                comando.Parameters.AddWithValue("@id_marca", id_marca);
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
                string consulta = "DELETE FROM productos WHERE id=@id";
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
