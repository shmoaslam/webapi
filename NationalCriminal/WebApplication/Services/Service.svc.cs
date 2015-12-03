using BusinessEntities;
using BusinessServices.interfaces;
using BusinessServices.services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WebApplication.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        private readonly ICriminalServices _criminalServices;


        public Service()
        {
            _criminalServices = new CriminalServices();
        }


        public void DoWork()
        {
        }

        public bool SearchCriminal(SearchCriminalModel objModel)
        {

            if (objModel != null)
            {
                new Thread(() => SendEmailWithListOfCriminal(objModel)).Start();
                return true;
            }
            return false;

        }

        private void SendEmailWithListOfCriminal(SearchCriminalModel objModel)
        {
            var criminals = FilterCriminals(objModel);

            if (criminals != null) CreatePDFFiles(criminals);


        }

        private void CreatePDFFiles(IEnumerable<CriminalEntity> criminals)
        {
            foreach (var criminal in criminals)
            {
                if (criminal != null) CreateCriminalPDF(criminal);
            }
        }

        private void CreateCriminalPDF(CriminalEntity criminal)
        {
            string content = GetDefaultData();
            string criminalData = GetCriminalData(criminal, content);
            CreateCriminalPDF(criminalData, criminal.FName);

        }

        private void CreateCriminalPDF(string criminalData, string fName)
        {
            string fileLoc = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/") + "/" + fName + ".pdf";
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(fileLoc, FileMode.Create));
            document.Open();
            iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);
            hw.Parse(new StringReader(criminalData));
            document.Close();
        }



        private string GetCriminalData(CriminalEntity entity, string content)
        {
            return content.Replace("{{Criminal_Name}}", entity.FName + entity.LName)
                .Replace("{{Criminal_Age}}", entity.Age != null ? entity.Age.ToString() : "Not Available")
                .Replace("{{Criminal_Sex}}", !string.IsNullOrEmpty(entity.Sex) ? entity.Sex : "Not Available")
                .Replace("{{Criminal_Height}}", entity.Height != null ? entity.Height.ToString() : "Not Available")
                .Replace("{{Criminal_Weight}}", entity.Weight != null ? entity.Weight.ToString() : "Not Available")
                .Replace("{{Criminal_Nationality}}", !string.IsNullOrEmpty(entity.Nationality) ? entity.Nationality : "Not Available");
        }

        private string GetDefaultData()
        {
            StringBuilder sb = new StringBuilder();
            string fileLoc = System.Web.Hosting.HostingEnvironment.MapPath("~/profile.html");
            using (StreamReader sr = new StreamReader(fileLoc))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            string allines = sb.ToString();
            return allines;
        }

        private IEnumerable<CriminalEntity> FilterCriminals(SearchCriminalModel objModel)
        {
            IEnumerable<CriminalEntity> criminals = null;
            if (!string.IsNullOrEmpty(objModel.Name))
                criminals = _criminalServices.GetAllCriminals().Where(x => x.FName.Trim().ToLower().Equals(objModel.Name.Trim().ToLower()) || x.LName.Trim().ToLower().Equals(objModel.Name.Trim().ToLower()));

            if (criminals == null) return criminals;

            if (objModel.MinAge != null)
                criminals = criminals.Where(x => x.Age > objModel.MinAge);

            if (criminals == null) return criminals;

            if (objModel.MaxAge != null)
                criminals = criminals.Where(x => x.Age < objModel.MaxAge);

            if (criminals == null) return criminals;

            if (!string.IsNullOrEmpty(objModel.Sex))
                criminals = criminals.Where(x => x.Sex.Trim().ToLower().Equals(objModel.Sex.Trim().ToLower()));

            if (criminals == null) return criminals;

            if (objModel.MinHeight != null)
                criminals = criminals.Where(x => x.Height > objModel.MinHeight);

            if (criminals == null) return criminals;

            if (objModel.MaxHeight != null)
                criminals = criminals.Where(x => x.Height < objModel.MaxHeight);

            if (criminals == null) return criminals;

            if (objModel.MinWeight != null)
                criminals = criminals.Where(x => x.Weight > objModel.MinWeight);

            if (criminals == null) return criminals;

            if (objModel.MaxWeigth != null)
                criminals = criminals.Where(x => x.Weight < objModel.MaxWeigth);

            if (criminals == null) return criminals;

            if (!string.IsNullOrEmpty(objModel.Nationality))
                criminals = criminals.Where(x => x.Nationality.Trim().ToLower().Equals(objModel.Nationality.Trim().ToLower()));

            return criminals;

        }
    }
}
