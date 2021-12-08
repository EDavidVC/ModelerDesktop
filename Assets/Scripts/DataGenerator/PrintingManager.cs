using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sfs2X.Entities.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

public class PrintingManager : MonoBehaviour
{
    string path;
    PdfPTable table = new PdfPTable(2);
    private Document pdfDocument;
    FileStream fileStream;    
    void Start()
    {
        path = Application.dataPath + "/Document.pdf";  
    }
    private void takeScreenShoot(){
        string name = string.Format("{0}/{1:D03} shot.png", "capturas", Time.frameCount);
        ScreenCapture.CaptureScreenshot(name);
    }
    public void GenerateFile() {
        takeScreenShoot();

        //Verify if the old archive exist!! before delete.
        if (File.Exists(path)) File.Delete(path);


        using (fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            pdfDocument = new Document(PageSize.A4,75,75,75,75);
            var writer = PdfWriter.GetInstance(pdfDocument, fileStream);

            pdfDocument.Open();

            pdfDocument.NewPage();

            var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Paragraph p = new Paragraph(string.Format("Ticket Id : {0}",12345 )); //iSFSObject.GetUtfString("TICKET_ID"
            p.Alignment = Element.ALIGN_BOTTOM;

            
            pdfDocument.Add(p);
          
                p = new Paragraph(string.Format("Bet Number : {0}     BetAmount : {1}", 1, 100));
                p.Alignment = Element.ALIGN_CENTER;
                pdfDocument.Add(p);
        

            pdfDocument.Close();
            writer.Close();
        }



        //StreamWriter writer = new StreamWriter(path, false);
        //writer.WriteLine(string.Format("Ticket Id : {0}",iSFSObject.GetUtfString("TICKET_ID")));
        //var betting = iSFSObject.GetSFSArray("BET_DETAILS");
        //for (int i = 0; i< betting.Count;i++)
        //    writer.WriteLine(string.Format("Bet Number : {0}     BetAmount : {1}", betting.GetSFSObject(i).GetUtfString("BET_NUM"), betting.GetSFSObject(i).GetDouble("BET_AMOUNT")));
        //writer.Close();

        PrintFiles();
    }

    void PrintFiles()
    {
        Debug.Log(path);
        if (path == null)
            return;

        if (File.Exists(path))
        {
            Debug.Log("file found");
            //var startInfo = new System.Diagnostics.ProcessStartInfo(path);
            //int i = 0;
            //foreach (string verb in startInfo.Verbs)
            //{
            //    // Display the possible verbs.
            //    Debug.Log(string.Format("  {0}. {1}", i.ToString(), verb));
            //    i++;
            //}
        }
        else
        {
            Debug.Log("file not found");
            return;
        }
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        process.StartInfo.UseShellExecute = true;
        process.StartInfo.FileName = path;
        //process.StartInfo.Verb = "print";

        process.Start();
        //process.WaitForExit();

    }
}
