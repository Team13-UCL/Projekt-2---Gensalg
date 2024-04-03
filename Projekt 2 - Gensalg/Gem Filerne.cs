using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Projekt_2___Gensalg;

public class GemFilerne
{

    public void GemData(List<Spil> data, string filnavn)
    {
        using (StreamWriter sw = new StreamWriter(filnavn,false))
        {
            foreach (var element in data)
            {
                sw.WriteLine(element.Navn);
            }
        }

    }

    public List<string> IndlæsData(string filnavn)
    {
        List<string> data = new List<string>();
        using (StreamReader sr = new StreamReader(filnavn))
        {
            string linje;
            while ((linje = sr.ReadLine()) != null)
            {
                data.Add(linje);
            }
        }
        return data;
    }
}
