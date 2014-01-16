using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

//Nathan Pillman is working on this. Working on it immediately!
namespace SeniorGen
{
    class TextFileWriter
    {
        string[] saveDEST = new string[4];
        StreamWriter Save;// = new StreamWriter("dir/file.ext");
        StreamWriter Students;
        StreamWriter Teachers;

        public void NewFile(string PathDest) {
            //MessageBox.Show(PathDest); | Made to Test path directory. No final "\";
            try { 
                saveDEST[0] = PathDest + "/HighSchool-SeniorMarch.smnw";
                saveDEST[1] = PathDest + "/Student.list.smnw";
                saveDEST[2] = PathDest + "/Teacher.list.smnw";
                Save = new StreamWriter(File.Create(saveDEST[0]));
                Students = new StreamWriter(File.Create(saveDEST[1]));
                Teachers = new StreamWriter(File.Create(saveDEST[2]));
                Save.WriteLine("<save>\n<students>" + saveDEST[1] + "</students>\n<teachers>" + saveDEST[2] + "</teachers>\n</save>"); 
                Save.Close(); 
            }
            catch (Exception errorBOO) { MessageBox.Show("Error creating files in the path: " + PathDest + "\n-Is this an administartion directory? If so please run this as administration or choose a directory under your Documents.\n\n-Is there already a file created? Check for a file named \"HighSchool-SeniorMarch.smnw\"? If so Load that file instead!\n\n\nExact Error for the \"HUMANS\": \n" + errorBOO.Message.ToString()); }
        }
        public void LoadFile(string FileDest)
        {

            try { XDocument doc = XDocument.Load(FileDest); saveDEST[1] = doc.Descendants("students").InDocumentOrder().ToString(); MessageBox.Show(saveDEST[1]); }
            catch (Exception errorBOO) { MessageBox.Show("Error opening save. \n\n\nExact Error for the \"HUMANS\": \n" + errorBOO.Message.ToString()); }
        }

    }
}
