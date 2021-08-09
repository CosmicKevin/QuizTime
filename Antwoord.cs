
namespace QuizTime
{
    public class Antwoord
    {
        public Antwoord(string vraag, string antwoordA, string antwoordB, string antwoordC, string antwoordD, int tijd)
        {
            Vraag = vraag;
            AntwoordA = antwoordA;
            AntwoordB = antwoordB;
            AntwoordC = antwoordC;
            AntwoordD = antwoordD;
            Tijd = tijd;
        }

        public string Vraag { get; private set; }
        public string AntwoordA { get; private set; }
        public string AntwoordB { get; private set; }
        public string AntwoordC { get; private set; }
        public string AntwoordD { get; private set; }
        public int Tijd { get; private set; }
    }
}
