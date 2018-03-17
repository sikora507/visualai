using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AiCore
{
    public class VisNetwork
    {

        [JsonProperty(PropertyName = "nodes")]
        public List<Node> Nodes { get; } = new List<Node>();
        [JsonProperty(PropertyName = "edges")]
        public List<Edge> Edges { get; } = new List<Edge>();

    }

    public class Node
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
    }

    public class Edge
    {
        [JsonProperty(PropertyName = "from")]
        public int From { get; set; }
        [JsonProperty(PropertyName = "to")]
        public int To { get; set; }
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
    }
}
