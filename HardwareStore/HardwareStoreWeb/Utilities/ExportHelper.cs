using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using System.ComponentModel;
using System.Net.Mime;

namespace HardwareStoreWeb.Utilities
{
    public class ExportHelper
    {
        public static async Task<FileStreamResult> ExportToExcel(PageModel pageModel, string worksheetName, List<string[]> headerRow, List<object[]> cellData)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using var excel = new ExcelPackage();

            excel.Workbook.Worksheets.Add(worksheetName);

            var headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

            var worksheet = excel.Workbook.Worksheets[worksheetName];
            worksheet.Cells[headerRange].LoadFromArrays(headerRow);

            worksheet.Cells[2, 1].LoadFromArrays(cellData);

            var memoryStream = new MemoryStream();
            await excel.SaveAsAsync(memoryStream);

			memoryStream.Position = 0;

			return pageModel.File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{worksheetName}.xlsx");
		}
    }
}
