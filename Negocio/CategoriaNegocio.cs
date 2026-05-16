using ClasesArt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarCategoria()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
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

        public void AgregarCategoria(Categoria nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("insert into CATEGORIAS (Descripcion) values (@descripcion)");

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

        public void ModificarCategoria(Categoria nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("update CATEGORIAS set Descripcion = @descripcion where Id = @id");

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

        public void eliminarCategoria(int id)
        {
            try
            {
                AccesoADatos datos = new AccesoADatos();
                datos.setearConsulta("delete from CATEGORIAS where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool categoriaEnUso(int idMarca)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.setearConsulta("select count(*) From ARTICULOS where IdCategoria = @id");
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

