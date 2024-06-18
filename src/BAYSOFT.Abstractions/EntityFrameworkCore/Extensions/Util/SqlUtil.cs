using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Microsoft.Data.SqlClient;
using BAYSOFT.Abstractions.EntityFrameworkCore.Extensions.Util;

namespace BAYSOFT.Abstractions.EntityFrameworkCore.Extensions
{
    internal static class SqlUtil
    {
        internal static string ConvertToColumnString(IEnumerable<string> columnNames)
        {
            return string.Join(",", columnNames);
        }
    }
}