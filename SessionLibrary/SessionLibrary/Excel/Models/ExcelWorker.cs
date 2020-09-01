using OfficeOpenXml;
using SessionLibrary.Excel.DataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SessionLibrary.Excel.Models
{
    /// <summary>
    /// Excel worker
    /// </summary>
    public static class ExcelWorker
    {
        /// <summary>
        /// Write session result's in xlsx file 
        /// </summary>
        /// <param name="filename">File's name</param>
        /// <param name="collection">List of results</param>
        /// <returns></returns>
        public static bool Write(string filename, ICollection<GroupResult> collection)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage();
                package.Workbook.Properties.Title = "Session results";
                package.Workbook.Properties.Created = DateTime.Now;
                string[] headers = { "Surname", "Name", "Midle name", "Date", "Subject", "Work's type", "Result" };
                foreach (GroupResult item in collection)
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(item.GroupName);
                    for (int i = 1; i <= headers.Length; i++)
                    {
                        worksheet.Cells[1, i].Value = headers[i - 1];
                        worksheet.Cells[1, i].Style.Font.Bold = true;
                        worksheet.Column(i).Width = headers.Length * 2;
                    }
                    for (int i = 2, j = 0; j < item.StudentResults.Count; i++, j++)
                    {
                        worksheet.Cells[i, 1].Value = item.StudentResults.ToList()[j].StudentSurname;
                        worksheet.Cells[i, 2].Value = item.StudentResults.ToList()[j].StudentName;
                        worksheet.Cells[i, 3].Value = item.StudentResults.ToList()[j].StudentMidleName;
                        worksheet.Cells[i, 4].Value = item.StudentResults.ToList()[j].Date.ToShortDateString();
                        worksheet.Cells[i, 5].Value = item.StudentResults.ToList()[j].Subject;
                        worksheet.Cells[i, 6].Value = item.StudentResults.ToList()[j].WorkType;
                        worksheet.Cells[i, 7].Value = item.StudentResults.ToList()[j].Result;
                    }
                }
                FileInfo fi = new FileInfo(filename);
                package.SaveAs(fi);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Write all group with them average, minimum and maximum results
        /// </summary>
        /// <param name="filename">File's name</param>
        /// <param name="collection">List of groups</param>
        /// <returns></returns>
        public static bool Write(string filename, ICollection<GroupsAvgMinMax> collection)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage();
                package.Workbook.Properties.Title = "Session results";
                package.Workbook.Properties.Created = DateTime.Now;
                string[] headers = { "Group's name", "Average", "Minimum", "Maximum" };
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("All groups");
                for (int i = 1; i <= headers.Length; i++)
                {
                    worksheet.Cells[1, i].Value = headers[i - 1];
                    worksheet.Cells[1, i].Style.Font.Bold = true;
                    worksheet.Column(i).Width = headers.Length * 5;
                }
                for (int i = 2, j = 0;j < collection.Count; i++,j++)
                {
                    worksheet.Cells[i, 1].Value = collection.ToList()[j].GroupName;
                    worksheet.Cells[i, 2].Value = collection.ToList()[j].Avg.ToString();
                    worksheet.Cells[i, 3].Value = collection.ToList()[j].Min.ToString();
                    worksheet.Cells[i, 4].Value = collection.ToList()[j].Max.ToString();
                }
                FileInfo fi = new FileInfo(filename);
                package.SaveAs(fi);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Write dropour students by groups
        /// </summary>
        /// <param name="filename">File's name</param>
        /// <param name="collection">List of dropout students</param>
        /// <returns></returns>
        public static bool Write(string filename,ICollection<DropOutStudentsByGroup> collection)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage();
                package.Workbook.Properties.Title = "Expel students";
                package.Workbook.Properties.Created = DateTime.Now;
                string[] headers = { "Name", "Surname", "Midle name" };
                foreach (DropOutStudentsByGroup item in collection)
                {
                    if(item.DropoutStudent.Count != 0)
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(item.GroupName);
                        for (int i = 1; i <= headers.Length; i++)
                        {
                            worksheet.Cells[1, i].Value = headers[i - 1];
                            worksheet.Cells[1, i].Style.Font.Bold = true;
                            worksheet.Column(i).Width = headers.Length * 5;
                        }
                        for (int i = 2, j = 0; j < item.DropoutStudent.Count; i++, j++)
                        {
                            worksheet.Cells[i, 1].Value = item.DropoutStudent.ToList()[j].Name;
                            worksheet.Cells[i, 2].Value = item.DropoutStudent.ToList()[j].Surname;
                            worksheet.Cells[i, 3].Value = item.DropoutStudent.ToList()[j].MidleName;
                        }
                    }
                }
                FileInfo fi = new FileInfo(filename);
                package.SaveAs(fi);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
