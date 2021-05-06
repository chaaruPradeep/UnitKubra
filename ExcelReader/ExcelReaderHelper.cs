using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
namespace UnitKubra.ExcelReader
{
    public class ExcelReaderHelper
    {
        private static IDictionary<string, IExcelDataReader> _cache;
        private static FileStream stream;
        private static IExcelDataReader reader;

        static ExcelReaderHelper()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }

        public static object GetCellData(string xlPath, string sheetName, int row, int column)
        {
            if (_cache.ContainsKey(sheetName))
            {
                reader = _cache[sheetName];
            }
            else
            {
                stream = new FileStream(xlPath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                _cache.Add(sheetName, reader);
            }
            DataTable table = reader.AsDataSet().Tables[sheetName];
            return GetData(table.Rows[row][column].GetType(), table.Rows[row][column]);
        }

        private static object GetData(Type type, object data)
        {
            switch (type.Name)
            {
                case "String":
                    return data.ToString();
                case "Double":
                    return Convert.ToDouble(data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                default:
                    return data.ToString();
            }
        }
    }
}
