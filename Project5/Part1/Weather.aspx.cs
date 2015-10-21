using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Xml;

namespace Part1
{
    public partial class Weather : System.Web.UI.Page
    {
        Part1.gov.weather.graphical.ndfdXML weatherService;
        protected void Page_Load(object sender, EventArgs e)
        {
            weatherService = new gov.weather.graphical.ndfdXML();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string codes;
            string[] zipCodes;
            bool illegal;

            codes = zipBox.Text.Replace(" ", "");
            zipCodes = codes.Split(',');
            illegal = false;

            foreach (string word in zipCodes)
            {
                if (word.Length != 5 || !Regex.IsMatch(word, @"^\d+$"))
                {
                    infoLabel.Text = "Illegal input, seperate zipcodes by comma";
                    illegal = true;
                    break;
                }
            }
            if (!illegal)
            {
                infoLabel.Text = "";
                DisplayWeather(zipCodes);
            }
        }

        protected void DisplayWeather(string[] zipCodes)
        {
            decimal lat;
            decimal lon;
            string[] latlon;
            WeatherDay[] dailyWeather;
            int count;
            weatherTable.Rows.Clear();
            foreach (string zip in zipCodes)
            {
                dailyWeather = new WeatherDay[5];
                string xmlZip = weatherService.LatLonListZipCode(zip);
                xmlZip = xmlZip.Remove(0, xmlZip.IndexOf("latLonList") + 11);
                xmlZip = xmlZip.Remove(xmlZip.IndexOf("<"));
                latlon = xmlZip.Split(',');
                try
                {
                    lat = decimal.Parse(latlon[0]);
                    lon = decimal.Parse(latlon[1]);

                    string XMLforecast = weatherService.NDFDgenByDay(lat, lon, DateTime.Today, "5",
                        Part1.gov.weather.graphical.unitType.m, Part1.gov.weather.graphical.formatType.Item24hourly);
                    XmlDocument weather = new XmlDocument();
                    weather.LoadXml(XMLforecast);

                    XmlNodeList temperature = weather.GetElementsByTagName("temperature");
                    foreach (XmlNode node in temperature)
                    {
                        count = 0;
                        if (node.Attributes["type"].Value.Equals("maximum"))
                        {
                            foreach (XmlNode val in node.ChildNodes)
                            {
                                if (val.Name.Equals("value"))
                                {
                                    dailyWeather[count] = new WeatherDay();
                                    dailyWeather[count].maxTemp = val.InnerText;
                                    count++;
                                }
                            }
                        }
                        if (node.Attributes["type"].Value.Equals("minimum"))
                        {
                            foreach (XmlNode val in node.ChildNodes)
                            {
                                if (val.Name.Equals("value"))
                                {
                                    dailyWeather[count].minTemp = val.InnerText;
                                    count++;
                                }
                            }
                        }
                    }

                    XmlNodeList weatherConditions = weather.GetElementsByTagName("weather");
                    count = 0;
                    foreach (XmlNode node in weatherConditions)
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.Name.Equals("weather-conditions"))
                            {
                                dailyWeather[count].desc = child.Attributes["weather-summary"].Value;
                                count++;
                            }
                        }
                    }

                    XmlNodeList icons = weather.GetElementsByTagName("conditions-icon");
                    count = 0;
                    foreach (XmlNode node in icons)
                    {
                        foreach(XmlNode val in node.ChildNodes)
                            if (val.Name.Equals("icon-link"))
                            {
                                dailyWeather[count].imgString = val.InnerText;
                                count++;
                            }
                    }

                    TableCell tempCell = new TableCell();
                    tempCell.Text = "Weather for zipcode: " + zip;
                    TableRow tempRow = new TableRow();
                    tempRow.Cells.Add(tempCell);
                    weatherTable.Rows.Add(tempRow);
                    tempRow = new TableRow();

                    foreach (WeatherDay day in dailyWeather)
                    {
                        tempCell = new TableCell();
                        tempCell.BorderWidth = 3;
                        tempCell.Text = "<img src=\"" + day.imgString + "\"><br/>" +  
                            day.desc + "<br/>" + "Min: " + day.minTemp + " Max: " + day.maxTemp;
                        tempRow.Cells.Add(tempCell);
                    }
                    weatherTable.Rows.Add(tempRow);
                }
                catch (FormatException)
                {
                    TableCell tempCell = new TableCell();
                    tempCell.Text = "Unable to locate weather for " + zip;
                    TableRow tempRow = new TableRow();
                    tempRow.Cells.Add(tempCell);
                    weatherTable.Rows.Add(tempRow);
                    tempRow = new TableRow();
                }

            }
        }
    }
}