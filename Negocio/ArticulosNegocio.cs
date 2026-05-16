using ClasesArt;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> Listar()
        {   
            List<Articulos> lista = new List<Articulos>();

            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("Select a.Id, a.Codigo, a.Nombre, a.Descripcion , a.Precio, i.ImagenUrl, m.Descripcion as desmar, m.Id as idMar, c.Descripcion as descat, c.Id as idCat From ARTICULOS a  LEFT JOIN IMAGENES i on i.IdArticulo = a.Id LEFT JOIN MARCAS m on m.Id = a.IdMarca LEFT JOIN CATEGORIAS c on c.Id = a.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                { 
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    
                    aux.IdMarca = new Marca();
                    if (!(datos.Lector["idMar"] is DBNull))
                    {
                        aux.IdMarca.Id = (int)datos.Lector["idMar"];
                        aux.IdMarca.Descripcion = (string)datos.Lector["desmar"];
                    }
                    
                    aux.IdCategoria = new Categoria();
                    if (!(datos.Lector["idCat"] is DBNull))
                    {
                        aux.IdCategoria.Id = (int)datos.Lector["idCat"];
                        aux.IdCategoria.Descripcion = (string)datos.Lector["descat"];
                    }

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }

                    lista.Add(aux);
                }              

                datos.CerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public void Agregar(Articulos nuevo)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria)values (@Codigo, @Nombre, @Descripcion, @Precio, @IdCategoria, @IdMarca); SELECT SCOPE_IDENTITY()");

                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@IdCategoria", nuevo.IdCategoria.Id);
                datos.setearParametro("@IdMarca", nuevo.IdMarca.Id);

                int idValor = datos.EjecutarEcalar();

                datos.setearConsulta("insert into IMAGENES (IdArticulo, ImagenUrl)values(@IdArticulo, @ImagenUrl)");
                datos.setearParametro("@IdArticulo", idValor);
                datos.setearParametro("@ImagenUrl", nuevo.ImagenUrl);

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

        public void Modificar(Articulos nuevo)
        {
            AccesoADatos datos = new AccesoADatos();
            
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, IdMarca = @idMarca, IdCategoria = @idCategoria where Id = @id");

                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.setearParametro("@idMarca", nuevo.IdMarca.Id);
                datos.setearParametro("@idCategoria", nuevo.IdCategoria.Id);
                datos.setearParametro("@id", nuevo.Id);

                datos.ejecutarAccion();
                
                datos.setearConsulta("update IMAGENES set ImagenUrl = @imagenUrl where IdArticulo = @idArticulo; if @@rowcount = 0 insert into IMAGENES(IdArticulo, ImagenUrl) values(@idArticulo, @imagenUrl)");
                datos.setearParametro("@idArticulo", nuevo.Id);
                datos.setearParametro("@imagenUrl", nuevo.ImagenUrl);

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

        public void eliminar(int id)
        {
            try
            {
                AccesoADatos datos = new AccesoADatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}





