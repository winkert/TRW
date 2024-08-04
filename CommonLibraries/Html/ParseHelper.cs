using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace TRW.CommonLibraries.Html
{
    public static class ParseHelper
    {
        internal const string TableExpression = "<table[^>]*>(.*?)</table>";
        internal const string HeaderExpression = "<th[^>]*>(.*?)</th>";
        internal const string RowExpression = "<tr[^>]*>(.*?)</tr>";
        internal const string ColumnExpression = "<td[^>]*>(.*?)</td>";

        internal const string TableClose = "</table>";

        public static DataTable ExtractTableFromHtml(string html)
        {
            DataTable dt = new DataTable();

            MatchCollection Tables = Regex.Matches(html, TableExpression, RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);
            foreach (Match T in Tables)
            {
                if (T.Value.Contains("<th"))
                {
                    MatchCollection Headers = Regex.Matches(T.Value,
                    HeaderExpression,
                    RegexOptions.Singleline |
                    RegexOptions.Multiline |
                    RegexOptions.IgnoreCase);

                    foreach (Match Header in Headers)
                    {
                        dt.Columns.Add(Header.Groups[1].ToString());
                    }
                }

                int iCurrentRow = 0;
                int iCurrentColumn = 0;

                MatchCollection Rows = Regex.Matches(T.Value, RowExpression, RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);

                foreach (Match Row in Rows)
                {
                    if (iCurrentRow != 0)
                    {
                        DataRow dr = dt.NewRow();
                        iCurrentColumn = 0;

                        MatchCollection Columns = Regex.Matches(Row.Value, ColumnExpression, RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase);

                        foreach (Match Column in Columns)
                        {
                            dr[iCurrentColumn] = Column.Groups[1].ToString();
                            iCurrentColumn++;
                        }

                        dt.Rows.Add(dr);
                    }
                    iCurrentRow++;
                }

            }
            return dt;

        }
    }
}
