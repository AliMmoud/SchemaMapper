﻿using System;
using System.Data;

namespace SchemaMapperDLL.Classes.Converters
{
    public abstract class BaseImport
    {

        #region declaration
        public string FilePath { get; set; }
        public bool RemoveEmptyColumns { get; set; } 
        public DataSet Maindataset { get; set; } 
        public  bool HasHeader { get; set; } 
        public  int RowsToSkip { get; set; } 

        #endregion

        #region abstract methods

        public BaseImport() { }

        #endregion

        #region methods
        public void ExportdataTableAsXml(string v_ExportPath, int index)
        {
            Maindataset.Tables[index].WriteXml(v_ExportPath + "\\" + 
                Maindataset.Tables[index].TableName + ".xml", XmlWriteMode.WriteSchema, false);
        }

        public void ExportdataTableAsXml(string v_ExportPath,string tablename)
        {
         Maindataset.Tables[tablename].WriteXml(v_ExportPath + "\\" + 
             tablename + DateTime.Now.ToString("yyyyMMddHHmmsss") + ".xml", XmlWriteMode.WriteSchema, false);
        }

        public void ExportdataTablesAsXml(string v_ExportPath)
        {
            foreach (DataTable dtTable in Maindataset.Tables)
            {
                dtTable.WriteXml(v_ExportPath + "\\" + 
                    dtTable.TableName + DateTime.Now.ToString("yyyyMMddHHmmsss") + ".xml", XmlWriteMode.WriteSchema, false);
            }
        }

        public void ExportDataSetAsXml(string v_ExportPath)
        {
         Maindataset.WriteXml(v_ExportPath + "\\" + 
             DateTime.Now.ToString("yyyyMMddHHmmsss") + ".xml", XmlWriteMode.WriteSchema);
        }

        #endregion

        //public void ConvertDataTablesToXml(string v_ExportPath)
        //{
        //    int intConvertedTables = 0;

        //    using (TableConverter tcConverter = new TableConverter(FilePath, ConfigClass, importLogId, uInput))
        //    {
        //        foreach (DataTable dtTable in Maindataset.Tables)
        //        {
        //            using (DataTable TempTable = tcConverter.ChangeTableStructureUsingColumnsMapping(dtTable, ConfigClass.dsMain.Tbl_ColumnsMapping, RemoveEmptyColumns, TemplateID, true))
        //            {
        //                if (!TempTable == null)
        //                {
        //                    tcConverter.ExportTablesAsXml(TempTable, v_ExportPath);
        //                    intConvertedTables += 1;
        //                }
        //            }
        //        }
        //    }

        //if (intConvertedTables == 0)
        //    throw new Exception("All tables are empty");
        //}
    }
}
