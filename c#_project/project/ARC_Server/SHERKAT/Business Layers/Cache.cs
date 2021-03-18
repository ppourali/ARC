using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Mehr.Business_Layers
{
    class Cache
    {
        private static String[] fieldNames = new string[] { "id", "darman_date", "payan_date", "name", "masrafi_type",
            "ravesh_tark", "status" , "hesab", "roozaneh", "monthFee"};

        private static Dictionary<String, Sicks> closedSicksCache = new Dictionary<String, Sicks>();
        private static Dictionary<String, Sicks> openSicksCache = new Dictionary<String, Sicks>();
        private static bool isDailyReal = false;
        private static bool isMonthlyDaftari = false;
        private static bool isTakhfif = false;
         
        public static void putRecords(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0)
                return;

            DataColumnCollection cols = rows[0].Table.Columns;
            foreach (DataRow r in rows)
            {
                Sicks sick = new Sicks();
                Type fieldTypes = typeof(Sicks);

                foreach (String fieldName in fieldNames)
                {
                    if (cols.Contains(fieldName))
                    {
                        FieldInfo fld = fieldTypes.GetField(fieldName);
                        fld.SetValue(sick, r[fieldName]);
                    }
                }

                putRecord(sick);
            }
        }

        internal static void resetGenSettings()
        {
            isTakhfif = false;
            isMonthlyDaftari = false;
            isDailyReal = false;
        }

        public static void putRecords(DataTable table)
        {
            if (table == null || table.Rows.Count == 0)
                return;

            DataRowCollection rows = table.Rows;
            DataColumnCollection cols = table.Columns;

            foreach (DataRow r in rows)
            {
                Sicks sick = new Sicks();
                Type fieldTypes = typeof(Sicks);

                foreach (String fieldName in fieldNames)
                {
                    if (cols.Contains(fieldName))
                    {
                        FieldInfo fld = fieldTypes.GetField(fieldName);
                        fld.SetValue(sick, r[fieldName]);
                    }
                }

                putRecord(sick);
            }
        }

       

        public static void putRecord(DataRow row)
        {
            if (row == null)
                return;

            DataColumnCollection cols = row.Table.Columns;

            Sicks sick = new Sicks();
            Type fieldTypes = typeof(Sicks);

            foreach (String fieldName in fieldNames)
            {
                if (cols.Contains(fieldName))
                {
                    FieldInfo fld = fieldTypes.GetField(fieldName);
                    fld.SetValue(sick, row[fieldName]);
                }
            }

            putRecord(sick);
        }

        public static void updateRecord(Sicks sick)
        {
            if (sick == null)
                return;

            if (sick.payan_date.Replace(" ", "").Length == 10)
            {
                closedSicksCache[sick.id.ToString()] = sick;
                if (openSicksCache.ContainsKey(sick.id.ToString()))
                    openSicksCache.Remove(sick.id.ToString());
            }
            else
            {
                openSicksCache[sick.id.ToString()] = sick;
                if (closedSicksCache.ContainsKey(sick.id.ToString()))
                    closedSicksCache.Remove(sick.id.ToString());

            }
        }

        public static void putRecord(Sicks sick)
        {
            if (sick == null)
                return;

            if (sick.payan_date.Replace(" ", "").Length == 10)
            {
                closedSicksCache[sick.id.ToString()] = sick;
            }
            else
            {
                openSicksCache[sick.id.ToString()] = sick;

            }
        }

        public static String closedDate(String id)
        {
            if(closedSicksCache.ContainsKey(id.Trim()))
            {
                Sicks sick = closedSicksCache[id.Trim()];
                return sick.payan_date;
            }

            return "";
        }

        internal static void updateHesab(string id, long hesab, string status)
        {
            if (closedSicksCache.ContainsKey(id.Trim()))
            {
                Sicks sick = closedSicksCache[id.Trim()];
                sick.hesab = hesab;
                sick.status = status;

                closedSicksCache[id.ToString()] = sick;
            }
            else if (openSicksCache.ContainsKey(id.Trim()))
            {
                Sicks sick = openSicksCache[id.Trim()];
                sick.hesab = hesab;
                sick.status = status;

                openSicksCache[id.ToString()] = sick;
            }
        }

        public static void updateCloseDate(string id, string payan_date)
        {
            if (closedSicksCache.ContainsKey(id.Trim()))
            {
                Sicks sick = closedSicksCache[id.Trim()];
                sick.payan_date = payan_date;

                putRecord(sick);
            }
            else if (openSicksCache.ContainsKey(id.Trim()))
            {
                Sicks sick = openSicksCache[id.Trim()];
                sick.payan_date = payan_date;

                openSicksCache.Remove(id.Trim());
                putRecord(sick);
            }
        }

        public static void updateGenSettings(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                updatePayPeriod(dt.Rows[0]["PayType"].ToString(), dt.Rows[0]["DaftariPayType"].ToString());
                updateTakhfif(dt.Rows[0]["Takhfif_Inc"].ToString());
            }

        }

        public static void updatePayPeriod(String payType, String daftartiPayType)
        {
            if (payType != null)
                isDailyReal = payType.Trim().Equals("روزانه");

            if (daftartiPayType != null)
                isMonthlyDaftari = daftartiPayType.Trim().Equals("ماهانه");
        }

        public static void updateTakhfif(String takhfif)
        {
            if (takhfif != null)
                isTakhfif = takhfif.Trim().Equals("بلی");
        }

        public static bool isDaftartiMonthly()
        {
            return isMonthlyDaftari;
        }
        public static bool isRealDaily()
        {
            return isDailyReal;
        }
        public static bool isTakhfifApplied()
        {
            return isTakhfif;
        }
    }
}
