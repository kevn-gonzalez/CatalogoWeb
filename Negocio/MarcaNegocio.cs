using ClasesArt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listarmarcas()
        {
            List<Marca> lista = new List<Marca>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void AgregarMarca(Marca nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("insert into MARCAS (Descripcion) values (@descripcion)");

                datos.setearParametro("@descripcion", nuevo.Descripcion);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public void ModificarMarca(Marca nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("update MARCAS set Descripcion = @descripcion where Id = @id");

                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@id", nuevo.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void eliminarMarca (int id)
        {
            try
            {
                AccesoADatos datos = new AccesoADatos();
                datos.setearConsulta("delete from MARCAS where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool marcaEnUso(int idMarca)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.setearConsulta("select count(*) From ARTICULOS where IdMarca = @id");
                datos.setearParametro("@id", idMarca);
                int cantidad = datos.EjecutarEcalar();

                if (cantidad > 0)
                {
                    return true;
                }
                else
                {
                    return false; 
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }

}
