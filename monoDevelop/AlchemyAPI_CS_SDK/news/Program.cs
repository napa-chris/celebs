﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlchemyAPI;

namespace news
{
    class Program
    {
        static void Main(string[] args)
        {
            AlchemyAPI.AlchemyAPI alchemyObj = new AlchemyAPI.AlchemyAPI();
            alchemyObj.SetAPIKey("6b5aa8499e9a98215e57cf2ef6a0456654be777b");

            AlchemyAPI_NewsParams prms = new AlchemyAPI_NewsParams();
            prms.setStartDate(5, 'd');
            prms.setStartDate();
            string[] taxonomy = {"sports"};
            prms.addTaxonomy(taxonomy);
            string xml = alchemyObj.GetNews(prms);
        }
    }
}
