using System;
using System.Collections.Generic;

struct Link
{
    public int L1;
    public int L2;
}

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        List<Link> Links = new List<Link>();
        List<int> Gateways = new List<int>();
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            Link link = new Link();
            link.L1 = N1;
            link.L2 = N2;
            Links.Add(link);
        }
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            Gateways.Add(EI);
        }

        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn

            // Possible links worth checking are all links to the Bobnet agent node.
            List<Link> PossLinks = Links.FindAll(l => l.L1 == SI || l.L2 == SI);

            // In case we don't find a better link below we just take the first.
            Link l = PossLinks[0];

            // Check if the agent is on a node linked to an exit. In that case sever that link.
            for (int i = 0; i < PossLinks.Count; i++)
            {
                for (int j = 0; j < Gateways.Count; j++)
                {
                    if (PossLinks[i].L1 == Gateways[j] || PossLinks[i].L2 == Gateways[j])
                    {
                        l = PossLinks[i];
                    }
                }
            }
            Links.Remove(l);
            Console.WriteLine($"{l.L1} {l.L2}");
        }
    }
}