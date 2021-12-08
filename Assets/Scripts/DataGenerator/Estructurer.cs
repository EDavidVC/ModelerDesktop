using System.Collections;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UnityEngine;

public class Estructurer : MonoBehaviour
{
    string path;
    private Document pdfDocument;
    FileStream fileStream;
    public string lastImageUrl = "";
    string directory = "";
    string filename = "";
    double price = 0;
    void Start()
    {
        directory = directory != "" ? Directory.CreateDirectory(directory).FullName : Directory.CreateDirectory(Path.Combine(Application.dataPath, "../Exportado/Planos")).FullName;
        filename = "plano-"+System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + ".pdf";
        
        string filepath = Path.Combine(directory, filename);

        Estructurer estructurer = GameObject.Find("globalData").GetComponent<Estructurer>();
        if(estructurer){
            estructurer.lastImageUrl = filepath;
        }
        path = filepath;
    }
    private IEnumerator tomarCaptura()
    {
        int width = 400;
        int height = 400;
        //string name = string.Format("{0}/{1:D03} shot.png", "capturas", Time.frameCount);
        //ScreenCapture.CaptureScreenshot(name);

        yield return new WaitForEndOfFrame();
        GameObject model = GameObject.Find("modelContainer/principal");
        Vector2 temp = model.transform.position;
        var startx = temp.x - width / 2;
        var starty = temp.y - height / 2;

        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(startx, starty, width, height), 0, 0);
        tex.Apply();

        var bytes = tex.EncodeToPNG();
        Destroy(tex);
        File.WriteAllBytes(Application.dataPath + "/captura.png", bytes);


    }

    public void GenerateFile()
    {
        filename = "plano-"+System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + ".pdf";
        string filepath = Path.Combine(directory, filename);
        path = filepath;
        //StartCoroutine(tomarCaptura());

        //Verify if the old archive exist!! before delete.
        if (File.Exists(path)) File.Delete(path);

        using (fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            //PdfPTable table = new PdfPTable(1);
            pdfDocument = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(pdfDocument, fileStream);

            pdfDocument.Open();
            pdfDocument.NewPage(); //New Page
            var p = new Paragraph(string.Format("Estructuras Manuel Gonzales\n"));
            p.Alignment = Element.ALIGN_CENTER;
            
            PdfPTable mtable = getMaterialRequired();

            PdfPTable pritable = getPrincipalTable();
            
            pdfDocument.Add(p);
            var b = new Paragraph("");
            pdfDocument.Add(b);
            pdfDocument.Add(pritable);
            pdfDocument.NewPage(); //New Page
            /* foreach(PdfPTable tempTable in getMaterialRequired()){
                pdfDocument.Add(tempTable);
            } */
            p = new Paragraph(string.Format("Materiales requeridos\n"));
            p.Alignment = Element.ALIGN_CENTER;
            pdfDocument.Add(p);

            pdfDocument.Add(mtable);

            //PdfPCell tempCell = new PdfPCell(new Phrase("Datos de Proyecto",new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 20f, iTextSharp.text.Font.NORMAL)));


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
    public PdfPTable getPrincipalTable()
    {
        PdfPTable principaltable = new PdfPTable(2);
        principaltable.WidthPercentage = 85f;
        principaltable.TotalWidth = 100f;
        principaltable.SetWidths(new float[] { 20f, 80f });
        PdfPCell tempCell;

        //TitleCell
        tempCell = new PdfPCell(new Phrase("Proyecto: " + System.DateTime.Now.ToString("MM/dd/yyyy")));
        tempCell.Colspan = 2;
        tempCell.FixedHeight = 30f;
        principaltable.AddCell(tempCell);


        //Image Project design
        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(lastImageUrl); 
        tempCell = new PdfPCell(image);
        tempCell.Colspan = 2;
        tempCell.HorizontalAlignment = 2;
        tempCell.VerticalAlignment = 2;
        tempCell.MinimumHeight = pdfDocument.PageSize.Height - 220f;

        principaltable.AddCell(tempCell);



        // Information Cells
        // Type Project
        tempCell = new PdfPCell(new Phrase("Tipo: "));
        tempCell.FixedHeight = 30f;
        principaltable.AddCell(tempCell);

        tempCell = new PdfPCell(new Phrase(new ValueString().getName(GameObject.Find("globalData").GetComponent<ArquitectureState>().typeProjectID)));
        tempCell.FixedHeight = 30f;
        principaltable.AddCell(tempCell);

        // Details
        tempCell = new PdfPCell(new Phrase("Detalle: "));
        tempCell.FixedHeight = 30f;
        principaltable.AddCell(tempCell);

        tempCell = new PdfPCell(new Phrase(new ValueString().getName(GameObject.Find("globalData").GetComponent<ArquitectureState>().templateSelectedID)));
        tempCell.FixedHeight = 30f;
        principaltable.AddCell(tempCell);

        // Precio
        tempCell = new PdfPCell(new Phrase("Precio Estimado: "));
        tempCell.FixedHeight = 30f;
        principaltable.AddCell(tempCell);

        tempCell = new PdfPCell(new Phrase("S/. "+price.ToString("N2")));
        tempCell.FixedHeight = 30f;
        principaltable.AddCell(tempCell);


        return principaltable;
    }
    public PdfPTable getMaterialRequired()
    {
        price = 0;
        PdfPTable tempTable = new PdfPTable(5);
        tempTable.WidthPercentage = 85f;
        tempTable.TotalWidth = 80f;
        tempTable.SetWidths(new float[] { 8f, 30f, 22f, 23f, 17f });
        PdfPCell tempCell;
        int rows = 1;

        //Header Cell
        tempCell = new PdfPCell(new Phrase("N°"));
        tempCell.MinimumHeight = 35f;
        tempCell.HorizontalAlignment = 1;
        tempTable.AddCell(tempCell);

        tempCell = new PdfPCell(new Phrase("NOMBRE"));
        tempCell.MinimumHeight = 35f;
        tempCell.HorizontalAlignment = 1;
        tempTable.AddCell(tempCell);

        tempCell = new PdfPCell(new Phrase("Identificador"));
        tempCell.MinimumHeight = 35f;
        tempCell.HorizontalAlignment = 1;
        tempTable.AddCell(tempCell);

        tempCell = new PdfPCell(new Phrase("REQUERIDO"));
        tempCell.MinimumHeight = 35f;
        tempCell.HorizontalAlignment = 1;
        tempTable.AddCell(tempCell);

        tempCell = new PdfPCell(new Phrase("PRECIO\n(Aproximado)"));
        tempCell.MinimumHeight = 35f;
        tempCell.HorizontalAlignment = 1;
        tempTable.AddCell(tempCell);

        ArquitectureState arstt = GameObject.Find("globalData").GetComponent<ArquitectureState>();
        Dictionary<string,
            Dictionary<string, Material>
            > shared = new Dictionary<string, Dictionary<string, Material>>();

        foreach (Part part in arstt.parts)
        {

            GameObject partModel = GameObject.Find("principal/" + part.partName);

            if (partModel)
            {
                foreach (Transform child in partModel.transform)
                {
                    string name = child.gameObject.name;

                    Material material = new ValueString().formatTextToMaterial(name);

                    //print("LLEGO: "+ material.nameEN+ material.position);

                    if (!material.nameEN.Equals("coco"))
                    {
                        if (!shared.ContainsKey(material.nameEN))
                        {
                            if(!ValueString.decorables.Contains(material.nameEN)){
                                if(material.medeasure.Contains("*")){
                                    int height = 0;
                                    int width  = 0;                                   

                                    width = int.Parse(material.medeasure.Substring(material.medeasure.IndexOf("*")+1));
                                    height = int.Parse(material.medeasure.Substring(0, material.medeasure.IndexOf("*")));

                                    int result = height + width + (height + width) / 2;

                                    material.medeasure = ""+result;
                                    shared.Add(
                                        material.nameEN,
                                        new Dictionary<string, Material>(){{
                                            material.properties,
                                            material}
                                    });
                                }else
                                {
                                    shared.Add(
                                    material.nameEN,
                                    new Dictionary<string, Material>(){{
                                        material.properties,
                                        material}
                                    }
                                );
                                }
                            }else
                            {
                             shared.Add(
                                material.nameEN,
                                new Dictionary<string, Material>(){{
                                    material.properties,
                                    material}
                                    }
                                );
                            }
                        }
                        else
                        {
                            if (shared[material.nameEN].ContainsKey(material.properties))
                            {
                                Material actualMaterial = shared[material.nameEN][material.properties];   

                                if (material.medeasure.Contains("*") && ValueString.decorables.Contains(material.nameEN))
                                {
                                    int height = 0;
                                    int width  = 0;

                                    print("ARRIBA: " + material.medeasure);

                                    string w = material.medeasure.Substring(material.medeasure.IndexOf("*")+1);
                                    string h = material.medeasure.Substring(0, material.medeasure.IndexOf("*"));

                                    print("H: "+h+" W: "+w);
                                    

                                    width = int.Parse(material.medeasure.Substring(material.medeasure.IndexOf("*")+1));
                                    height = int.Parse(material.medeasure.Substring(0, material.medeasure.IndexOf("*")));

                                    int tHeight = 0;
                                    int tWidth = 0;
                                    print(actualMaterial.medeasure);
                                    tWidth = int.Parse(actualMaterial.medeasure.Substring(actualMaterial.medeasure.IndexOf("*")+1));
                                    tHeight = int.Parse(actualMaterial.medeasure.Substring(0, actualMaterial.medeasure.IndexOf("*")));

                                    int totalHeight = height + tHeight;
                                    int totalWidth = width  + tWidth;

                                    string result = ""+totalHeight+"*"+totalWidth;

                                    actualMaterial.medeasure = result;

                                    shared[material.nameEN][material.properties] = actualMaterial;

                                }else if(material.medeasure.Contains("*")){
                                    int height = 0;
                                    int width  = 0;                                   

                                    width = int.Parse(material.medeasure.Substring(material.medeasure.IndexOf("*")+1));
                                    height = int.Parse(material.medeasure.Substring(0, material.medeasure.IndexOf("*")));

                                    int result = height + width + (height + width) / 2;

                                    int actualMedeasure = int.Parse(actualMaterial.medeasure);

                                    int newValue = actualMedeasure + result;

                                    actualMaterial.medeasure = ""+newValue;

                                    shared[material.nameEN][material.properties] = actualMaterial;
                                }
                                else{
                                    double actualMeasureTmp = double.Parse(actualMaterial.medeasure.Replace(",", "."));

                                    double newMeasure = double.Parse(material.medeasure.Replace(",", "."));

                                    actualMeasureTmp = actualMeasureTmp + newMeasure;

                                    actualMaterial.medeasure = "" + actualMeasureTmp;

                                    shared[material.nameEN][material.properties] = actualMaterial;
                                }                                

                            }
                            else
                            {

                                shared[material.nameEN].Add(material.properties,  material );

                            }
                        }
                    }
                }
            }
        }

        foreach (string name in shared.Keys)
        {

            foreach (string part in shared[name].Keys)
            {

                tempCell = new PdfPCell(new Phrase("" + rows));
                tempCell.MinimumHeight = 35f;
                tempCell.HorizontalAlignment = 0;
                tempTable.AddCell(tempCell);

                tempCell = new PdfPCell(new Phrase(new ValueString().getNameMaterial(name)));
                tempCell.MinimumHeight = 35f;
                tempCell.HorizontalAlignment = 0;
                tempTable.AddCell(tempCell);

                tempCell = new PdfPCell(new Phrase(part + " " +shared[name][part].typeProperty));
                tempCell.MinimumHeight = 35f;
                tempCell.HorizontalAlignment = 0;
                tempTable.AddCell(tempCell);

                if(shared[name][part].medeasure.Contains("*")){
                    int width = 0;
                    int height = 0;
                    width = int.Parse(shared[name][part].medeasure.Substring(shared[name][part].medeasure.IndexOf("*")+1));
                    height = int.Parse(shared[name][part].medeasure.Substring(0, shared[name][part].medeasure.IndexOf("*")));

                    double result = (width + height) * (0.40);
                    price = price + result;

                    tempCell = new PdfPCell(new Phrase(""+width+" cm x\n"+height+" cm"));
                    tempCell.MinimumHeight = 35f;
                    tempCell.HorizontalAlignment = 0;
                    tempTable.AddCell(tempCell);

                    tempCell = new PdfPCell(new Phrase("S/. "+result.ToString("N2")));
                    tempCell.MinimumHeight = 35f;
                    tempCell.HorizontalAlignment = 0;
                    tempTable.AddCell(tempCell);


                }
                else
                {
                    tempCell = new PdfPCell(new Phrase(shared[name][part].medeasure  + " cm"));
                    tempCell.MinimumHeight = 35f;
                    tempCell.HorizontalAlignment = 0;
                    tempTable.AddCell(tempCell);

                    double result = int.Parse(shared[name][part].medeasure ) * 1.35;
                    price = price + result;


                    tempCell = new PdfPCell(new Phrase("S/. "+result.ToString("N2")));
                    tempCell.MinimumHeight = 35f;
                    tempCell.HorizontalAlignment = 0;
                    tempTable.AddCell(tempCell);
                }
                
                


            }



            rows++;
        }

        return tempTable;
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
