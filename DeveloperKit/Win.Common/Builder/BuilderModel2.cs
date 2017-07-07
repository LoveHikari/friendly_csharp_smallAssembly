using System;
using System.Collections.Generic;
using System.Text;
using Win.Models;

namespace Win.Common.Builder
{
    /// <summary>
    /// ��ϵ�л���Model�����������
    /// </summary>
    public class BuilderModel2
    {
        #region �ֶ�
        private string _modelpath;  //ʵ����������ռ�
        private List<ColumnModel> _fieldlist;  //ѡ����ֶμ���
        private string _modelName;  //ʵ������
        #endregion

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="fieldlist">ѡ����ֶμ���</param>
        /// <param name="modelpath">ʵ����������ռ�</param>
        /// <param name="modelSuffix">ʵ����ĺ�׺</param>
        public BuilderModel2(List<ColumnModel> fieldlist, string modelpath, string modelSuffix)
        {
            
            _fieldlist = fieldlist;
            _modelpath = modelpath;
            string tableName = _fieldlist[0].TableName;
            _modelName = tableName.ToPascal() + modelSuffix;
        }
        /// <summary>
        /// ʵ����������ռ�
        /// </summary>
        public string Modelpath { get => _modelpath; set => _modelpath = value; }
        /// <summary>
        /// ѡ����ֶμ���
        /// </summary>
        public List<ColumnModel> Fieldlist { get => _fieldlist; set => _fieldlist = value; }
        /// <summary>
        /// ʵ������
        /// </summary>
        public string ModelName { get => _modelName; set => _modelName = value; }


        /// <summary>
        /// ��������Model��
        /// </summary>
        public virtual string CreatModel()
        {
            StringBuilder strclass = new StringBuilder();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using System.Runtime.Serialization;");
            strclass.AppendLine("namespace " + _modelpath);
            strclass.AppendLine("{");
            strclass.AppendSpaceLine(1, "/// <summary>");
            if (_fieldlist[0].TableDescription.Length > 0)
            {
                strclass.AppendSpaceLine(1, "/// " + _fieldlist[0].TableDescription.Replace("\r\n", "\r\n\t///"));
            }
            else
            {
                strclass.AppendSpaceLine(1, "/// " + _fieldlist[0].TableName + ":ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)");
            }
            strclass.AppendSpaceLine(1, "/// </summary>");
            strclass.AppendSpaceLine(1, "[Serializable]");
            strclass.AppendSpaceLine(1, "public partial class " + _modelName);
            strclass.AppendSpaceLine(1, "{");
            strclass.AppendLine(CreatModelMethod());
            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            strclass.AppendLine("");

            return strclass.ToString();
        }


        /// <summary>
        /// ����ʵ���������
        /// </summary>
        /// <returns></returns>
        public virtual string CreatModelMethod()
        {
            int i = 1;
            StringBuilder strclass = new StringBuilder();
            StringBuilder strclass2 = new StringBuilder();
            strclass.AppendSpaceLine(2, "#region Model");
            foreach (ColumnModel field in _fieldlist)
            {
                string columnName = field.ColumnName;
                string columnTypedb = field.TypeName;
                bool isIdentity = field.IsIdentity;
                bool ispk = field.IsPrimaryKey;
                bool cisnull = field.IsCanNull;
                //string defValue=field.DefaultVal;
                string deText = field.Description;
                string columnType = Win.Common.CodeCommon.DbTypeToCS(columnTypedb);
                string isnull = "";
                if ((!isIdentity) && (!ispk) && (cisnull) && (columnType!="string"))
                {
                    isnull = "?";//����ɿ�����
                }

                strclass2.AppendSpaceLine(2, "/// <summary>");
                strclass2.AppendSpaceLine(2, "/// " + deText);
                strclass2.AppendSpaceLine(2, "/// </summary>");
                strclass2.AppendSpaceLine(2, "public " + columnType + isnull + " " + columnName.ToFirstUpper() + " { get; set; }");//����
                i++;
            }
            strclass.Append(strclass2);
            strclass.AppendSpaceLine(2, "#endregion Model");

            return strclass.ToString();
        }




    }
}
