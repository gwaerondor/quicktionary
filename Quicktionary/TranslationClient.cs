using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

public class TranslationClient
{
    public TranslationClient()
    {

    }

    private string CreateHTTPRequest(string requestedWord)
    {
        return "http://www.dict.com/Chinese-English/ " + requestedWord + "?";
    }

    public string Request(string word)
    {
        WebClient myClient = new WebClient();
        string requestURI = CreateHTTPRequest(word);
        byte[] binary = myClient.DownloadData(requestURI);
        string result = System.Text.Encoding.UTF8.GetString(binary);
        return FilterMatches(result);
    }

    // This'll do for now, I'm sleepy and want to commit.
    // Need to not use regex for XML parsing though. Look into this one:
    // http://stackoverflow.com/questions/2441673/reading-xml-with-xmlreader-in-c-sharp
    private string FilterMatches(string webpage)
    {
        string filtered = "";
        MatchCollection matches = Regex.Matches(webpage, "\\<input id=\"IdxSet\" type=\"hidden\".*");
        Console.WriteLine("matches: {0}", matches.Count);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.ToString());
            filtered += match.ToString() + "\n\n\n";
        }
        return filtered;
    }
}