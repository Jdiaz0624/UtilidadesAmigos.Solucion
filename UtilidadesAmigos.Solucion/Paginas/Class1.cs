using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExcelDataReader;
using System.IO;

namespace UtilidadesAmigos.Solucion.Paginas
{
    public static void LeerExcel(string RUta)
    {

        var Stream = File.Open(RUta, FileMode.Open, FileAccess.Read);
        var Reader = ExcelReaderFactory.CreateReader(Stream);
        var Resultado = Reader.AsDataSet();
        var Tables = Resultado.Tables.Cast<DataTable>();
        foreach (DataTable table in Tables)
        {
            // dataGridView1.DataSource = table;
        }
    }
}