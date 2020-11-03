using System;
using System.Data;
using System.Data.SqlClient;

namespace PerfilEfectividad.Clases
{

    public class ClPerfilPuesto
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexionSql"]);
        DataSet ds = new DataSet();

        public int ExistePuesto(string Puesto)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_ExistePuesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Resul", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@Resul"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int ExisteArea(string Area)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Existe_Area", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Area", SqlDbType.VarChar, 500).Value = Area;
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@Resul"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_Puesto(string Puesto)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Puesto", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Puesto", SqlDbType.VarChar, 500).Value = Puesto;
                Comando.Parameters.Add("@Resul", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@Resul"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_Perfil(int PuestoId, string Fecha, int AreaId, string FuncPrincipal, string Principales, string FuncSemQuin, string FuncMenual, string FuncTriMen, string FuncAnual, 
            string FuncEventual, int TomaDesicionId, int EsfuerzoMentalId, int RelacionInternaId, int RelacionExternaId, int ManejoInformacionId, int UsuarioId, string PuestoSuperior, 
            string NombrePersona, string Superior, string FuncionesDiarias, int EducacionFormalId,
            int ImpcatoErrorId, string OtrosEstudios, int GradoId, int CarreraId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_Perfil", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@Fecha", SqlDbType.VarChar, 10).Value = Fecha;
                Comando.Parameters.Add("@AreaId", SqlDbType.Int).Value = AreaId;
                Comando.Parameters.Add("@FuncPrincipal", SqlDbType.Text).Value = FuncPrincipal;
                Comando.Parameters.Add("@Principales", SqlDbType.Text).Value = Principales;
                Comando.Parameters.Add("@FuncSemQuin", SqlDbType.Text).Value = FuncSemQuin;
                Comando.Parameters.Add("@FuncMensual", SqlDbType.Text).Value = FuncMenual;
                Comando.Parameters.Add("@FuncTriSem", SqlDbType.Text).Value = FuncTriMen;
                Comando.Parameters.Add("@FuncAnual", SqlDbType.Text).Value = FuncAnual;
                Comando.Parameters.Add("@FuncEventual", SqlDbType.Text).Value = FuncEventual;
                Comando.Parameters.Add("@TomaDesicionId", SqlDbType.Int).Value = TomaDesicionId;
                Comando.Parameters.Add("@EsfuerzoMentalId", SqlDbType.Int).Value = EsfuerzoMentalId;
                Comando.Parameters.Add("@RelacionInternaId", SqlDbType.Int).Value = RelacionInternaId;
                Comando.Parameters.Add("@RelacionExternaId", SqlDbType.Int).Value = RelacionExternaId;
                Comando.Parameters.Add("@ManejoInformacionId", SqlDbType.Int).Value = ManejoInformacionId;
                Comando.Parameters.Add("@UsuarioId", SqlDbType.Int).Value = UsuarioId;
                Comando.Parameters.Add("@PuestoSuperior", SqlDbType.VarChar, 500).Value = PuestoSuperior;
                Comando.Parameters.Add("@NombrePersona", SqlDbType.VarChar, 500).Value = NombrePersona;
                Comando.Parameters.Add("@Superior", SqlDbType.VarChar, 500).Value = Superior;
                Comando.Parameters.Add("@FuncDiarias", SqlDbType.Text).Value = FuncionesDiarias;
                if (EducacionFormalId == 0)
                    Comando.Parameters.Add("@EducacionFormalId", SqlDbType.Int).Value = DBNull.Value;
                else
                    Comando.Parameters.Add("@EducacionFormalId", SqlDbType.Int).Value = EducacionFormalId;
                if (ImpcatoErrorId == 0)
                    Comando.Parameters.Add("@ImpcatoErrorId", SqlDbType.Int).Value = DBNull.Value;
                else
                    Comando.Parameters.Add("@ImpcatoErrorId", SqlDbType.Int).Value = ImpcatoErrorId;
                Comando.Parameters.Add("@OtrosEstudios", SqlDbType.VarChar, 500).Value = OtrosEstudios;
                Comando.Parameters.Add("@PuestoVerId", SqlDbType.Int).Direction = ParameterDirection.Output;
                Comando.Parameters.Add("@GradoId", SqlDbType.Int).Value = GradoId;
                if (CarreraId == 0)
                    Comando.Parameters.Add("@CarreraId", SqlDbType.Int).Value = DBNull.Value;
                else
                    Comando.Parameters.Add("@CarreraId", SqlDbType.Int).Value = CarreraId;

                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@PuestoVerId"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleManejoBien(int PuestoId, int PuestoVer, int ConceptoId, string Monto, int Indirecta, int Directa, int Compartida)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleManejoBien", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@ConceptoId", SqlDbType.Int).Value = ConceptoId;
                Comando.Parameters.Add("@Monto", SqlDbType.VarChar, 900).Value = Monto;
                Comando.Parameters.Add("@Indirecta", SqlDbType.Int).Value = Indirecta;
                Comando.Parameters.Add("@Directa", SqlDbType.Int).Value = Directa;
                Comando.Parameters.Add("@Compartida", SqlDbType.Int).Value = Compartida;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleSupervisiones(int PuestoId, int PuestoVer, int TipoSupervisionId, string NombrePuesto, int Cantidad)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleSupervisiones", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@TipoSupervisionId", SqlDbType.Int).Value = TipoSupervisionId;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 900).Value = NombrePuesto;
                Comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = Cantidad;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleRelaciones(int PuestoId, int PuestoVer, string NombrePuesto, string Proposito, int FrecuenciaId, int TipoRelacionId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleRelaciones", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@NombrePuesto", SqlDbType.VarChar, 900).Value = NombrePuesto;
                Comando.Parameters.Add("@Proposito", SqlDbType.VarChar, 900).Value = Proposito;
                Comando.Parameters.Add("@FrecuenciaId", SqlDbType.Int).Value = FrecuenciaId;
                Comando.Parameters.Add("@TipoRelacionId", SqlDbType.Int).Value = TipoRelacionId;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleManejoInfo(int PuestoId, int PuestoVer, string Documento, string Accion, string TipoInformacion, int Jefe, int AuditoriaInt, int AuditoriaExt)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleManejoInfo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar, 900).Value = Documento;
                Comando.Parameters.Add("@Accion", SqlDbType.VarChar, 900).Value = Accion;
                Comando.Parameters.Add("@TipoInformacion", SqlDbType.VarChar, 900).Value = TipoInformacion;
                Comando.Parameters.Add("@Jefe", SqlDbType.Int).Value = Jefe;
                Comando.Parameters.Add("@AuditoriaInt", SqlDbType.Int).Value = AuditoriaInt;
                Comando.Parameters.Add("@AuditoriaExt", SqlDbType.Int).Value = AuditoriaExt;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleAmbienteTrabajo(int PuestoId, int PuestoVer, int TipoAmbienteTrabajoId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleAmbienteTrabajo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@TipoAmbienteTrabajoId", SqlDbType.Int).Value = TipoAmbienteTrabajoId;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleRiesgo(int PuestoId, int PuestoVer, int TipoRiesgoId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleRiesgo", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@TipoRiesgoId", SqlDbType.Int).Value = TipoRiesgoId;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleEsfuerzoFisico(int PuestoId, int PuestoVer, int TipoEsfuerfoFisicoId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleEsfuerzoFisico", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@EsfuerzoFisicoId", SqlDbType.Int).Value = TipoEsfuerfoFisicoId;

                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleOtrosCursos(int PuestoId, int PuestoVer, string Curso, 
            string Duracion)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleOtrosEstudios", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@Curso", SqlDbType.VarChar, 500).Value = Curso;
                Comando.Parameters.Add("@Duracion", SqlDbType.VarChar, 500).Value = Duracion;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleOtrosIdiomas(int PuestoId, int PuestoVer,
            int DominioIdiomaId, int IdiomaId)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleOtrosIdiomas", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                
                Comando.Parameters.Add("@DominioIdiomaId", SqlDbType.Int).Value = DominioIdiomaId;
                Comando.Parameters.Add("@IdomaId", SqlDbType.VarChar, 500).Value = IdiomaId;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Insert_DetalleExperiencia(int PuestoId, int PuestoVer, string TipoTrabajo,
            string Tiempo)
        {
            try
            {
                if (ds.Tables["DATOS"] != null)
                    ds.Tables.Remove("DATOS");
                cn.Open();
                SqlCommand Comando = new SqlCommand("Sp_Insert_DetalleExperiencia", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@PuestoId", SqlDbType.Int).Value = PuestoId;
                Comando.Parameters.Add("@PuestoVer", SqlDbType.Int).Value = PuestoVer;
                Comando.Parameters.Add("@TipoTrabajo", SqlDbType.VarChar, 900).Value = TipoTrabajo;
                Comando.Parameters.Add("@Tiempo", SqlDbType.VarChar, 900).Value = Tiempo;
                Comando.ExecuteNonQuery();
                cn.Close();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Get_Idioma(string Idioma)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("SP_GetIdiomaId", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Idioma", SqlDbType.VarChar, 500).Value = Idioma;
                Comando.Parameters.Add("@IdiomaId", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@IdiomaId"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int Get_Carrera(string Carrera, int GradoId)
        {
            try
            {
                cn.Open();
                SqlCommand Comando = new SqlCommand("SP_GetCarreraId", cn);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Carrera", SqlDbType.VarChar, 500).Value = Carrera;
                Comando.Parameters.Add("@GradoId", SqlDbType.Int).Value = GradoId;
                Comando.Parameters.Add("@CarreraId", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                SqlDataAdapter adp = new SqlDataAdapter(Comando);
                adp.Fill(ds, "DATOS");
                int Resultado = Convert.ToInt32(Comando.Parameters["@CarreraId"].Value.ToString());
                cn.Close();

                return Resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}