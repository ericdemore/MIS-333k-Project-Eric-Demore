using BevoBnB.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BevoBnB.Models;

namespace BevoBnB.Utilities
{
    public class PdfInvoiceGenerator
    {
        public byte[] GenerateInvoice(string confirmationNumber, List<Reservation> reservations)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12).FontColor(Colors.Black));

                    // Header Section
                    page.Header()
                        .Row(row =>
                        {
                            row.RelativeColumn()
                                .Text("BevoBnB Invoice")
                                .SemiBold()
                                .FontSize(20)
                                .FontColor(Colors.Blue.Medium);

                            row.RelativeColumn()
                                .AlignRight()
                                .Text($"Date: {DateTime.Now:MM-dd-yyyy}")
                                .FontSize(12);
                        });

                    // Content Section
                    page.Content()
                        .PaddingVertical(10)
                        .Column(column =>
                        {
                            column.Spacing(20);

                            // Confirmation Number
                            column.Item().Text($"Confirmation Number: {confirmationNumber}")
                                          .FontSize(14)
                                          .Bold()
                                          .FontColor(Colors.Black);

                            // Reservations Table
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3); // Property Name
                                    columns.RelativeColumn(2); // Check-In
                                    columns.RelativeColumn(2); // Check-Out
                                    columns.RelativeColumn(1); // Nights
                                    columns.RelativeColumn(1); // Total
                                });

                                // Table Header
                                table.Header(header =>
                                {
                                    header.Cell().Element(CellStyle).Background(Colors.Grey.Lighten3).Text("Property ID").Bold();
                                    header.Cell().Element(CellStyle).Background(Colors.Grey.Lighten3).Text("Check-In").Bold();
                                    header.Cell().Element(CellStyle).Background(Colors.Grey.Lighten3).Text("Check-Out").Bold();
                                    header.Cell().Element(CellStyle).Background(Colors.Grey.Lighten3).Text("Nights").Bold();
                                    header.Cell().Element(CellStyle).Background(Colors.Grey.Lighten3).Text("Total").Bold();
                                });

                                // Add Reservations Rows
                                foreach (var reservation in reservations)
                                {
                                    table.Cell().Element(CellStyle).Text(reservation.Property.PropertyID);
                                    table.Cell().Element(CellStyle).Text(reservation.CheckIn.ToShortDateString());
                                    table.Cell().Element(CellStyle).Text(reservation.CheckOut.ToShortDateString());
                                    table.Cell().Element(CellStyle).Text(reservation.TotalNights.ToString());
                                    table.Cell().Element(CellStyle).Text($"${reservation.Total:F2}");
                                }
                            });

                            // Totals Section
                            column.Item().PaddingTop(20).AlignRight().Text(text =>
                            {
                                text.Line($"Stay Total: ${reservations.Sum(r => r.StayTotal):F2}")
                                    .FontColor(Colors.Black);
                                text.Line($"Cleaning Fee: ${reservations.Sum(r => r.CleaningFee):F2}")
                                    .FontColor(Colors.Black);
                                text.Line($"Sales Tax: ${reservations.Sum(r => r.SalesTax):F2}")
                                    .FontColor(Colors.Black);
                                text.Line($"Discount: ${reservations.Sum(r => r.DiscountAmount):F2}")
                                    .FontColor(Colors.Red.Medium);
                                text.Line($"Grand Total: ${reservations.Sum(r => r.Total):F2}")
                                    .Bold()
                                    .FontSize(14)
                                    .FontColor(Colors.Green.Darken2);
                            });
                        });

                    // Footer Section
                    page.Footer()
                        .AlignCenter()
                        .PaddingTop(20)
                        .Text(x =>
                        {
                            x.Span("Thank you for choosing BevoBnB! ").Bold();
                            x.Line("For inquiries, contact support@bevobnb.com.");
                        });
                });
            });

            using var stream = new MemoryStream();
            document.GeneratePdf(stream);
            return stream.ToArray();
        }

        private QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer container)
        {
            return container.Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
        }
    }
}
