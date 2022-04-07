using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glasnost_back.Utils
{
    public static class Format
    {
        public static string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static string ToTitleCase(string frase)
        {
            List<string> fraseList = new List<string> { };
            fraseList = frase.Trim().Split(' ').ToList();
            List<string> newFraseList = new List<string> { };
            List<string> naoConverte = new List<string> { "em", "de", "da", "do", "das", "dos", "e", "o", "a", "os", "as", "para", "por", "LTDA", "no", "na", "nos", "nas" };

            foreach (string palavra in fraseList)
            {
                if (palavra.Trim() != "")
                {
                    if (!naoConverte.Contains(palavra.ToLower()))
                    {
                        string newPalavra = palavra.Substring(0, 1).ToUpper() + palavra.Substring(1, palavra.Length - 1).ToLower();
                        newFraseList.Add(newPalavra);
                    }
                    else if (palavra.ToLower() == "tocomply")
                    {
                        newFraseList.Add("ToComply");
                    }
                    else
                    {
                        newFraseList.Add(palavra.ToLower());
                    }
                }
            }
            frase = string.Join(" ", newFraseList);
            return frase;
        }

        public static string FormatId(int number, int len = 4, char c = '0')
        {
            return new string(c, len - number.ToString().Length) + number.ToString();
        }

        public static string GetMonth(int index)
        {
            if (index < 0 || index > 12)
                return "Mês inválido";
            List<string> meses = new List<string> { "-", "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            return meses[index];
        }

    }
}
