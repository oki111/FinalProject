using SalonVencanica.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SalonVencanica.WebUI.HtmlHelpers
{
    //ovo je staticka klasa koja ne moze da se instancira i moze joj se pristupiti direktno po nazivu
    //u ovoj klasi pravimo navigacione dugmice za stranice sa proizvodima
    public static class PagingHelpers
    {
        //ovo je metod ekstenzije (extension method)
        //on je po definiciji staticki i njegov prvi ulazni argument po konvenciji mora da sadrzi keyword 'this'
        //ovaj metod se poziva u View 'List.cshtml' kroz HTML protokol i taj protokol zapravo po konvenciji zahteva da ovaj metod bude u ovakvoj formi kakvoj jeste
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            //objekat stringbuilder kkoji ce kreirati web adresu za svako numericko dugme
            StringBuilder result = new StringBuilder();

            //petlja koja ide kroz sve stranice sadrzane u modelu PagingInfo i kreira HTML blok koji se salje u View Product
            //logika koja se nalazi unutar petlje je preuzeta sa stackoverflow i uskladjena za potrebe projekta
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                //prvo pravimo tag element sa 'a' oznakom, sto predstavlja web-link
                TagBuilder tag = new TagBuilder("a");

                //zatim dodajemo ostale potrebne delove linka i numericki broj stranice
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                //ako se broj linka podudara sa trenutnom stranicom
                if (i == pagingInfo.CurrentPage)
                {
                    //onda dodajemo bootstrap klase koje se odnosi na selektovano i primarno dugme
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }

                //takodje dodajemo bootstrap klasu za default dugme
                tag.AddCssClass("btn btn-default");

                //sada ovaj kreirani HTML blok saljem u stringbuilder objekat
                result.Append(tag.ToString());

            }

            //vracamo stringbuilder objekat ka View koome je potreban (List.cshtml)
            return MvcHtmlString.Create(result.ToString());
        }
    }
}