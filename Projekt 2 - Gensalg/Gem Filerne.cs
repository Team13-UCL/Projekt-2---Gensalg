using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class GemFilerne
{

    public void GemData(List<string> data, string filnavn)
    {
        using (StreamWriter sw = new StreamWriter(filnavn))
        {
            foreach (var element in data)
            {
                sw.WriteLine(element);
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
