using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using Mehr.Utils;

namespace Mehr.Business_Layers
{
    class Cache
    {
        private static String[] fieldNames = new string[] { "id", "darman_date", "payan_date", "name", "masrafi_type",
            "ravesh_tark", "status" , "hesab", "roozaneh", "monthFee"};

        private static Dictionary<String, Sicks> openSicksCache = new Dictionary<String, Sicks>();
        private static Dictionary<String, String> closeDatesCache = new Dictionary<String, String>();

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

        internal static void resetSicksCache()
        {
            openSicksCache = new Dictionary<String, Sicks>();
            closeDatesCache= new Dictionary<String, String>();
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

            if (DateUtils.isCompleteDate(sick.payan_date))
            {
                closeDatesCache[sick.id.ToString()] = sick.payan_date;
                if (openSicksCache.ContainsKey(sick.id.ToString()))
                    openSicksCache.Remove(sick.id.ToString());
            }
            else
            {
                openSicksCache[sick.id.ToString()] = sick;
                if (closeDatesCache.ContainsKey(sick.id.ToString()))
                    closeDatesCache.Remove(sick.id.ToString());

            }
        }

        public static void putRecord(Sicks sick)
        {
            if (sick == null)
                return;

            if (!DateUtils.isCompleteDate(sick.payan_date))
            {
                openSicksCache[sick.id.ToString()] = sick;
                if (closeDatesCache.ContainsKey(sick.id.ToString()))
                    closeDatesCache.Remove(sick.id.ToString());

            }
            else
            {
                closeDatesCache[sick.id.ToString()] = sick.payan_date;
                if (openSicksCache.ContainsKey(sick.id.ToString()))
                    openSicksCache.Remove(sick.id.ToString());
            }
        }

        public static String closedDate(String id)
        {
            if(closeDatesCache.ContainsKey(id.Trim()))
            {
                return closeDatesCache[id.Trim()];
            }

            return "";
        }

        internal static void updateHesab(string id, long hesab, string status)
        {
           if (openSicksCache.ContainsKey(id.Trim()))
            {
                Sicks sick = openSicksCache[id.Trim()];
                sick.hesab = hesab;
                sick.status = status;

                openSicksCache[id.ToString()] = sick;
            }
        }

        public static void updateCloseDate(string id, string payan_date)
        {

            if (!DateUtils.isCompleteDate(payan_date))
            {
                if (openSicksCache.ContainsKey(id.Trim()))
                {
                    Sicks sick = openSicksCache[id.Trim()];
                    sick.payan_date = payan_date;

                    openSicksCache.Remove(id.Trim());
                    putRecord(sick);
                }
                else
                {
                    Sicks sick = new Sicks();
                    sick.id = id;
                    DataTable dt = sick.Selectforedit();
                    putRecords(dt);
                    updateCloseDate(id, payan_date);
                }
            }
            else
            {
                if (openSicksCache.ContainsKey(id.Trim()))
                {
                    openSicksCache.Remove(id.Trim());
                }

                closeDatesCache[id.Trim()] = payan_date;

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

        internal static void generateContents()
        {
            resetSicksCache();
            resetGenSettings();

            Sicks sicks = new Sicks();
            DataTable allSicks = sicks.Select();
            putRecords(allSicks);

            Gen_settings genSettings = new Gen_settings();
            DataTable settings = genSettings.Select();
        }

        public static bool isTakhfifApplied()
        {
            return isTakhfif;
        }
    }
}
