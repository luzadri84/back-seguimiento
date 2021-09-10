using DevExpress.XtraReports.UI;
using System.Drawing;

namespace MinCultura.Reports.Web.Reportes
{
    public partial class XtraReportParteB : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportParteB()
        {
            InitializeComponent();
        }

        private void xrTableCell462_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            bool tipoRecursoEntidad = GetCurrentColumnValue<bool>("TIP_RECURSOS_ENTIDAD");
            if (!tipoRecursoEntidad)
            {
                XRTableCell xRTable = (XRTableCell)sender;
                xRTable.ForeColor = Color.White;
            }
        }

        private void xrTableCell492_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            bool tipoRecursoEntidad = GetCurrentColumnValue<bool>("TIP_RECURSOS_ENTIDAD");
            if (!tipoRecursoEntidad)
            {
                XRTableCell xRTable = (XRTableCell)sender;
                xRTable.ForeColor = Color.White;
            }
        }
    }
}
