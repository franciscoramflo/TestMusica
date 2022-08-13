using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;
using Telerik.Reporting.Services;
using Telerik.Reporting.Services.Engine;

namespace Musica.Web.Classes
{

    class ReportSourceResolverWithFallBack : IReportSourceResolver
    {
        readonly IReportSourceResolver parentResolver;
        readonly string connectionString;

        public ReportSourceResolverWithFallBack(string connectionString, IReportSourceResolver parentResolver)
        {
            this.parentResolver = parentResolver;
            this.connectionString = connectionString;
        }

        public ReportSource Resolve(string report, OperationOrigin operationOrigin, IDictionary<string, object> currentParameterValues)
        {
            ReportSource reportDocument = null;
            string[] files = { "LogbookReturn.trdx" };

            if (files.Contains(report))
            {
                ParameterCollection parameters = new ParameterCollection();
                foreach (var parameter in currentParameterValues)
                {
                    parameters.Add(new Parameter()
                    {
                        Name = parameter.Key,
                        Value = parameter.Value
                    });
                }

                reportDocument = this.ResolveCustomReportSource(report, parameters);
            }

            if (null == reportDocument && null != this.parentResolver)
            {
                reportDocument = this.parentResolver.Resolve(report, operationOrigin, currentParameterValues);
            }

            return reportDocument;
        }

        public ReportSource ResolveCustomReportSource(string reportName, ParameterCollection parameters)
        {
            UriReportSource sourceReportSource = new UriReportSource { Uri = "Reports/" + reportName };
            sourceReportSource.Parameters.AddRange(parameters);
            ReportSource reportSource = UpdateReportSource(sourceReportSource);
            return reportSource;
        }

        public ReportSource UpdateReportSource(ReportSource sourceReportSource)
        {
            Report reportInstance = null;

            if (sourceReportSource is UriReportSource)
            {
                UriReportSource uriReportSource = (UriReportSource)sourceReportSource;
                reportInstance = DeserializeReport(uriReportSource);

                //string selectCommand = @"SELECT * FROM Sales.Store";
                //SqlDataSource sqlDataSource = new SqlDataSource(connectionString, selectCommand);

                //TextBox textBoleta = reportInstance.Items.Find("Boleta", true)[0] as TextBox;
                //TextBox lblBoleta = reportInstance.Items.Find("lblBoleta", true)[0] as TextBox;
                //textBoleta.Value = "1893242";
                //TextBox auxText = new TextBox()
                //{
                //    Name = textBoleta.Name + "1",
                //    Size = textBoleta.Size,
                //    StyleName = textBoleta.StyleName,
                //    Value = "4298420",
                //    Location = textBoleta.Location
                //};

                //auxText.Style.BorderStyle.Default = textBoleta.Style.BorderStyle.Default;
                //auxText.Location = new PointU(auxText.Location.X, new Unit(Convert.ToDouble(textBoleta.Location.Y.Value) + 2, UnitType.Cm));

                //DetailSection detail1 = reportInstance.Items.Find("detailSection1", true)[0] as DetailSection;
                //detail1.Items.AddRange(new ReportItemBase[] { auxText });

                ValidateReportSource(uriReportSource.Uri);
                //SetConnectionString(reportInstance);
                return CreateInstanceReportSource(reportInstance, uriReportSource);
            }

            throw new NotImplementedException("Handler for the used ReportSource type is not implemented.");
        }

        ReportSource CreateInstanceReportSource(IReportDocument report, ReportSource originalReportSource)
        {
            InstanceReportSource instanceReportSource = new InstanceReportSource { ReportDocument = report };
            instanceReportSource.Parameters.AddRange(originalReportSource.Parameters);
            return instanceReportSource;
        }

        void ValidateReportSource(string value)
        {
            if (value.Trim().StartsWith("="))
            {
                throw new InvalidOperationException("Expressions for ReportSource are not supported when changing the connection string dynamically");
            }
        }

        Report DeserializeReport(UriReportSource uriReportSource)
        {
            var settings = new System.Xml.XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (var xmlReader = System.Xml.XmlReader.Create(uriReportSource.Uri, settings))
            {
                var xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
                var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);
                return report;
            }
        }

        void SetConnectionString(ReportItemBase reportItemBase)
        {
            if (reportItemBase.Items.Count < 1)
                return;

            if (reportItemBase is Report)
            {
                var report = (Report)reportItemBase;

                if (report.DataSource is SqlDataSource)
                {
                    var sqlDataSource = (SqlDataSource)report.DataSource;
                    sqlDataSource.ConnectionString = connectionString;
                }
                foreach (var parameter in report.ReportParameters)
                {
                    if (parameter.AvailableValues.DataSource is SqlDataSource)
                    {
                        var sqlDataSource = (SqlDataSource)parameter.AvailableValues.DataSource;
                        sqlDataSource.ConnectionString = connectionString;
                    }
                }
            }

            foreach (var item in reportItemBase.Items)
            {
                //recursively set the connection string to the items from the Items collection
                SetConnectionString(item);

                //set the drillthrough report connection strings
                var drillThroughAction = item.Action as NavigateToReportAction;
                if (null != drillThroughAction)
                {
                    var updatedReportInstance = this.UpdateReportSource(drillThroughAction.ReportSource);
                    drillThroughAction.ReportSource = updatedReportInstance;
                }

                if (item is SubReport)
                {
                    var subReport = (SubReport)item;
                    subReport.ReportSource = this.UpdateReportSource(subReport.ReportSource);
                    continue;
                }

                //Covers all data items(Crosstab, Table, List, Graph, Map and Chart)
                if (item is DataItem)
                {
                    var dataItem = (DataItem)item;
                    if (dataItem.DataSource is SqlDataSource)
                    {
                        var sqlDataSource = (SqlDataSource)dataItem.DataSource;
                        sqlDataSource.ConnectionString = connectionString;
                        continue;
                    }
                }

            }
        }
    }

}
