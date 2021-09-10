using MinCultura.Reports.Web.DataBase;
using MinCultura.Reports.Web.Reportes;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;

namespace MinCultura.Reports.Web.Pages
{
    public partial class SaveParteB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request["Id"]) 
                && !string.IsNullOrWhiteSpace(Request["Rad"])
                && !string.IsNullOrWhiteSpace(Request["IdE"]))
            {
                XtraReportParteB parteB = new XtraReportParteB();
                decimal Id = Convert.ToDecimal(Request["Id"]);
                string radicado = Request["Rad"];
                int idEnvioCorre = Convert.ToInt32(Request["IdE"]);

                DataSource.PAS_REPORTE_REGISTRO_PROYECTO_CONCERTACIONDataTable data =
                    parteB.pAS_REPORTE_REGISTRO_PROYECTO_CONCERTACIONTableAdapter.GetData(Id);
                if (data.Count > 0)
                {
                    DataSource.PAS_REPORTE_PARTE_BDataTable dataParteB =
                        parteB.pAS_REPORTE_PARTE_BTableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_TEMASDataTable dataParteBTemas =
                        parteB.pAS_REPORTE_PARTE_B_TEMASTableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_TRAYECTORIADataTable dataParteBTrayectoria =
                        parteB.pAS_REPORTE_PARTE_B_TRAYECTORIATableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_CRONODataTable dataParteBCrono =
                        parteB.pAS_REPORTE_PARTE_B_CRONOTableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_PRESUPUESTODataTable dataParteBPresupuesto =
                        parteB.pAS_REPORTE_PARTE_B_PRESUPUESTOTableAdapter.GetData(Id);
                    DataSource.PAS_REPORTE_PARTE_B_IMPACTOSDataTable dataParteBImpactos =
                        parteB.pAS_REPORTE_PARTE_B_IMPACTOSTableAdapter.GetData(Id);

                    //Información de la parte A
                    parteB.pAS_REPORTE_REGISTRO_PROYECTO_CONCERTACIONTableAdapter.Fill(data, Id);
                    //Información básica parte B
                    parteB.pAS_REPORTE_PARTE_BTableAdapter.Fill(dataParteB, Id);
                    //Temas proyecto
                    parteB.pAS_REPORTE_PARTE_B_TEMASTableAdapter.Fill(dataParteBTemas, Id);
                    //Preguntas trayectoria proyecto
                    parteB.pAS_REPORTE_PARTE_B_TRAYECTORIATableAdapter.Fill(dataParteBTrayectoria, Id);
                    //Cronograma y actividades obligatorias del proyecto
                    parteB.pAS_REPORTE_PARTE_B_CRONOTableAdapter.Fill(dataParteBCrono, Id);
                    //Presupuesto del proyecto
                    parteB.pAS_REPORTE_PARTE_B_PRESUPUESTOTableAdapter.Fill(dataParteBPresupuesto, Id);
                    //Impactos del proyecto
                    parteB.pAS_REPORTE_PARTE_B_IMPACTOSTableAdapter.Fill(dataParteBImpactos, Id);
                                       
                    string ruta = string.Format("{0}{1}\\", ConfigurationManager.AppSettings["pathSaveReport"], Id);
                    if (!Directory.Exists(ruta))
                    {
                        Directory.CreateDirectory(ruta);
                    }
                    string nombre = string.Format("{0}.pdf", radicado);
                    parteB.ExportToPdf(string.Format("{0}{1}", ruta, nombre));
                    DataAccess.SaveAdjunto(idEnvioCorre, string.Format("{0}\\", Id), nombre);
                    LabMsj.Text = "";
                }
                else
                {
                    LabMsj.Text = "No existe información para salvar el reporte.";
                    LabMsj.ForeColor = Color.Red;
                }
            }
            else
            {
                LabMsj.Text = "Parámetros invalidos.";
                LabMsj.ForeColor = Color.Red;
            }
        }
    }
}