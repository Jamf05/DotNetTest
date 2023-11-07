using System.Xml;

namespace DotNetTest.Infrastructure.Finder.Util;

public static class SqlReader
{
    public static Task<string> GetQuery(string query)
    {
        XmlTextReader xmlReader = new XmlTextReader(Directory.GetCurrentDirectory() + "/Configuration/queries.xml");
        var queryFounded = false;
        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element)
            {
                while (xmlReader.MoveToNextAttribute())
                {
                    if (xmlReader.Value.Equals(query))
                    {
                        queryFounded = true;
                        break;
                    }
                }
            }

            if (queryFounded)
            {
                var line = xmlReader.Value.ToLower();
                if (line.Trim().Contains("select"))
                {
                    return Task.FromResult(xmlReader.Value);
                }
            }
        }

        return Task.FromResult("");
    }

    public static Task<string> GetCommand(string command)
    {
        XmlTextReader xmlReader = new XmlTextReader(Directory.GetCurrentDirectory() + "/Configuration/commands.xml");
        var commandFounded = false;
        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element)
            {
                while (xmlReader.MoveToNextAttribute())
                {
                    if (xmlReader.Value.Equals(command))
                    {
                        commandFounded = true;
                        break;
                    }
                }
            }

            if (commandFounded)
            {
                var line = xmlReader.Value.ToLower();
                if (line.Trim().Contains("insert") || line.Trim().Contains("update"))
                {
                    return Task.FromResult(xmlReader.Value);
                }
            }
        }

        return Task.FromResult("");
    }
}